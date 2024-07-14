using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum Society
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
    public Earth EarthInfo;  //Earthclass�ɂ���ϐ���񂪑S�������Ă��� ex)EarthManager.instance.EarthInfo.seacolour
    
}

[Serializable]
public class Earth
{ 
    //�n���̌�����-�Œ�l
    public int SeaColour;

    public int GroundColour;

    //�n���̏��-��Œ�l�A��p�x�̕ύX
    [HideInInspector]
    public int HumanNum; //�l���m�F-�������W�x�����Z�o�̍ۂɎQ��

    [HideInInspector]
    public int environmentalPollutionLevel; //�������x-�l�ɂ�蕶���̌�ށA�ŖS�������N����

    public Society CurrentSociety;

    //�n���̏��-��Œ�l�A���p�x�̕ύX
    public Season CurrentSeason;

    public Weather CurrentWeather;
}
