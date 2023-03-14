using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(30, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.ToString() == "Enemy (UnityEngine.GameObject)")
        {
           this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
