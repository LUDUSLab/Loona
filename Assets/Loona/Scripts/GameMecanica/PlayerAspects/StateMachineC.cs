﻿using UnityEngine;
using System.Collections;

public class StateMachineC : MonoBehaviour {
	private Vector2 PlayerScale,Distance,ThisScale,Controller;
	private GameObject PlayerController,Player;
	public GameObject HuntFace, RunFace;
	private Animator animator;
	public float MinDistance;
	public float ScaleAddToPlayer;
	public float PunchForce;
	private Animator PlayerExpressions;
	void Start () {
		PlayerController = GameObject.FindGameObjectWithTag ("PlayerController");	
		animator = GetComponent<Animator>();
		Player = GameObject.FindGameObjectWithTag ("Player");
		PlayerExpressions = GameObject.FindGameObjectWithTag ("PlayerExpressions").GetComponent<Animator>();
	}

	void FixedUpdate () {
		PlayerScale = PlayerController.GetComponent<ScaleTrack> ().CheckPlayerSize ();
		ThisScale = GetComponent<SpriteRenderer>().bounds.size;
		Distance = Player.transform.position - this.transform.position;
		//Debug.Log (Distance.sqrMagnitude);

		if ((Distance.sqrMagnitude < MinDistance && (PlayerScale.x < ThisScale.x))) {
			animator.SetTrigger ("Hunt");
			RunFace.SetActive(false);
			HuntFace.SetActive(true);
		} else if ((Distance.sqrMagnitude < MinDistance && (PlayerScale.x > ThisScale.x))) {
			animator.SetTrigger("Run");
			HuntFace.SetActive(false);
			RunFace.SetActive(true);
		}else if(Distance.sqrMagnitude > MinDistance){
			animator.SetTrigger("Walk");
			RunFace.SetActive(false);
			HuntFace.SetActive(true);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
	

		if(other.gameObject.tag == "Player"){
			if(PlayerScale.x < ThisScale.x){
				PlayerController.GetComponent<Movimentacao>().Mover(Distance.normalized.x*PunchForce*-1f,Distance.normalized.y*-1f*PunchForce,ForceMode2D.Force);
				PlayerController.GetComponent<Crescer>().MassAddUp(Player,ScaleAddToPlayer);
				//Player.transform.localScale = new Vector3(Player.transform.localScale.x - ScaleAddToPlayer,Player.transform.localScale.y - ScaleAddToPlayer);
			}else if(PlayerScale.x > ThisScale.x){
				ScaleAddToPlayer = ThisScale.x/2;
				PlayerController.GetComponent<Crescer>().MassAddUp(Player,ScaleAddToPlayer);
				PlayerExpressions.SetTrigger("Eat");
				Destroy(this.gameObject);
			
			
			}

		}
	}
}

