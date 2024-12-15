using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum Society //eunum�̓f�t�H���g�ŏォ��0,1,2... �ƑΉ����Ă���
{
    HUNTERGATHERER,
    AGRICULTURAL,
    INDUSTRIAL,
    INFORMATION,
    SUPERSMART
}
public enum Season
{
    SPRING,
    SUMMER,
    AUTUMN,
    WINTER
}

public enum Weather
{
    SUNNY,
    RAINY,
    CLOUDY,
    SNOWY
}
public class EarthManager : SingletonMonoBehaviour<EarthManager>
{
    public List<Earth> EarthInfoList = new List<Earth>();  //Earthclass�ɂ���ϐ���񂪑S�������Ă��� ex)EarthManager.instance.EarthInfo.seacolour

    public Earth CurrentEarthInfo;

    public void AddEarth(Earth newEarth) //CreateINputHandler�ŌĂяo���ăA�[�X��ۑ�
    {
        EarthInfoList.Add(newEarth);

        SaveEarth();
    }
    public void SaveEarth()
    {
        var earthJson = JsonUtility.ToJson(EarthInfoList); //������n���f�[�^�����ׂĕۑ�

        PlayerPrefs.SetString("EarthInfo", earthJson);

        PlayerPrefs.Save();
    }
    public void OnEnable()
    {
        if (PlayerPrefs.HasKey("EarthInfo")) //"EarthInfo"���f�[�^�������Ă��邩�ǂ���
        {

             var earthJson = PlayerPrefs.GetString("EarthInfo");

             EarthInfoList = JsonUtility.FromJson<List<Earth>>(earthJson);
        }
      
    }

    public void OnDisable()
    {
        SaveEarth();
    }

}

[Serializable]
public class Earth
{
    public string LightName;

    public string DayName;

    public string HeavenName;

    public string LandName;

    public string SeaName;

    public string NightName;
    //�n���̌�����-�Œ�l
    public int SeaColour;

    public int GroundColour;

    //�n���̏��-��Œ�l�A��p�x�̕ύX//

    //�l���m�F-�������W�x�����Z�o�̍ۂɎQ��
    private int _population; //private�ϐ��ɂ͐퓬��_���� ex)EarthManger.instance.EarthInfo._population �ď�������C������������I

    //�����x-�l���������Z�o�̍ۂɎQ��
    private Society _society;

    //Population���Ăяo����_population�̒l���Q�Ƃ��邱�Ƃ��ł���@�����������Ȃ�
    public int Population => _population;
    public Society Society => _society;

    //�������x-�l�ɂ�蕶���̌�ށA�ŖS�������N����
    [HideInInspector]
    public int environmentalPollutionLevel; //DO:�����get set �ŏ���

    //�n���̏��-��Œ�l�A���p�x�̕ύX
    public Season CurrentSeason;

    public Weather CurrentWeather;

    public void SetPoputaion(int population) //���̃X�N���v�g����ϐ���ҏW����ۂɎg�p����
    {
        _population = population;
    }

    public void SetSociety(Society society)
    {
        _society = society;
    }
}
