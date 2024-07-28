// Hierarchy��Flowchart�I�u�W�F�N�g��I�����AInput�R���|�[�l���g��ǉ�
// Flowchart��Variables�^�u�ŁA�V����String�ϐ� playerName ���쐬
// Input�R���|�[�l���g�̐ݒ�
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class NameInputHandler : MonoBehaviour
{
    public InputField nameInputField;         // InputField�R���|�[�l���g���Q��
    public Flowchart flowchart;               // Flowchart�R���|�[�l���g���Q��
    public string enteredMessage = "Entered"; //���O�����͂���Ă���
    public string emptyMessage = "Empty";     //���O�����͂���ĂȂ��Ƃ�
    void Start()
    {
        // InputField��On End Edit�C�x���g�Ƀ��X�i�[��ǉ�
        nameInputField.onEndEdit.AddListener(OnNameInputEnd);
    }
    void OnNameInputEnd(string inputName)
    {
        if (string.IsNullOrEmpty(inputName))
        {
            flowchart.SendFungusMessage(emptyMessage);
            //�������O���󂾂�����Z�b�g���Ă��Ӗ��Ȃ�����else���ŏ���
            flowchart.SetBooleanVariable("isEmptyName", true);
        }
        else
        {
            flowchart.SetStringVariable("nameInput", inputName);
            flowchart.SendFungusMessage(enteredMessage);
            flowchart.SetBooleanVariable("isEnteredName", true);
            // Fungus�̕ϐ� playerName �Ƀ��[�U�[���͂�ݒ�
            
        }
        // Fungus�̕ϐ��������肽���Ƃ��� flowchart.SethogehogeVariable("unity��Őݒ肵���ϐ���", ����)�Ŏ�������
    }
}