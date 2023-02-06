using System.Collections;
using UnityEngine;

public class Healthbar : MonoBehaviour {

    public Slider slider;
    public int SetHealth(int health) 
    {
        slider.maxValue = health;
        slider.value = health;
    }
    
    public int SetHealth(int health)
    {
        slider.value = health;
    }
}