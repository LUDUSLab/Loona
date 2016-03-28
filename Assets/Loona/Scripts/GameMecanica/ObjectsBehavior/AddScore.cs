using UnityEngine;
using System.Collections;

public class AddScore : MonoBehaviour {
    public int ScoreToAdd;
    public GameObject SceneAspectsController;
	// Use this for initialization
	void Start () {
		SceneAspectsController = GameObject.FindGameObjectWithTag ("SceneAspectsController");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "ColisorPlayer")
        {
			bool WinningCondition = SceneAspectsController.GetComponent<VictoryCondition> ().GetWinningCurrentCondition ();
			if(!WinningCondition)
           	 SceneAspectsController.GetComponent<ScoreManager>().SetScore(ScoreToAdd);
        }
    }
}
