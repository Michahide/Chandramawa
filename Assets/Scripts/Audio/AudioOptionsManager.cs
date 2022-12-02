using UnityEngine;
using TMPro;

public class AudioOptionsManager : MonoBehaviour
{
    public static float musicVolume { get; private set; }
    // public static float soundEffectsVolume { get; private set; }

    [SerializeField] private TextMeshProUGUI musicSliderText;
    // [SerializeField] private TextMeshProUGUI soundEffectsSliderText;

    public void OnMusicSliderValueChange(float value)
    {
        musicVolume = value;
        
        musicSliderText.text = ((int)(value * 100)).ToString();
        AudioManager.Instance.UpdateMixerVolume();
    }
    void Update(){
        musicSliderText = GameObject.Find("MusicValue").GetComponent<TextMeshProUGUI>();
    }

    // public void OnSoundEffectsSliderValueChange(float value)
    // {
    //     soundEffectsVolume = value;

    //     soundEffectsSliderText.text = ((int)(value * 100)).ToString();
    //     AudioManager.Instance.UpdateMixerVolume();
    // }
}