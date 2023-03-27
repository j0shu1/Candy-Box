using TMPro;
using UnityEngine;
public class HealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int gradient;
    private GameManager gameManager;
    public TextMeshProUGUI textbox;

   
    public int PlayerHealthBar;



 
     // Use t$$anonymous$$s for initialization
     
     // Update is called once per frame


    void Start()
    {
        currentHealth = maxHealth;
        gameManager = GameManager.Instance;
    }


    void Update()
    {
        int PlayerHealthNow = gameManager.GetHealth();
        textbox.text = ("Health: " + PlayerHealthNow.ToString() + "/"+ maxHealth.ToString());
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(1);
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;


    }
}

