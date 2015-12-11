using UnityEngine;
using System.Collections;

public class DebugOnTriggerCollision : MonoBehaviour {
	public bool TriggerEnter,TriggerExit,CollisionEnter,CollisionExit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D cool){
		if(TriggerEnter)Debug.Log ("TriggerEnter"+ cool.gameObject.tag);
	}
	void OntriggerExit2D( Collider2D cool){
		if(TriggerExit)Debug.Log ("TriggerExit"+ cool.gameObject);
	}
	void OnCollisionEnter2D( Collision2D cool){
		if(CollisionEnter)Debug.Log ("CollisionEnter"+cool.gameObject);
	}
	void OnCollisionExit2D( Collision2D cool){
		if(CollisionEnter)Debug.Log ("CollisionExit"+cool.gameObject);
	}
}
