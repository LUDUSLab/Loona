using UnityEngine;
using System.Collections;

public class Hunt2 : StateMachineBehaviour {

	private GameObject target;
	private Vector2 direction;
	private GameObject Enemy;
	public float speed;
	//private ForceMode2D force2;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		target = GameObject.FindGameObjectWithTag ("Player");
		Enemy = GameObject.FindGameObjectWithTag ("Enemy");
	}
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		direction = target.transform.position - Enemy.transform.position;
		Enemy.GetComponent<Rigidbody2D> ().velocity = (direction.normalized*speed);
		//OnTriggerEnter2D (target.GetComponent<Collider2D>());
	
	}
	//void OnTriggerEnter2D(Collider2D other) {
		//if(other.gameObject.tag == "Player"){
			//other.GetComponent<Rigidbody2D>().velocity = new Vector2 (other.transform.position.x -5,other.transform.position.y -5);
			//other.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
			//Debug.Log("prestou");
		//}
	//}
	
}




