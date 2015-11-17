using UnityEngine;
using System.Collections;

public class StateMachineC : MonoBehaviour {
	private Vector2 PlayerScale,Distance,ThisScale,Controller;
	private GameObject PlayerController,Player;
	private Animator animator;
	public float MinDistance;

	void Start () {
		PlayerController = GameObject.FindGameObjectWithTag ("PlayerController");	
		animator = GetComponent<Animator>();
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () {
		PlayerScale = PlayerController.GetComponent<ScaleTrack> ().CheckPlayerSize ();
		ThisScale = GetComponent<SpriteRenderer>().bounds.size;
		Distance = Player.transform.position - this.transform.position;
		//Debug.Log (Distance.sqrMagnitude);

		if ((Distance.sqrMagnitude < MinDistance && (PlayerScale.x < ThisScale.x))) {
			animator.SetTrigger ("Hunt");
		} else if ((Distance.sqrMagnitude < MinDistance && (PlayerScale.x > ThisScale.x))) {
			animator.SetTrigger("Run");
		}else if(Distance.sqrMagnitude > MinDistance){
			animator.SetTrigger("Walk");
		}
	}

	void OnCollisionEnter2D(Collision2D other){
	

		if(other.gameObject.tag == "Player"){
			PlayerController.GetComponent<Movimentacao>().Mover(Distance.x*10000f,Distance.y*1000f,ForceMode2D.Force);
			Debug.Log ("Prestou");
		}
	}


}

