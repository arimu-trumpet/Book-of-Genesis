// Hierarchy��Flowchart�I�u�W�F�N�g��I�����AInput�R���|�[�l���g��ǉ�
// Flowchart��Variables�^�u�ŁA�V����String�ϐ� playerName ���쐬
// Input�R���|�[�l���g�̐ݒ�
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class LightInputHandler : MonoBehaviour
{
    [SerializeField]
     InputField lightInputField;                         // InputField�R���|�[�l���g���Q��
    [SerializeField]
     Flowchart lightFlowchart;                           // Flowchart�R���|�[�l���g���Q��

    private string enteredMessage = "LightEntered";      //���O�����͂���Ă���
    private string emptyMessage = "LightEmpty";          //���O�����͂���ĂȂ��Ƃ�
    void Start()
    {
        // InputField��On End Edit�C�x���g�Ƀ��X�i�[��ǉ�
        lightInputField.onEndEdit.AddListener(OnLightInputEnd);
    }
    void OnLightInputEnd(string inputName)
    {
        if (string.IsNullOrEmpty(inputName))
        {
            lightFlowchart.SendFungusMessage(emptyMessage);
            //�������O���󂾂�����Z�b�g���Ă��Ӗ��Ȃ�����else���ŏ���
            lightFlowchart.SetBooleanVariable("isEmptyName", true);
        }
        else
        {
            lightFlowchart.SetStringVariable("Light", inputName);
            lightFlowchart.SendFungusMessage(enteredMessage);
            lightFlowchart.SetBooleanVariable("isEnteredName", true);
            // Fungus�̕ϐ� playerName �Ƀ��[�U�[���͂�ݒ�
            
        }
        // Fungus�̕ϐ��������肽���Ƃ��� flowchart.SethogehogeVariable("unity��Őݒ肵���ϐ���", ����)�Ŏ�������
    }
}