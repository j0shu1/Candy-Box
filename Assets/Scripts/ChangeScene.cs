using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void MoveToScene(int sceneID){
        //Switch Scene
        SceneManager.LoadScene(sceneID);
        //Make click sound when switching scenes
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click);

        //Switch the background music
        AudioSource source = new AudioSource(); 
        if(BgScript.BgInstance.Audio.clip == BgScript.BgInstance.MusicClips[0]) //detects if current music is wrong
        {
            if(sceneID == 5) //if the scene is switched to attack scene
            {            //stop music, set new music, play music
                BgScript.BgInstance.Audio.Stop(); 
                BgScript.BgInstance.Audio.clip = BgScript.BgInstance.MusicClips[1];
                BgScript.BgInstance.Audio.Play(0);
            }
        }
        if(BgScript.BgInstance.Audio.clip == BgScript.BgInstance.MusicClips[1]) //detects if current music is wrong
        {
            if(sceneID != 5)//if the scene is switched from attack scene
            {           //stop music, set new music, play music
                BgScript.BgInstance.Audio.Stop();
                BgScript.BgInstance.Audio.clip = BgScript.BgInstance.MusicClips[0];
                BgScript.BgInstance.Audio.Play(0);
            }
        }
    }
}
