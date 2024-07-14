using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonDisappear : MonoBehaviour
{
    [SerializeField]
    float disappearingSpeed; //“§–¾‚É‚È‚é‘¬“x

    [SerializeField]
    Button button;

    float albedo;
    private void Start()
    {
        albedo = button.GetComponent<Image>().color.a;
    }

    public void OnClick()//‰Ÿ‚³‚ê‚½ƒ{ƒ^ƒ“‚ð‚¾‚ñ‚¾‚ñ“§–¾‚É‚·‚é
    {
        StartCoroutine(Disapper());
    }

    IEnumerator Disapper()
    {
        while (albedo > 0f)
        {
            albedo -= disappearingSpeed;
            button.GetComponent<Image>().color = new Color(button.GetComponent<Image>().color.r, button.GetComponent<Image>().color.g, button.GetComponent<Image>().color.b, albedo);
            yield return null;
        }
    }
}