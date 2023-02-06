using TMPro;
using UnityEngine;

public class Lollipops : MonoBehaviour
{
    private GameObject myTextObject;
    private TextMeshProUGUI myText;

    public static Lollipops Instance;
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        myTextObject = GameObject.FindGameObjectWithTag("LollipopTextBox");
        myText = myTextObject.GetComponent<TextMeshProUGUI>();
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
