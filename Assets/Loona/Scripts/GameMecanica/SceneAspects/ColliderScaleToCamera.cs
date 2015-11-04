using UnityEngine;
using System.Collections;

public class ColliderScaleToCamera : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		InvokeRepeating ("SetBoxCollider",0, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void SetBoxCollider(){
		float height =  Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;
		GetComponent<BoxCollider2D> ().size = new Vector2 (width-1, height-1);
	}
}