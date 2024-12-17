using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public void ToHome()
    {
        SceneManager.LoadScene("Home");
    }
    public void ToCreation()
    {
        SceneManager.LoadScene("Creation");
    }
    public void ToWorld()
    {
        SceneManager.LoadScene("World");//XXX:七日目終了後自動でロードすると謎のデータがない地球に飛ばされる　どうにかプレイヤが作った地球に飛べるように
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
