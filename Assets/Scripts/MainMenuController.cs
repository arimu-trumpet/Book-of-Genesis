using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject EarthButtonPrefab;

    public GameObject EarthButtonParent;
    // Start is called before the first frame update
    void Start()
    {
        var earthList = EarthManager.Instance.EarthInfoList;

        foreach(var Earth in earthList)
        {
            var earthObject = Instantiate(EarthButtonPrefab, EarthButtonParent.transform); //セットペアレントもしてる！

            earthObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                 EarthManager.Instance.CurrentEarthInfo = Earth;

                 SceneManager.LoadScene("World");
            });
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
