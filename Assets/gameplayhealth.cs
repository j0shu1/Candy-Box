public class gameplayhealth : MonoBehaviour 

{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start() 
    {
        currentHealth = maxHealth;
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

}
