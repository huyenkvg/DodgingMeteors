using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static public UIManager Instance;

    public GameObject txtScore;
    public GameObject txtScoreBest;
    public GameObject txtPnlScoreBest;
    public GameObject txtPnlScore;
    public GameObject pnlGameOver;
    public GameObject startCanvas;
    public GameObject overCanvas;
    private void Awake()
    {
        if (!Instance)
            Instance = this;
    }
    public void eventPlay()
    {
        GameManager.Instance.mGameState = GameState.Playing;
        startCanvas.SetActive(false);
    }
    public void EventPlayAgain()
    {
        Application.LoadLevel(0); // tro lai 
    }
    public void ShowGameOver()
    {
        overCanvas.SetActive(true);
    }


}