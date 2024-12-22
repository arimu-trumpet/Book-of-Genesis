using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public void ToHome()
    {
        SceneManager.LoadScene("Home");//To World の代用
    }
    public void ToCreation()
    {
        SceneManager.LoadScene("Creation");
    }
    public void ToWorld()
    {
       //ダイレクトで送るのは諦めてホームに送るのもあり　exチュートリアル案内の天使みたいなやつに「じゃあホームに戻って作った地球を見てみよう」とか言わせる

        //SceneManager.LoadScene("World"); XXX:七日目終了後自動でロードすると謎のデータがない地球に飛ばされる　どうにかプレイヤが作った地球に飛べるように
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ToShop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void ToGacha()
    {
        SceneManager.LoadScene("Gacha");
    }
}
