using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {

    public string ScoreTAG, ScoreGameOver, HighScoreTAG;
    private GameObject Score, ScoreGameOverr, HighScorer;
    private int Scorer;
    private int HighScore;
    // Use this for initialization
    void Start()
    {
        Score = GameObject.FindGameObjectWithTag(ScoreTAG);
        ScoreGameOverr = GameObject.FindGameObjectWithTag(ScoreGameOver);
        HighScorer = GameObject.FindGameObjectWithTag(HighScoreTAG);
        getPlayerPrefs();
        Score.GetComponent<Text>().text = Scorer.ToString();
        ScoreGameOverr.GetComponent<Text>().text = Scorer.ToString();
        HighScorer.GetComponent<Text>().text = "Highest Score: " + HighScore;
    }

    // Update is called once per frame
    public void SetScore(int ScoreToAdd)
    {
        Scorer = Scorer + ScoreToAdd;
        Score.GetComponent<Text>().text = Scorer.ToString();
        ScoreGameOverr.GetComponent<Text>().text = " " + Scorer;
        if (Scorer >= HighScore)
        {
            HighScore = Scorer;
            setPlayerPrefs(Scorer);
            PlayerPrefs.Save();
        }
        HighScorer.GetComponent<Text>().text = " " + HighScore;

    }
    public int GetScore()
    {
        return Scorer;
    }
    void getPlayerPrefs()
    {
        HighScore = PlayerPrefs.GetInt("highscore");
    }

    void setPlayerPrefs(int score)
    {
        PlayerPrefs.SetInt("highscore", score);
    }
}
