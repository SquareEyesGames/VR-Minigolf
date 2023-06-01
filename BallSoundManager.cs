using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip _puttSound;
    [SerializeField] private AudioClip _holeSound;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayPuttSound()
    {
        _audioSource.clip = _puttSound;
        _audioSource.Play();
    }

    public void PlayHoleSound()
    {
        _audioSource.clip = _holeSound;
        _audioSource.Play();
    }
}
