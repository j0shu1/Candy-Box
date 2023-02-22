using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelection : MonoBehaviour
{
    public Text TextBox;
    private GameManager gameManager;
    public Dropdown dropdown;
    public List<Sprite> WeaponSprites;
    public Object WeaponSelected;
    public Sprite WeaponCurrent;
    //public SpriteRenderer Weapon;

    void Start(){
        dropdown = GetComponent<Dropdown>();
        //gameManager = GameManager.Instance;
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
        gameManager = GameManager.Instance;

        int index = dropdown.value;
        
        if(index ==0){
            index = gameManager.GetWeapon();
        }
        

        gameManager.GetWeapon();
        switch(index)
        {
            case 0: WeaponCurrent = WeaponSprites[0]; break;
            case 1: WeaponCurrent = WeaponSprites[1]; break;
            case 2: WeaponCurrent = WeaponSprites[2]; break;
            case 3: WeaponCurrent = WeaponSprites[3]; break;
        }
        //Weapon = WeaponSelected.GetComponent<SpriteRenderer>();
        gameManager.SetWeapon(index);
        TextBox.text = dropdown.options[index].text;
        //Weapon.Sprite = WeaponCurrent;
        gameManager.SetWeapon(index);
    }
    void Update()
    {
        // Changes the text to Candies: <candies>
        //candyText.text = "Candies: " + gameManager.GetCandy();
        dropdown = GetComponent<Dropdown>();
        gameManager = GameManager.Instance;
        gameManager.SetWeapon(dropdown.value);
    }
}
