using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AdjustVolume : MonoBehaviour
{
    const string MasterGroup = "MasterVolume";
    const string SoundGroup = "SoundVolume";
    const string BackgroundMusicGroup = "BackgroundMusicVolume";

    [SerializeField] private AudioMixerGroup _audioMixerGroup;

    [SerializeField] private Slider _totalVolume;
    [SerializeField] private Slider _buttonVolume;
    [SerializeField] private Slider _backgroundMusicVolume;

    [SerializeField] private Button _buttonAllSoundValue;

    private int _minimumVolumeLevel = -80;
    private bool _isPlaying = true;

    public void ChangeVolumeBackgroundMusic()
    {
        _audioMixerGroup.audioMixer.SetFloat(BackgroundMusicGroup, Mathf.Lerp(_minimumVolumeLevel, 0, _backgroundMusicVolume.value));
    }

    public void ChangeVolumeSoundBaton()
    {
        _audioMixerGroup.audioMixer.SetFloat(SoundGroup, Mathf.Lerp(_minimumVolumeLevel, 0, _buttonVolume.value));
    }

    public void ChangeVolumeAllSound()
    {
        _audioMixerGroup.audioMixer.SetFloat(MasterGroup, Mathf.Lerp(_minimumVolumeLevel, 0, _totalVolume.value));
    }

    public void TornAllSound()
    {
        if (_isPlaying == true)
        {
            _audioMixerGroup.audioMixer.SetFloat(MasterGroup, _minimumVolumeLevel);
            _isPlaying = false;
        }
        else
        {
            ChangeVolumeAllSound();
            _isPlaying = true;
        }
    }
}
