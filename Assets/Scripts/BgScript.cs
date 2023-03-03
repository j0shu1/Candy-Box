using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BgScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static BgScript BgInstance;
    public AudioSource Audio; //Background audio source
    public AudioClip[] MusicClips; //array of music
    //item 0: Main ; item 1: Fight

    private void Awake()
    {
        if(BgInstance != null && BgInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        BgInstance = this;
        DontDestroyOnLoad(this);
    }
}
