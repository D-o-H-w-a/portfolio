using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    static PlayerSound instance;

    public static PlayerSound Instance => instance;

    private AudioClip _audioClip;
    private AudioSource _audioSource;
    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioClip = GetComponent<AudioClip>();
    }

    public AudioClip audioClip
    {
        get
        {
            return _audioClip;
        }

        set
        {
            _audioClip = value;
        }
    }

    public AudioSource audioSource
    {
        get
        {
            return _audioSource;
        }

        set
        {
            _audioSource = value;
        }
    }

    // Update is called once per frame
    public void PlaySound(string Type)
    {
        switch (Type)
        {
            case "Jump":
                _audioClip = (AudioClip)Instantiate(Resources.Load("AudioClip/Jump"));
                break;
            case "Hit":
                _audioClip = (AudioClip)Instantiate(Resources.Load("AudioClip/Hit"));
                break;
        }
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }
}
