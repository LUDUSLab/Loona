using UnityEngine;
using System.Collections;

public class SetCameraLimits : MonoBehaviour {
	public bool SetX, SetY;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay2D(Collider2D other){
		if (SetX) {
			Camera.main.GetComponent<CameraFollowPlayer>().SetXlimit(other.transform.position.x);
		}
		if (SetY) {
			Camera.main.GetComponent<CameraFollowPlayer>().SetYlimit(other.transform.position.y);
		}
	}
	void OnTriggerExit2D(Collider2D other){
		Camera.main.GetComponent<CameraFollowPlayer>().ResetLimits();
	}
}
