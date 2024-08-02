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

    private string emptyMessage = "Empty";   //�C���v�b�g�t�B�[���h�ɓ��͂���Ă��Ȃ��Ƃ�

    private int createStepNum = 0;�@�@�@�@�@ //�����ځ@ 

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
                //add:����������
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
                //������
               
            }
            createStepNum++;
        }
    }
}