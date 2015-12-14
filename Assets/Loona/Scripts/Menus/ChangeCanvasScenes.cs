using UnityEngine;
using System.Collections;

public class ChangeCanvasScenes : MonoBehaviour {
	public GameObject MainCanvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ChangeIt(string MenuFeedBack){
		MainCanvas.GetComponent<Animator> ().SetTrigger (MenuFeedBack);

        GameObject.Find("LightEffect").SetActive(false);
	}
}
