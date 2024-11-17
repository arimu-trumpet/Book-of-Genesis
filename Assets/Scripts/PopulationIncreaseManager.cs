using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
public class EarthStatusManager : MonoBehaviour //�l���ω���S��
{
    public float increment;    //EarthManager����Q�b�g���������x�ɂ��ω��������B

    private int _elapsedTime; //�l���̌v�Z�Ɏg�p

    private Dictionary<Society, float> _societyChangeThreshold = new Dictionary<Society, float>()
    {
        {Society.HUNTERGATHERER,10},
        {Society.AGRICULTURAL,100},
        {Society.INDUSTRIAL,1000},
        {Society.INFORMATION,10000},
        {Society.SUPERSMART,100000}
    };
    // Start is called before the first frame update
    void Start()
    {
        Observable.Interval(TimeSpan.FromSeconds(1)) //UniRx�̓X�^�[�g�ŌĂяo���Ă�����Ώ���ɓ���
                         .Subscribe(_ =>
                            {
                                increment = 1.00001f;
                                IncreasePopulation();

                                IncreaseLevelofSociety();

                            }).AddTo(this); //���̃X�N���v�g���A�^�b�`�����I�u�W�F�N�g����������~�܂��R�[�h
    }

    // Update is called once per frame
    private void IncreasePopulation()
    {
        _elapsedTime++;
        int population = (int)Mathf.Floor(1 * (1 - Mathf.Pow(increment, _elapsedTime)) / (1 - increment));
        EarthManager.Instance.EarthInfo.SetPoputaion(population);//unity��������̂�21���܂�
        Debug.Log(population);
    }

    private void IncreaseLevelofSociety()
    {
        //enum��society�Ƃ̍�����h�����߂�civilisation���g�p����
        int population = EarthManager.Instance.EarthInfo.Population;
        Society society = EarthManager.Instance.EarthInfo.Society; //���݂̐i���xSociety���ꎞ�ϐ�society�ɑ��

        if (population > _societyChangeThreshold[society])
        {
            //society��enum�f�t�H���g�̃V���A���i���o�[�ɒ����Ă����đ����B�����object�^�ɕύX���Ă�����Society�^�ɕύX���Ă����� ToSociety�Ƃ��͂ł��Ȃ��̂ŁA���ėp�^��object�ɂ���@�\���͂���ł���B�@
            society = (Society)Enum.ToObject(typeof(Society), (int)society + 1);
            EarthManager.Instance.EarthInfo.SetSociety(society);
        }
        Debug.Log(society);
    }
}
