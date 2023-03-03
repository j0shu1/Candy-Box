using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject healthBar;
    public Slider healthSlider;
    private GameManager gameManager;
    
    private int attack = 10; // Just a default value
    private int weaponSelection = 0; //default weapon selected
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        maxHealth = 100;
        currentHealth = maxHealth;
        InvokeRepeating("Regen", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("HealthBar") != null)
        {
            healthBar = GameObject.FindGameObjectWithTag("HealthBar");
            healthSlider = healthBar.GetComponent<Slider>();
            healthSlider.value = currentHealth;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        int WeaponIndex = gameManager.GetWeapon();
        switch(WeaponIndex)
        {
            case 0: SetAttack(1); break;
            case 1: SetAttack(10); break;
            case 2: SetAttack(20); break;
            case 3: SetAttack(30); break;
        }
    }


    // COMBAT FUNCTIONS
    public void SetAttack(int number)
    {
        attack = number;
    }
    
    public int GetAttack()
    {
        return attack;
    }

    void Regen() // Should only run when not in combat
    {
        if (SceneManager.GetActiveScene().buildIndex != 5)
        {
            if (currentHealth < maxHealth)
            {
            currentHealth += 1;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            BgScript.BgInstance.Audio.clip = BgScript.BgInstance.MusicClips[0];
            BgScript.BgInstance.Audio.Play(0);
            SceneManager.LoadScene(2);
            //ChangeScene.MoveToScene(2);
        }
    }

    // WEAPON SELECTION
    public void SetWeapon(int number)
    {
        weaponSelection = number;
    }
    public int GetWeapon()
    {
        return weaponSelection;
    }
}
