using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CollectLollipop: MonoBehaviour
{
    private Lollipops lollipops;
    private GameObject thisLollipop;
    private void Awake()
    {
        lollipops = Lollipops.Instance;
    }

    public void Collect()
    {
        lollipops.CollectLollipop();

        thisLollipop = GameObject.FindGameObjectWithTag("Lollipop");
        Destroy(thisLollipop);
    }
}
