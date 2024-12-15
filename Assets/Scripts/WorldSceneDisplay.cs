using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WorldSceneDisplay : MonoBehaviour
{
    public TextMeshProUGUI populationText;

    public TextMeshProUGUI societyText;

    private string _society; //enum�^����ϊ��������̎󂯎M

    void Update()
    {
        populationText.text = "���񂱂�:" + EarthManager.Instance.CurrentEarthInfo.Population;

        societyText.text = "���Ⴉ��:" + ConvertEnumToString(EarthManager.Instance.CurrentEarthInfo.Society);
    }

    private string ConvertEnumToString(Society i)
    {
        if (EarthManager.Instance.CurrentEarthInfo.Society == Society.HUNTERGATHERER)
        {
            _society = "�����傤";
        }
        if (EarthManager.Instance.CurrentEarthInfo.Society == Society.AGRICULTURAL)
        {
            _society = "�̂����傤";
        }
        if (EarthManager.Instance.CurrentEarthInfo.Society == Society.INDUSTRIAL)
        {
            _society = "���񂬂傤";
        }
        if (EarthManager.Instance.CurrentEarthInfo.Society == Society.INFORMATION)
        {
            _society = "���傤�ق�";
        }
        if (EarthManager.Instance.CurrentEarthInfo.Society == Society.SUPERSMART)
        {
            _society = "���܁[��";
        }

        return _society;
    }
}
