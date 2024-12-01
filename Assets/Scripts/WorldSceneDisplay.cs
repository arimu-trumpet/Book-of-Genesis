using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WorldSceneDisplay : MonoBehaviour
{
    public TextMeshProUGUI populationText;

    public TextMeshProUGUI societyText;

    private string _society; //enumå^Ç©ÇÁïœä∑ÇµÇΩéûÇÃéÛÇØéM

    void Update()
    {
        populationText.text = "Ç∂ÇÒÇ±Ç§:" + EarthManager.Instance.EarthInfo.Population;

        societyText.text = "ÇµÇ·Ç©Ç¢:" + ConvertEnumToString(EarthManager.Instance.EarthInfo.Society);
    }

    private string ConvertEnumToString(Society i)
    {
        if (EarthManager.Instance.EarthInfo.Society == Society.HUNTERGATHERER)
        {
            _society = "ÇµÇ„ÇËÇÂÇ§";
        }
        if (EarthManager.Instance.EarthInfo.Society == Society.AGRICULTURAL)
        {
            _society = "ÇÃÇ§Ç¨ÇÂÇ§";
        }
        if (EarthManager.Instance.EarthInfo.Society == Society.INDUSTRIAL)
        {
            _society = "Ç≥ÇÒÇ¨ÇÂÇ§";
        }
        if (EarthManager.Instance.EarthInfo.Society == Society.INFORMATION)
        {
            _society = "Ç∂ÇÂÇ§ÇŸÇ§";
        }
        if (EarthManager.Instance.EarthInfo.Society == Society.SUPERSMART)
        {
            _society = "Ç∑Ç‹Å[Ç∆";
        }

        return _society;
    }
}
