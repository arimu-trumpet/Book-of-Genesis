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
    public Earth EarthInfo;  //Earthclassにある変数情報が全部入っている ex)EarthManager.instance.EarthInfo.seacolour
    
}

[Serializable]
public class Earth
{ 
    //地球の見た目-固定値
    public int SeaColour;

    public int GroundColour;

    //地球の状態-非固定値、低頻度の変更
    [HideInInspector]
    public int HumanNum; //人口確認-文明発展度合い算出の際に参照

    [HideInInspector]
    public int environmentalPollutionLevel; //環境汚染度-値により文明の後退、滅亡を引き起こす

    public Society CurrentSociety;

    //地球の状態-非固定値、高頻度の変更
    public Season CurrentSeason;

    public Weather CurrentWeather;
}
