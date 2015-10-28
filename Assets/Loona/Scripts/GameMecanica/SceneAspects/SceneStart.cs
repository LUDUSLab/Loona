using UnityEngine;
using System.Collections;

public class SceneStart : MonoBehaviour {
    public GameObject[] Characters;
	// Use this for initialization
	void Start () {
        Time.timeScale = 0;
        Instantiate(Characters[PlayerPrefs.GetInt("PositionInCharacterVector")]);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
