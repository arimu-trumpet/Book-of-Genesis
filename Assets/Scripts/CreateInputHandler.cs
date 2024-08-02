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
    Flowchart flowchart;

    private string emptyMessage = "Empty";   //インプットフィールドに入力されていないとき

    private int createStepNum = 0;　　　　　 //何日目　 

    void Start()
    {
        inputField.onEndEdit.AddListener(OnEndEdit);
    }
    void OnEndEdit(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            Debug.Log("null string");
            flowchart.SendFungusMessage(emptyMessage);
        }
        else
        {
            if (createStepNum == 0)
            {
                flowchart.SetStringVariable("Light", input);
                flowchart.SendFungusMessage("LightEntered");
                InputField form = inputField.GetComponent<InputField>();   
                form.text = "";
                //add:文字数制限
            }
            if (createStepNum == 1)
            {
                flowchart.SetStringVariable("Day", input);
                flowchart.SendFungusMessage("DayEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";
            }
            if (createStepNum == 2)
            {


            }
            if (createStepNum == 3)
            {


            }
            if (createStepNum == 4)
            {


            }
            if (createStepNum == 5)
            {


            }
            if (createStepNum == 6)
            {
                //七日目
               
            }
            createStepNum++;
        }
    }
}