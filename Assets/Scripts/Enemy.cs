using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float currentHP;
    public float maxHP;
    public Image HealthBarFill;
    public int attack;
    //private GameManager gameManager;
    
    void Start()
    {
        // attack = GameManager.Instance.GetAttack();
        //  gameManager = GameManager.Instance;
        //  attack = gameManager.GetAttack();
        attack = 10;
    }
    public void SetEnemyDamage(int damage)
    {
        attack = damage;
    }

    void Update()
    {
        // Move to the left
        GetComponent<Rigidbody2D>().velocity = new Vector2(-30, 0);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.ToString() == "Player (UnityEngine.GameObject)")
        {
           InvokeRepeating("Damage", 0.0f, 1.0f);
        }
    }

    void Damage()
    {
        currentHP -= attack;
        HealthBarFill.fillAmount = currentHP / maxHP;
        GameManager.Instance.TakeDamage(10);
        if (currentHP == 0)
        {
            Destroy(gameObject);
        }
    }    
}
