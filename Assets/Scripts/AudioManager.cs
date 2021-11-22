using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioManager instance;
    public static AudioManager Instance => instance;

    private AudioSource _audioSource;
    public AudioClip[] audioClips;

    private int audioLength = 10;

    public AudioSource audioSource
    {
        get { return _audioSource; }
        set { _audioSource = value; }
    }
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips[Random.Range(0,audioClips.Length)];
        audioSource.Play();
    }
}
