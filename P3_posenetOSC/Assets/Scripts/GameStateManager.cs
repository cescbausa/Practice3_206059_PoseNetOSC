using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    [HideInInspector]
    public int diamondsCollected;

    [HideInInspector]
    public int livesLeft;

    public int hitsBeforeGameOver;
    public ProjectileSpawner projectileSpawner;
    
    public int diamondsToWin;
    public DiamondSpawner diamondSpawner;
    public Text gameOver;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        gameOver.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void collectDiamonds()
    {
        diamondsCollected += 1;
        UIManager.Instance.UpdateDiamondsCollected();
    }

    public void lessLife()
    {
        livesLeft += 1;
        UIManager.Instance.UpdateHitsTaken();
        if(livesLeft == hitsBeforeGameOver)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        projectileSpawner.canSpawn = false;
        projectileSpawner.DestroyAllProjectiles();
        diamondSpawner.canSpawn = false;
        diamondSpawner.DestroyAllDiamonds();
        gameOver.text = "GAME OVER";

    }
}
