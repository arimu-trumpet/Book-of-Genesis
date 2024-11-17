using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
public class EarthStatusManager : MonoBehaviour //人口変化を担う
{
    public float increment;    //EarthManagerからゲットした文明度により変化する公比。

    private int _elapsedTime; //人口の計算に使用

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
        Observable.Interval(TimeSpan.FromSeconds(1)) //UniRxはスタートで呼び出してあげれば勝手に動く
                         .Subscribe(_ =>
                            {
                                increment = 1.00001f;
                                IncreasePopulation();

                                IncreaseLevelofSociety();

                            }).AddTo(this); //このスクリプトをアタッチしたオブジェクトが消えたら止まるよコード
    }

    // Update is called once per frame
    private void IncreasePopulation()
    {
        _elapsedTime++;
        int population = (int)Mathf.Floor(1 * (1 - Mathf.Pow(increment, _elapsedTime)) / (1 - increment));
        EarthManager.Instance.EarthInfo.SetPoputaion(population);//unityが扱えるのは21億まで
        Debug.Log(population);
    }

    private void IncreaseLevelofSociety()
    {
        //enumのsocietyとの混同を防ぐためにcivilisationを使用する
        int population = EarthManager.Instance.EarthInfo.Population;
        Society society = EarthManager.Instance.EarthInfo.Society; //現在の進歩度Societyを一時変数societyに代入

        if (population > _societyChangeThreshold[society])
        {
            //societyをenumデフォルトのシリアルナンバーに直してあげて足す。それをobject型に変更してあげてSociety型に変更してあげる ToSocietyとかはできないので、超汎用型のobjectにする機能をはさんでいる。　
            society = (Society)Enum.ToObject(typeof(Society), (int)society + 1);
            EarthManager.Instance.EarthInfo.SetSociety(society);
        }
        Debug.Log(society);
    }
}
