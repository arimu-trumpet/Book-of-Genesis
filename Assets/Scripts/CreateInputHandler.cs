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

    private string emptyMessage = "Empty";   //�C���v�b�g�t�B�[���h�ɓ��͂���Ă��Ȃ��Ƃ�

    private int createStepNum = 0;�@�@�@�@�@ //0�`2:����ځ@3:����ځ@ 

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
            //��:flowchart[n-1����]

            if (createStepNum == 0)   //�����
            {
                flowchart[0].SetStringVariable("Light", input);
                flowchart[0].SendFungusMessage("LightEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";
                //add:����������
            }
            if (createStepNum == 1)   //�����
            {
                flowchart[0].SetStringVariable("Day", input);
                flowchart[0].SendFungusMessage("DayEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";
            }
            if (createStepNum == 2)   //�����
            {
                flowchart[0].SetStringVariable("Night", input);
                flowchart[0].SendFungusMessage("NightEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";

            }
            if (createStepNum == 3)   //�����
            {
                flowchart[1].SetStringVariable("Heaven", input);
                flowchart[1].SendFungusMessage("HeavenEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";

            }
            if (createStepNum == 4)   //�O����
            {
                flowchart[2].SetStringVariable("Land", input);
                flowchart[2].SendFungusMessage("LandEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";

            }
            if (createStepNum == 5)   //�O����
            {
                flowchart[2].SetStringVariable("Sea", input);
                flowchart[2].SendFungusMessage("SeaEntered");
                InputField form = inputField.GetComponent<InputField>();
                form.text = "";

            }
            if (createStepNum == 6)
            {


            }
            createStepNum++;
        }
    }
}