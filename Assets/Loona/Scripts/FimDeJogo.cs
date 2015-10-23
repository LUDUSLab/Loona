using UnityEngine;
using System.Collections;

//Made By JMG
public class FimDeJogo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Morrer()
    {
        GetComponent<ButtonController>().SetTriggerAnimator("GameOver");
        Time.timeScale = 0;
        Debug.Log("Derrotado");
    }
}
