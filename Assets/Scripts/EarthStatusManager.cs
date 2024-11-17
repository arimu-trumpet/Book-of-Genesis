using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
public class PopulationIncreaseManager : MonoBehaviour //人口変化を担う
{
    [HideInInspector]
    public float Population;   //EarthManagerにゲットされて文明度の決定に使用

    public float increment;    //EarthManagerからゲットした文明度により変化する公比。

    private int elapsedTime; //人口の計算に使用
    // Start is called before the first frame update
    void Start()
    {
        increment = 1.00001f;

        Observable.Interval(TimeSpan.FromSeconds(1)) //UniRxはスタートで呼び出してあげれば勝手に動く
            .Subscribe(_ =>
            {
                elapsedTime ++;
                Population = Mathf.Floor(1 * (1 - Mathf.Pow(increment, elapsedTime)) / (1 - increment));
                Debug.Log(Population);

            }).AddTo(this); //このスクリプトをアタッチしたオブジェクトが消えたら止まるよコード

    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
