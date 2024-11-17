using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
public class PopulationIncreaseManager : MonoBehaviour //�l���ω���S��
{
    [HideInInspector]
    public float Population;   //EarthManager�ɃQ�b�g����ĕ����x�̌���Ɏg�p

    public float increment;    //EarthManager����Q�b�g���������x�ɂ��ω��������B

    private int elapsedTime; //�l���̌v�Z�Ɏg�p
    // Start is called before the first frame update
    void Start()
    {
        increment = 1.00001f;

        Observable.Interval(TimeSpan.FromSeconds(1)) //UniRx�̓X�^�[�g�ŌĂяo���Ă�����Ώ���ɓ���
            .Subscribe(_ =>
            {
                elapsedTime ++;
                Population = Mathf.Floor(1 * (1 - Mathf.Pow(increment, elapsedTime)) / (1 - increment));
                Debug.Log(Population);

            }).AddTo(this); //���̃X�N���v�g���A�^�b�`�����I�u�W�F�N�g����������~�܂��R�[�h

    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
