using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    float panSpeed = 20.0f;

    [SerializeField]
    public float acceleration = 2.0f;

    [SerializeField]
    public float deceleration = 3.0f;

    [SerializeField]
    public float zoomSpeed = 4.0f;

    [SerializeField]
    public float minY = 10.0f;

    [SerializeField]
    public float maxY = 80.0f;

    [SerializeField]
    public Vector2 panLimit;

    private Vector3 velocity = Vector3.zero;
    private CinemachineComponentBase componentBase;

    void Start()
    {
        if (virtualCamera != null)
        {
            componentBase = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        }
    }

    void Update()
    {
        if (virtualCamera == null || componentBase == null) return;

        // 入力に基づく目標速度
        Vector3 targetVelocity = Vector3.zero;
        if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
        {
            targetVelocity.z += panSpeed;
        }
        if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
        {
            targetVelocity.z -= panSpeed;
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            targetVelocity.x -= panSpeed;
        }
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            targetVelocity.x += panSpeed;
        }

        // 現在の速度を更新
        velocity = Vector3.MoveTowards(velocity, targetVelocity, (targetVelocity == Vector3.zero ? deceleration : acceleration) * Time.deltaTime);

        // カメラの新しい位置を計算
        Vector3 pos = virtualCamera.transform.position + velocity * Time.deltaTime;

        // マウスホイールによるズーム
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (virtualCamera.m_Lens.Orthographic)
        {
            virtualCamera.m_Lens.OrthographicSize -= scroll * zoomSpeed;
            virtualCamera.m_Lens.OrthographicSize = Mathf.Clamp(virtualCamera.m_Lens.OrthographicSize, minY, maxY);
        }
        else
        {
            pos.y -= scroll * zoomSpeed * 100.0f * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
        }

        // 移動範囲を制限
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        // カメラの位置を更新
        virtualCamera.transform.position = pos;
    }

}