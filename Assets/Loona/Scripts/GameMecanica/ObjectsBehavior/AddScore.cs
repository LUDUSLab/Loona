using UnityEngine;
using System.Collections;

public class AddScore : MonoBehaviour {
    public int ScoreToAdd;
    public string SceneAspectsControllerTag;
    private GameObject SceneAspectsController;
	// Use this for initialization
	void Start () {
        SceneAspectsController = GameObject.FindGameObjectWithTag(SceneAspectsControllerTag);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "ColisorPlayer")
        {
            SceneAspectsController.GetComponent<ScoreManager>().SetScore(ScoreToAdd);
        }
    }
}
