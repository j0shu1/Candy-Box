using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelection : MonoBehaviour
{
    public Text TextBox;
    //private GameManager gameManager;
    public Dropdown dropdown;
    public List<Sprite> WeaponSprites;
    public Object WeaponSelected;

    void Start(){
        dropdown = GetComponent<Dropdown>();
        
        //var dropdown = transform.GetComponent<Dropdown>();
        
        

        List<string> weapons = new List<string>();
        weapons.Add("Select One");
        weapons.Add("Weapon 1");
        weapons.Add("Weapon 2");
        weapons.Add("Weapon 3");

        foreach(var weapon in weapons)
        {
            dropdown.options.Add(new Dropdown.OptionData() {text = weapon});
        }

        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });
    }

    void DropdownItemSelected(Dropdown dropdown)
    {
        //gameManager = GameManager.Instance;

        int index = dropdown.value;
        
        //gameManager.SetWeapon(index);

        //WeaponRend = WeaponSelected.GetComponent<SpriteRenderer>();
        switch(index)
        {
            case 0: WeaponSelected= WeaponSprites[0]; break;
            case 1: WeaponSelected = WeaponSprites[1]; break;
            case 2: WeaponSelected = WeaponSprites[2]; break;
            case 3: WeaponSelected = WeaponSprites[3]; break;
        }
        
        TextBox.text = dropdown.options[index].text;
    }
    void Update()
    {
        // Changes the text to Candies: <candies>
        //candyText.text = "Candies: " + gameManager.GetCandy();
    }
}
