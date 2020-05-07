using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text diamondsCollectedText;
    public Text hitsTakenText;
    public GameObject gameOverWindow;


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void UpdateDiamondsCollected()
    {
        diamondsCollectedText.text = GameStateManager.Instance.diamondsCollected.ToString();
    }

    public void UpdateHitsTaken()
    {
        hitsTakenText.text = GameStateManager.Instance.livesLeft.ToString();
    }
    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }


}
