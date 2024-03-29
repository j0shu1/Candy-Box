using UnityEngine;

/* 
This script will run across all scenes. As such, please only include code that will exist for every scene. 
Any code that doesn't should simply reference the GameManager object. (e.g. GameManager.Instance.GetCandy())
*/

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Component script instances
    private Player player;
    private Candy candy;
    private FeatureBar featureBar;

    public bool EatCandyScript; // Unsure if this is the best way to keep the EatCandy button visible despite scene changes
    
    private bool WeaponButtonActive = true;
    private bool NextMapButtonActive = false;
    private bool FinalBossButtonActive = false;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        player = gameObject.GetComponent<Player>();
        candy = gameObject.GetComponent<Candy>();
        featureBar = gameObject.GetComponent<FeatureBar>();
    }

    // *********   PUBLIC METHODS     **********

    /*******************************************
     *           CANDY METHODS
     *      Makes Candy accessible to all!
     * 
     *******************************************/
    // Methods that do not return values
    public void SpendCandy(int amount) { candy.SpendCandy(amount); }
    public void ResetCandy() { candy.ResetCandy(); }
    public void EatCandies() { candy.EatCandies(); }
    public void AddCandies(int candies) { candy.AddCandies(candies); }

    // Methods that return values
    public int GetCandy() { return candy.GetCandy(); }
    public int GetTotalCandyEaten() { return candy.GetTotalCandyEaten(); }
    public bool CanSpend(int amount) { return candy.CanSpend(amount); }

    /*******************************************
     *           PLAYER METHODS
     *  Makes Player accessible to all!
     * 
     *******************************************/
    // Methods that do not return values
    public void SetWeapon(int weaponSelection) { player.SetWeapon(weaponSelection); }
    public void TakeDamage(int damage) { player.TakeDamage(damage); }
    public void SetMaxHealth(){player.SetMaxHealth();}

    // Methods that return values
    public int GetWeapon() { return player.GetWeapon(); }
    public int GetHealth() { return player.GetHealth(); }

    /*******************************************
    *           FEATUREBAR METHODS
    *         Controls everything to
    *         do with the FeatureBar.
    *******************************************/
    // Methods that do not return values
    public void EnableAddFeatureButton() { featureBar.EnableAddFeatureButton(); }
    public void EnableNextFeature() { featureBar.EnableNextFeature(); }

    // Methods that return values
    public int GetFeatureCost() { return featureBar.GetFeatureCost(); }

    /*******************************************
    *           SPAWNABLE BUTTONS
    *         Controls everything to
    *         do with spawning buttons.
    *******************************************/
    // Methods that do not return values
    public bool GetWeaponBuy() { return WeaponButtonActive; }
    public bool GetNextMapEnabled() { return NextMapButtonActive; }
    public bool GetFinalBossEnabled() { return FinalBossButtonActive; }
    // Methods that do not return values
    public void SetWeaponBuy(bool status) { WeaponButtonActive = status; }
    public void SetNextMapEnabled(bool status) {  NextMapButtonActive = status; }
    public void SetFinalBossEnabled(bool status ) {  FinalBossButtonActive = status; }
}