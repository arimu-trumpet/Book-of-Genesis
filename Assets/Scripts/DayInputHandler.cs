// Hierarchy��Flowchart�I�u�W�F�N�g��I�����AInput�R���|�[�l���g��ǉ�
// Flowchart��Variables�^�u�ŁA�V����String�ϐ� playerName ���쐬
// Input�R���|�[�l���g�̐ݒ�
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class DayInputHandler : MonoBehaviour
{
    [SerializeField]
     InputField inputField;                       // InputField�R���|�[�l���g���Q��
    [SerializeField]
     Flowchart flowchart;                         // Flowchart�R���|�[�l���g���Q��

    private string enteredMessage = "DayEntered";    //���O�����͂���Ă���
    private string emptyMessage = "DayEmpty";        //���O�����͂���ĂȂ��Ƃ�
    void Start()
    {
        // InputField��On End Edit�C�x���g�Ƀ��X�i�[��ǉ�
        inputField.onEndEdit.AddListener(OnDayInputEnd);
    }

    void OnDayInputEnd(string inputName)
    {
        if (string.IsNullOrEmpty(inputName))
        {
            flowchart.SendFungusMessage(emptyMessage);
            //�������O���󂾂�����Z�b�g���Ă��Ӗ��Ȃ�����else���ŏ���
        }
        else
        {
            flowchart.SetStringVariable("Day", inputName);
            flowchart.SendFungusMessage(enteredMessage);
            // Fungus�̕ϐ� playerName �Ƀ��[�U�[���͂�ݒ�

        }
        // Fungus�̕ϐ��������肽���Ƃ��� flowchart.SethogehogeVariable("unity��Őݒ肵���ϐ���", ����)�Ŏ�������
    }
}