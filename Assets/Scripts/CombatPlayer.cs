using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

            // give player accumulated rewards
            gameManager.AddCandies(combatManager.GetComponent<BattleLog>().GetWinReward());

            int currentScene = SceneManager.GetActiveScene().buildIndex;

            // Won basement fight
            if (currentScene == 4)
            {
                gameManager.SetNextMapEnabled(true);
                AfterBattleReset();
                // Load map scene
                SceneManager.LoadScene(2);
            }

            // Won desert fight
            if (currentScene == 6)
            {
                gameManager.SetFinalBossEnabled(true);
                AfterBattleReset();
                // Load map scene
                SceneManager.LoadScene(2);
            }

            // Won boss fight
            if (currentScene == 7)
            {
                AfterBattleReset();
                // Load victory scene
                SceneManager.LoadScene(9);
            }

        }

        
    }
    private void AfterBattleReset()
    {
        // Reset player velocity
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        // Reset music
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Die);
        BgScript.BgInstance.Audio.clip = BgScript.BgInstance.MusicClips[0];
        BgScript.BgInstance.Audio.Play(0);
    }
}
