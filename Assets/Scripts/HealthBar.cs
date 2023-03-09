using UnityEngine;
public class HealthBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;


    public HealthBar healthBar;
    public Gradient gradient;


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
