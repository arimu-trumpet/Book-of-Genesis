using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

public class CreateInputHandler : MonoBehaviour
{
    [SerializeField]
    InputField inputField;

    [SerializeField]
    Flowchart[] flowchart;

    private string emptyMessage = "Empty";   //インプットフィールドに入力されていないとき

    private int createStepNum = 0;　　　　　 //0～2:一日目　3:二日目　 

    void Start()
    {
        inputField.onEndEdit.AddListener(OnEndEdit);
    }
    void OnEndEdit(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            Debug.Log("null string");
            if (createStepNum <= 2)
            {
                flowchart[0].SendFungusMessage(emptyMessage);
            }
            if (createStepNum == 3)
            {
                flowchart[1].SendFungusMessage(emptyMessage);
            }
        }
        else
        {
            if (createStepNum == 0)   //一日目
            {
                flowchart[0].SetStringVariable("Light", input);
                flowchart[0].SendFungusMessage("LightEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";
                //add:文字数制限
            }
            if (createStepNum == 1)   //一日目
            {
                flowchart[0].SetStringVariable("Day", input);
                flowchart[0].SendFungusMessage("DayEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";
            }
            if (createStepNum == 2)   //一日目
            {
                flowchart[0].SetStringVariable("Night", input);
                flowchart[0].SendFungusMessage("NightEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";

            }
            if (createStepNum == 3)   //二日目
            {
                flowchart[1].SetStringVariable("Sky", input);
                flowchart[1].SendFungusMessage("SkyEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";

            }
            if (createStepNum == 4)
            {


            }
            if (createStepNum == 5)
            {


            }
            if (createStepNum == 6)
            {


            }
            createStepNum++;
        }
    }
}