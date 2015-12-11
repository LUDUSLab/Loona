using UnityEngine;
using System.Collections;

public class EnemyScale : MonoBehaviour {
	private GameObject PlayerController;
	public float ScaleLoonaAddedOnEnemy;
	// Use this for initialization
	void Start () {
        float FatScale = PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize().x/10;
        PlayerController = GameObject.FindGameObjectWithTag ("PlayerController");
		//if(transform.localScale.x < PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize().x ){
			transform.localScale =  new Vector3(PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize().x+ FatScale, PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize().y+ FatScale, 0);
			if(transform.localScale.x > 2){
				transform.localScale = new Vector3(2f,2f,0f);
			}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
