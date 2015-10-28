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
	public void ChangeIt(string SceneToAppear){
		MainCanvas.GetComponent<Animator> ().SetTrigger (SceneToAppear);
	}
}
