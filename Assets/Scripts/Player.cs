using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int attack = 10; // Just a default value
    private int weaponSelection = 0; //default weapon selected
    
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
