using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
public class PopulationIncreaseManager : MonoBehaviour //�l���ω���S��
{
    public float increment;    //�����x(EarthManager����Q�b�g����)�ɂ��ω��������B

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
        _elapsedTime++; //�v���C���[���X�}�z����Ă����̌v�Z�p�@�ۑ��K�{�I
        if (EarthManager.Instance.CurrentEarthInfo.Population == 0) //�����l��^����
        {
            int population = 2; //�A�_���ƃC�u
            EarthManager.Instance.CurrentEarthInfo.SetPoputaion(population);//unity��������̂�21���܂�
             
        }
        else if(EarthManager.Instance.CurrentEarthInfo.Population != 0) //�l����؃o�O�h�~
        {
            if((int)Mathf.Floor(((increment / 100)) * EarthManager.Instance.CurrentEarthInfo.Population) <= 1)
            {
                int population = EarthManager.Instance.CurrentEarthInfo.Population + 1;

                EarthManager.Instance.CurrentEarthInfo.SetPoputaion(population);//unity��������̂�21���܂�
            }
            if((int)Mathf.Floor(((increment / 100)) * EarthManager.Instance.CurrentEarthInfo.Population) > 1) //�������������đ�������1�𒴂��鎞�v�Z����؂�ւ���
            {
                int population = (int)Mathf.Floor((1 + (increment / 100)) * EarthManager.Instance.CurrentEarthInfo.Population); //�v�Z�����p : https://dmpl.doshisha.ac.jp/wp-content/uploads/2015/06/simulation_and_model.pdf 

                EarthManager.Instance.CurrentEarthInfo.SetPoputaion(population);//unity��������̂�21���܂�
            }
        }
    }

    private void IncreaseLevelofSociety()
    {
        //enum��society�Ƃ̍�����h�����߂�civilisation���g�p����
        int population = EarthManager.Instance.CurrentEarthInfo.Population;
        Society society = EarthManager.Instance.CurrentEarthInfo.Society; //���݂̐i���xSociety���ꎞ�ϐ�society�ɑ��

        if (population > _societyChangeThreshold[society])
        {
            //society��enum�f�t�H���g�̃V���A���i���o�[�ɒ����Ă����đ����B
            //�����object�^�ɕύX���Ă�����Society�^�ɕύX���Ă����� ToSociety�Ƃ��͂ł��Ȃ��̂ŁA�ėp�^��object�ɂ���@�\���͂���ł���B�@
            society = (Society)Enum.ToObject(typeof(Society), (int)society + 1);
            EarthManager.Instance.CurrentEarthInfo.SetSociety(society);
        }
        Debug.Log(society);
    }
}
