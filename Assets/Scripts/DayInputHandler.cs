// Hierarchy��Flowchart�I�u�W�F�N�g��I�����AInput�R���|�[�l���g��ǉ�
// Flowchart��Variables�^�u�ŁA�V����String�ϐ� playerName ���쐬
// Input�R���|�[�l���g�̐ݒ�
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class DayInputHandler : MonoBehaviour
{
    [SerializeField]
     InputField dayInputField;                       // InputField�R���|�[�l���g���Q��
    [SerializeField]
     Flowchart dayFlowchart;                         // Flowchart�R���|�[�l���g���Q��

    private string enteredMessage = "DayEntered";    //���O�����͂���Ă���
    private string emptyMessage = "DayEmpty";        //���O�����͂���ĂȂ��Ƃ�
    void Start()
    {
        // InputField��On End Edit�C�x���g�Ƀ��X�i�[��ǉ�
        dayInputField.onEndEdit.AddListener(OnDayInputEnd);
    }
    void OnDayInputEnd(string inputName)
    {
        if (string.IsNullOrEmpty(inputName))
        {
            dayFlowchart.SendFungusMessage(emptyMessage);
            //�������O���󂾂�����Z�b�g���Ă��Ӗ��Ȃ�����else���ŏ���
            dayFlowchart.SetBooleanVariable("isEmptyName", true);
        }
        else
        {
            dayFlowchart.SetStringVariable("Day", inputName);
            dayFlowchart.SendFungusMessage(enteredMessage);
            dayFlowchart.SetBooleanVariable("isEnteredName", true);
            // Fungus�̕ϐ� playerName �Ƀ��[�U�[���͂�ݒ�

        }
        // Fungus�̕ϐ��������肽���Ƃ��� flowchart.SethogehogeVariable("unity��Őݒ肵���ϐ���", ����)�Ŏ�������
    }
}