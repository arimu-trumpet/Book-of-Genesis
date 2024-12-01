using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _meteoriteImpact;

    [SerializeField] private Animator _humanAttackMoving;

    [SerializeField] private List<Animator> _humanAttackRunning;

    [SerializeField] private int _occurRebellionPopulation; //�l�Ԃ������������̒l(�e���E���Ƃɂ���͈͂Ń����_�������Ă�������)
    void Start()
    {
        _meteoriteImpact.speed = 0;

        _humanAttackMoving.speed = 0;

        // ���X�g���̂��ׂĂ�Animator�ɑ΂��ď��������s
        foreach (Animator animator in _humanAttackRunning)
        {
            animator.speed = 0;
        }
    }
    void Update()
    {
        // ���X�g���̂��ׂĂ�Animator�ɑ΂��ď��������s
        if (EarthManager.Instance.EarthInfo.Population >= _occurRebellionPopulation)
        {
            _humanAttackMoving.speed = 1;

            _humanAttackMoving.Play("HumanRebellion");

            foreach (Animator animator in _humanAttackRunning)
            {
                animator.speed = 1;
                // ���݂̃X�e�[�g�̏����擾
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                // �����_���ȊJ�n���ԂŃA�j���[�V�������Đ�
                animator.Play(stateInfo.shortNameHash, 0, Random.Range(0f, 1f));
            }
  
        }
    }
    public void Onclik() //�ŖS�{�^���������ꂽ�Ƃ�覐ΏՓ�
    {
        _meteoriteImpact.speed = 1;

        _meteoriteImpact.Play("MeteoriteImpact");
    }
}
//�l�Ԃ̔�������̃A�j���[�V�����𒲐߂���