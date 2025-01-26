using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWorldAnimator : MonoBehaviour
{
    [SerializeField] private Animator _meteoriteImpact;

    [SerializeField] private Animator _humanAttackMoving;

    [SerializeField] private List<Animator> _humanAttackRunning;

    [SerializeField] private int _occurRebellionPopulation; //人間が反乱する既定の人口(各世界ごとにある範囲でランダムせっていしたい)

    private bool _isAnimationPlayed; //人間の反乱が再生されたかどうか:デフォルトでfalse
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
        if (EarthManager.Instance.CurrentEarthInfo.Population >= _occurRebellionPopulation && _isAnimationPlayed == false) //bool型のやつないと、アップデートで繰り返すときにまた最初から再生され続けちゃう
        {                                                                                                            //_isAnimationPlayedがfalse,つまりアニメーションがまだ一度も再生されていないときにだけこれを再生し始められる
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
            _isAnimationPlayed = true;
        }
    }
    public void Onclik() //滅亡ボタンが押されたとき隕石衝突
    {
        _meteoriteImpact.speed = 1;

        _meteoriteImpact.Play("MeteoriteImpact");
    }
}