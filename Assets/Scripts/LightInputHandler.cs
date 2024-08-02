// Hierarchy��Flowchart�I�u�W�F�N�g��I�����AInput�R���|�[�l���g��ǉ�
// Flowchart��Variables�^�u�ŁA�V����String�ϐ� playerName ���쐬
// Input�R���|�[�l���g�̐ݒ�
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class LightInputHandler : MonoBehaviour
{
    [SerializeField]
     InputField inputField;                              // InputField�R���|�[�l���g���Q��
    [SerializeField]
     Flowchart flowchart;                                // Flowchart�R���|�[�l���g���Q��

    private string enteredMessage = "LightEntered";      //���O�����͂���Ă���
    private string emptyMessage = "Empty";               //���O�����͂���ĂȂ��Ƃ�
    void Start()
    {
        // InputField��On End Edit�C�x���g�Ƀ��X�i�[��ǉ�
        inputField.onEndEdit.AddListener(OnLightInputEnd);
    }

    void OnLightInputEnd(string inputName)
    {
        if (string.IsNullOrEmpty(inputName))
        {
            flowchart.SendFungusMessage(emptyMessage);
            //�������O���󂾂�����Z�b�g���Ă��Ӗ��Ȃ�����else���ŏ���
        }
        else
        {
            flowchart.SetStringVariable("Light", inputName);
            flowchart.SendFungusMessage(enteredMessage);
            // Fungus�̕ϐ� playerName �Ƀ��[�U�[���͂�ݒ�   
        }
        // Fungus�̕ϐ��������肽���Ƃ��� flowchart.SethogehogeVariable("unity��Őݒ肵���ϐ���", ����)�Ŏ�������
    }
}