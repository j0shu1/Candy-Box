using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip Click; //swap scene
    public AudioClip Buy; //buy something
    public AudioClip Attack; //attack something
    public AudioClip Die; //die to something
    public AudioClip Eat; //eat something

    public static SfxManager sfxInstance;

    private void Awake()
    {
        if(sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
