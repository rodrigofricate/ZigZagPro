using Assets.Script;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanOptions : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropGraphicQuality;
    [SerializeField] Slider sldSound;
    [SerializeField] Text txtSoundVal;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void EnableCanva()
    {
        gameObject.SetActive(true);
        sldSound.value = StaticOptions.MasterVolume;
        dropGraphicQuality.value = StaticOptions.GraphicQuality;

    }
    public void DisableCanva() { gameObject.SetActive(false); }
    public void RefreshVolume(float volume) { 
        StaticOptions.MasterVolume = volume;
        txtSoundVal.text = (StaticOptions.MasterVolume*100).ToString("00")+"%";
    }
    public void RefreshGraphics(int graphicValue)
    {
        StaticOptions.GraphicQuality = graphicValue;
        QualitySettings.SetQualityLevel(StaticOptions.GraphicQuality);
    }
    public void QuitGame() { Application.Quit(); }

}
