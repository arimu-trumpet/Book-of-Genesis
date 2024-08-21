using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonDisappear : MonoBehaviour
{
    [SerializeField]
    float disappearingSpeed; //�����ɂȂ鑬�x

    [SerializeField]
    Button button;

    TextMeshProUGUI buttonText;

    float albedo;
    private void Start()
    {
        albedo = button.GetComponent<Image>().color.a;

        buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnClick()//�����ꂽ�{�^�������񂾂񓧖��ɂ���
    {
        button.interactable = false; //�����ڂ͎c���Ĕ���𖳂���
        StartCoroutine(Disapper());
    }

    IEnumerator Disapper()
    {
        while (albedo > 0f)
        {
            albedo -= disappearingSpeed;
            button.GetComponent<Image>().color = new Color(button.GetComponent<Image>().color.r, button.GetComponent<Image>().color.g, button.GetComponent<Image>().color.b, albedo);

            if (buttonText != null)
            {
                Color textColor = buttonText.color;
                buttonText.color = new Color(textColor.r, textColor.g, textColor.b, albedo);
            }
            yield return null;
        }
    }
}