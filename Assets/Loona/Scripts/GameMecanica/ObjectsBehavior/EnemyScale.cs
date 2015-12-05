using UnityEngine;
using System.Collections;

public class EnemyScale : MonoBehaviour {
	private GameObject PlayerController;
	public float ScaleLoonaAddedOnEnemy;
	// Use this for initialization
	void Start () {
		PlayerController = GameObject.FindGameObjectWithTag ("PlayerController");
		if(transform.localScale.x < PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize().x ){
			transform.localScale =  new Vector3(PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize().x*ScaleLoonaAddedOnEnemy ,PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize().y*ScaleLoonaAddedOnEnemy ,0);
			if(transform.localScale.x > 2){
				transform.localScale = new Vector3(2f,2f,0f);

			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
