using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum Society //eunumはデフォルトで上から0,1,2... と対応している
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

    //地球の状態-非固定値、低頻度の変更//

    //人口確認-文明発展度合い算出の際に参照
    private int _population; //private変数には戦闘に_つける ex)EarthManger.instance.EarthInfo._population て書いたら気持ち悪いから！
    //文明度-人口増加率算出の際に参照
    private Society _society;
    //Populationを呼び出すと_populationの値を参照することができる　書き換えられない
    public int Population => _population;
    public Society Society => _society;

    //環境汚染度-値により文明の後退、滅亡を引き起こす
    [HideInInspector]
    public int environmentalPollutionLevel; 

    //地球の状態-非固定値、高頻度の変更
    public Season CurrentSeason;

    public Weather CurrentWeather;

    public void SetPoputaion(int population)
    {
        _population = population;
    }

    public void SetSociety(Society society)
    {
        _society = society;
    }
}
