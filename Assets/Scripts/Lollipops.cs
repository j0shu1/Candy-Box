using TMPro;
using UnityEngine;

public class Lollipops : MonoBehaviour
{
    private GameObject myTextObject;
    private TextMeshProUGUI myText;

    private static Lollipops _instance;
    public static Lollipops Instance { get { return _instance; } }
    private void Start()
    {
        myTextObject = GameObject.FindGameObjectWithTag("LollipopTextBox");
        myText = myTextObject.GetComponent<TextMeshProUGUI>();        
    }
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else
        {
            _instance = this;
        }
    }
    private int lollipops = 0;
    public int GetLollipops()
    {
        return lollipops;
    }
    public void CollectLollipop()
    {
        lollipops++;
        myText.text = "Collected " + lollipops + " lollipops";
    }
}
