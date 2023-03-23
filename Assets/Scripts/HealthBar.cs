using UnityEngine;
public class HealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int gradient;

    
    public int PlayerHealthBar;


 
     // Use t$$anonymous$$s for initialization
     
     // Update is called once per frame

    void Start()
    {
        currentHealth = maxHealth;

    }

    void Update()
    {
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
