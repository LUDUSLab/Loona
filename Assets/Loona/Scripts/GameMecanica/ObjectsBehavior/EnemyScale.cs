using UnityEngine;
using System.Collections;

public class EnemyScale : MonoBehaviour {
	private GameObject PlayerController;
	public float ScaleAddOnStart;
	// Use this for initialization
	void Start () {
		PlayerController = GameObject.FindGameObjectWithTag ("PlayerController");
		if(transform.localScale.x < PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize().x ){
			transform.localScale += new Vector3(ScaleAddOnStart,ScaleAddOnStart,0);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
