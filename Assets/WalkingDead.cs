using UnityEngine;
using System.Collections;

public class WalkingDead : StateMachineBehaviour {

	private GameObject target;
	private Vector2 direction;
	private GameObject Enemy;
	//private ForceMode2D force2;
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Enemy= animator.gameObject;
	}
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{

		//Debug.Log (Time.time);
		direction = new Vector3(Random.Range(-100f,100f),Random.Range(-100f,100f))- Enemy.transform.position;	
		if(Time.time%2 <=0.2){
			Enemy.GetComponent<Rigidbody2D> ().velocity = (direction.normalized*3);
	}
 }
}