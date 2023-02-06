using System.Collections;
using System.Collections.geleric;
using UnityEngine;

public class Untitled-1 : MonoBehaviour {

    public Slider slider;
    private void SetHealth(int health) 
    {
        slider.maxValue = health;
        slider.value = health;
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}