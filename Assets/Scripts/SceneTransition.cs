using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTransition : MonoBehaviour
{
    public void ToHome()
    {
        SceneManager.LoadScene("Home");//To World �̑�p
    }
    public void ToCreation()
    {
        SceneManager.LoadScene("Creation");
    }
    public void ToWorld()
    {
       //�_�C���N�g�ő���̂͒��߂ăz�[���ɑ���̂�����@ex�`���[�g���A���ē��̓V�g�݂����Ȃ�Ɂu���Ⴀ�z�[���ɖ߂��č�����n�������Ă݂悤�v�Ƃ����킹��

        //SceneManager.LoadScene("World"); XXX:�����ڏI���㎩���Ń��[�h����Ɠ�̃f�[�^���Ȃ��n���ɔ�΂����@�ǂ��ɂ��v���C����������n���ɔ�ׂ�悤��
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ToShop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void ToGacha()
    {
        SceneManager.LoadScene("Gacha");
    }
}
