using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _meteoriteImpact;

    [SerializeField] private Animator _humanAttackMoving;

    [SerializeField] private List<Animator> _humanAttackRunning;

    [SerializeField] private int _occurRebellionPopulation; //人間が反乱する既定の値(各世界ごとにある範囲でランダムせっていしたい)
    void Start()
    {
        _meteoriteImpact.speed = 0;

        _humanAttackMoving.speed = 0;

        // リスト内のすべてのAnimatorに対して処理を実行
        foreach (Animator animator in _humanAttackRunning)
        {
            animator.speed = 0;
        }
    }
    void Update()
    {
        // リスト内のすべてのAnimatorに対して処理を実行
        if (EarthManager.Instance.EarthInfo.Population >= _occurRebellionPopulation)
        {
            _humanAttackMoving.speed = 1;

            _humanAttackMoving.Play("HumanRebellion");

            foreach (Animator animator in _humanAttackRunning)
            {
                animator.speed = 1;
                // 現在のステートの情報を取得
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                // ランダムな開始時間でアニメーションを再生
                animator.Play(stateInfo.shortNameHash, 0, Random.Range(0f, 1f));
            }
  
        }
    }
    public void Onclik() //滅亡ボタンが押されたとき隕石衝突
    {
        _meteoriteImpact.speed = 1;

        _meteoriteImpact.Play("MeteoriteImpact");
    }
}
//人間の反乱周りのアニメーションを調節する