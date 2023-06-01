using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private AudioSource _gameMusic;

    void Start()
    {
        _volumeSlider.value = _gameMusic.volume;

        _volumeSlider.value = 0.5f;

        _volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    public void ChangeVolume(float volume)
    {
        _gameMusic.volume = volume;
    }
}
