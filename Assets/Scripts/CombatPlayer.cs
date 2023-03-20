using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatPlayer : MonoBehaviour
{
    
    public CombatManager combatManager;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(60, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.ToString() == "Win (UnityEngine.GameObject)")
        {
            gameManager = GameManager.Instance;
            
            gameManager.AddCandies(combatManager.GetComponent<BattleLog>().GetWinReward()); //secds player accumulated rewards

            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Die);
            BgScript.BgInstance.Audio.clip = BgScript.BgInstance.MusicClips[0];
            BgScript.BgInstance.Audio.Play(0);
            SceneManager.LoadScene(2);
        }
    }
}
