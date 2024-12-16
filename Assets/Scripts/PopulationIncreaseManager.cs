using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
public class PopulationIncreaseManager : MonoBehaviour //人口変化を担う
{
    public float increment;    //文明度(EarthManagerからゲットした)により変化する公比。

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
        _elapsedTime++; //プレイヤーがスマホを閉じてた時の計算用　保存必須！
        if (EarthManager.Instance.CurrentEarthInfo.Population == 0) //初期値を与える
        {
            int population = 2; //アダムとイブ
            EarthManager.Instance.CurrentEarthInfo.SetPoputaion(population);//unityが扱えるのは21億まで
             
        }
        else if(EarthManager.Instance.CurrentEarthInfo.Population != 0) //人口停滞バグ防止
        {
            if((int)Mathf.Floor(((increment / 100)) * EarthManager.Instance.CurrentEarthInfo.Population) <= 1)
            {
                int population = EarthManager.Instance.CurrentEarthInfo.Population + 1;

                EarthManager.Instance.CurrentEarthInfo.SetPoputaion(population);//unityが扱えるのは21億まで
            }
            if((int)Mathf.Floor(((increment / 100)) * EarthManager.Instance.CurrentEarthInfo.Population) > 1) //増加率をかけて増加分が1を超える時計算式を切り替える
            {
                int population = (int)Mathf.Floor((1 + (increment / 100)) * EarthManager.Instance.CurrentEarthInfo.Population); //計算式引用 : https://dmpl.doshisha.ac.jp/wp-content/uploads/2015/06/simulation_and_model.pdf 

                EarthManager.Instance.CurrentEarthInfo.SetPoputaion(population);//unityが扱えるのは21億まで
            }
        }
    }

    private void IncreaseLevelofSociety()
    {
        //enumのsocietyとの混同を防ぐためにcivilisationを使用する
        int population = EarthManager.Instance.CurrentEarthInfo.Population;
        Society society = EarthManager.Instance.CurrentEarthInfo.Society; //現在の進歩度Societyを一時変数societyに代入

        if (population > _societyChangeThreshold[society])
        {
            //societyをenumデフォルトのシリアルナンバーに直してあげて足す。
            //それをobject型に変更してあげてSociety型に変更してあげる ToSocietyとかはできないので、汎用型のobjectにする機能をはさんでいる。　
            society = (Society)Enum.ToObject(typeof(Society), (int)society + 1);
            EarthManager.Instance.CurrentEarthInfo.SetSociety(society);
        }
        Debug.Log(society);
    }
}
