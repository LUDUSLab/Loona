﻿using UnityEngine;
using System.Collections;

public class RunAway2 : StateMachineBehaviour {

	private GameObject target;
	private Vector2 direction;
	private GameObject Enemy;


	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		target = GameObject.FindGameObjectWithTag ("Player");
		Enemy = GameObject.FindGameObjectWithTag ("Enemy");
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		direction =  Enemy.transform.position - target.transform.position;
		Enemy.GetComponent<Rigidbody2D> ().velocity =  (direction.normalized*2 );
		//Debug.Log (direction);
	
}
}