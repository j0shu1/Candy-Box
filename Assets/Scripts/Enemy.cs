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
    
    
    void Start()
    {
        // attack = GameManager.Instance.GetAttack();
        attack = 10;
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
        if (currentHP == 0)
        {
            Destroy(gameObject);
        }
    }    
}