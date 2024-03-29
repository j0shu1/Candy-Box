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
    public int PlayerAttack;
    public int bountyVal;
    private GameManager gameManager;
    public CombatManager combatManager;

    
    void Start()
    {
        // attack = GameManager.Instance.GetAttack();
        gameManager = GameManager.Instance;
        PlayerAttack =(gameManager.GetWeapon() * 10);
        //attack = 10;
        bountyVal =  Random.Range(bountyVal*10,bountyVal*20);
    }
    public void SetEnemyDamage(int damage)
    {
        attack = damage;
    }

    void Update()
    {
        // Move to the left
        //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
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
        currentHP -= PlayerAttack;
        HealthBarFill.fillAmount = currentHP / maxHP;
        int PlayerHealth = gameManager.GetHealth();
        if (PlayerHealth < attack){
            combatManager.GetComponent<BattleLog>().ResetPoints();
        }
        
        gameManager.TakeDamage(attack);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Attack);
        if (currentHP <= 0)
        {
            BattleLog battleLog = combatManager.GetComponent<BattleLog>();
            battleLog.AddLine($"Killed enemy. You collected {bountyVal} candies.\t(Total earned: {battleLog.GetPoints() + bountyVal})", bountyVal); //Add bounty to accumulated candies
            
            Destroy(gameObject);
        }

    }    
}
