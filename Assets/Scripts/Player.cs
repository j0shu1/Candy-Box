using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int attack = 10; // Just a default value
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
}
