using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {
    public string SceneToLoad;
	// Use this for initialization
	void Start () {
        Invoke("LoadScene", 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void LoadScene()
    {
        Application.LoadLevel(SceneToLoad);

    }
}
