using UnityEngine;

public class CollectLollipop: MonoBehaviour
{
    private Lollipops lollipops = Lollipops.Instance;
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
