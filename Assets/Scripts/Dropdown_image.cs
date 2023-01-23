using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dropdown_image : MonoBehaviour
{
    public Image oldimg;
    public Sprite[] newimg;
    public Dropdown myDD;

    public void ImageChange(Dropdown myDD){
        oldimg.sprite = newimg[myDD.value];
    }
}
