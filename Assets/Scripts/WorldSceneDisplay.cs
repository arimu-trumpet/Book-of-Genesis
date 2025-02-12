using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WorldSceneDisplay : MonoBehaviour
{
    public TextMeshProUGUI populationText;

    public TextMeshProUGUI societyText;

    private string _society; //enum型から変換した時の受け皿

    void Update()
    {
        populationText.text = "じんこう:" + EarthManager.Instance.CurrentEarthInfo.Population;

        societyText.text = "しゃかい:" + ConvertEnumToString(EarthManager.Instance.CurrentEarthInfo.Society);
    }

    private string ConvertEnumToString(Society i)
    {
        if (EarthManager.Instance.CurrentEarthInfo.Society == Society.HUNTERGATHERER)
        {
            _society = "しゅりょう";
        }
        if (EarthManager.Instance.CurrentEarthInfo.Society == Society.AGRICULTURAL)
        {
            _society = "のうぎょう";
        }
        if (EarthManager.Instance.CurrentEarthInfo.Society == Society.INDUSTRIAL)
        {
            _society = "さんぎょう";
        }
        if (EarthManager.Instance.CurrentEarthInfo.Society == Society.INFORMATION)
        {
            _society = "じょうほう";
        }
        if (EarthManager.Instance.CurrentEarthInfo.Society == Society.SUPERSMART)
        {
            _society = "すまーと";
        }

        return _society;
    }
}
