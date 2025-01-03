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

    private int createStepNum = 0;      //0〜2:一日目　3:二日目　 

    private Earth _draftEarth = new Earth(); //地球の下書き

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
            //注:flowchart[n-1日目] 七日目は遠すぎるので例外　七日目 : flowchart[3]

            if (createStepNum == 0)   //一日目
            {
                _draftEarth.LightName = input;
                flowchart[0].SetStringVariable("Light", input);
                flowchart[0].SendFungusMessage("LightEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";
                //ADD:文字数制限
            }
            if (createStepNum == 1)   //一日目
            {
                _draftEarth.DayName = input;
                flowchart[0].SetStringVariable("Day", input);
                flowchart[0].SendFungusMessage("DayEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";
            }
            if (createStepNum == 2)   //一日目
            {
                _draftEarth.NightName = input;
                flowchart[0].SetStringVariable("Night", input);
                flowchart[0].SendFungusMessage("NightEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";

            }
            if (createStepNum == 3)   //二日目
            {
                _draftEarth.HeavenName = input;
                flowchart[1].SetStringVariable("Heaven", input);
                flowchart[1].SendFungusMessage("HeavenEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";

            }
            if (createStepNum == 4)   //三日目
            {
                _draftEarth.LandName = input;
                flowchart[2].SetStringVariable("Land", input);
                flowchart[2].SendFungusMessage("LandEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";

            }
            if (createStepNum == 5)   //三日目
            {
                _draftEarth.SeaName = input;
                flowchart[2].SetStringVariable("Sea", input);
                flowchart[2].SendFungusMessage("SeaEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";

            }
            if(createStepNum == 6)   //七日目
            {
                _draftEarth.WorldName = input;
                flowchart[3].SetStringVariable("World", input);
                flowchart[3].SendFungusMessage("WorldEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";

                EarthManager.Instance.AddEarth(_draftEarth);
            }
            createStepNum++;
        }
    }
}