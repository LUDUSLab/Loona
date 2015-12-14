using UnityEngine;
using System.Collections;

public class EnemyScale : MonoBehaviour {
	private GameObject PlayerController;
	// Use this for initialization
	void Start () {
        PlayerController = GameObject.FindGameObjectWithTag("PlayerController");
        float FatScale = PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize().x/5;
        //Debug.Log(PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize().x);
		//if(transform.localScale.x < PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize().x ){
			transform.localScale =  new Vector3(PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize().x+ FatScale,PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize().y+ FatScale, 0);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
