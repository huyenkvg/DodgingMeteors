using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private int scoreBest;
    static public ScoreManager Instance;

    public void AddScore(int n)
    {
        score += n;
        if (scoreBest < score)
        {
            scoreBest = score;
            UIManager.Instance.txtScoreBest.GetComponent<Text>().text = scoreBest.ToString();
            // lưu điểm:
            PlayerPrefs.SetInt("SCOREBEST", scoreBest);
        }

        //Debug.Log(score);
        UIManager.Instance.txtScore.GetComponent<Text>().text = score.ToString();
    }

    private void Awake()
    {
        if (!Instance) Instance = this;
    }
    // Use this for initialization
    private void Start()
    {
        scoreBest = PlayerPrefs.GetInt("SCOREBEST");
        UIManager.Instance.txtScoreBest.GetComponent<Text>().text = scoreBest.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetScore()
    {
        return score;

    }
    public int GetScoreBest()
    {
        return scoreBest;
    }
}
