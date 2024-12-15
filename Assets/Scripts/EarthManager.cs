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
    public List<Earth> EarthInfoList = new List<Earth>();  //Earthclassにある変数情報が全部入っている ex)EarthManager.instance.EarthInfo.seacolour

    public Earth CurrentEarthInfo;

    public void AddEarth(Earth newEarth) //CreateINputHandlerで呼び出してアースを保存
    {
        EarthInfoList.Add(newEarth);

        SaveEarth();
    }
    public void SaveEarth()
    {
        var earthJson = JsonUtility.ToJson(EarthInfoList); //今ある地球データをすべて保存

        PlayerPrefs.SetString("EarthInfo", earthJson);

        PlayerPrefs.Save();
    }
    public void OnEnable()
    {
        if (PlayerPrefs.HasKey("EarthInfo")) //"EarthInfo"がデータを持っているかどうか
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
    public int environmentalPollutionLevel; //DO:これもget set で書く

    //地球の状態-非固定値、高頻度の変更
    public Season CurrentSeason;

    public Weather CurrentWeather;

    public void SetPoputaion(int population) //他のスクリプトがら変数を編集する際に使用する
    {
        _population = population;
    }

    public void SetSociety(Society society)
    {
        _society = society;
    }
}
