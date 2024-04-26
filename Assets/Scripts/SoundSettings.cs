using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _sound1;
    [SerializeField] private AudioSource _sound2;
    [SerializeField] private AudioSource _sound3;

    [SerializeField] private Slider _totalVolume;
    [SerializeField] private Slider _buttonVolume;
    [SerializeField] private Slider _backgroundMusicVolume;

    private bool _isPlaying = true;

    private void Awake()
    {
        SetCurrentSound();
    }

    public void TurnBackgroundSound()
    {
        if (_isPlaying)
        {
            _backgroundMusic.volume = 0;
            _sound1.volume = 0;
            _sound2.volume = 0;
            _sound3.volume = 0;

            _isPlaying = false;
        }
        else
        {
            SetCurrentSound();

            _isPlaying = true;
        }
    }

    private void SetCurrentSound()
    {
        float currentVolumeBackgroundMusic = _totalVolume.value * _backgroundMusicVolume.value;
        _backgroundMusic.volume = currentVolumeBackgroundMusic;

        float currentSoundVolume = _buttonVolume.value * _totalVolume.value;
        _sound1.volume = currentSoundVolume;
        _sound2.volume = currentSoundVolume;
        _sound3.volume = currentSoundVolume;
    }
}
