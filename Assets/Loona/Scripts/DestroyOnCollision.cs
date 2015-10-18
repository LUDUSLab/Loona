using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {
	
	public string PlayerTag;
	public float RotantionSpeed, MoveSpeed;
	private GameObject controller;
	private GameObject player;
	private Transform PlayerTransform;
	private Vector3 AuxVector3;
	public float TimeToDestroy,TimeStepUpdate,ScaleAddedToPlayer;
	
	void Start ()
	{
		controller = GameObject.FindGameObjectWithTag("GameController");
		player = GameObject.FindGameObjectWithTag("Player");
		PlayerTransform = player.transform;
	}
	void OnTriggerEnter2D(Collider2D other){
		if ((other.gameObject.tag == "Player" && this.gameObject.tag == "Enemy")&& (player.transform.localScale.x > this.transform.localScale.x))
		{
			Debug.Log("prestou");
			Follow();
			InvokeRepeating("Update2",0, TimeStepUpdate);
			Invoke("DestroyNow", TimeToDestroy);
			controller.GetComponent<Crescer>().MassAddUp(player,ScaleAddedToPlayer);
		}
		//if (other.gameObject.tag == "Player" && this.gameObject.tag == "EnemySphere")
		//{
		//controller.GetComponent<Crescer>().MassAddUp(player,);
		///InvokeRepeating("Update2", 0, TimeStepUpdate);
		// Invoke("DestroyNow", TimeToDestroy);
		// }
		if((other.gameObject.tag == PlayerTag)&& (player.transform.localScale.x > this.transform.localScale.x))
		{
			Debug.Log("prestou");
			InvokeRepeating("Update2", 0, TimeStepUpdate);
			Invoke("DestroyNow", TimeToDestroy);
			controller.GetComponent<Crescer>().MassAddUp(player,ScaleAddedToPlayer);
		}
	}
	void DestroyNow()
	{
		Destroy(gameObject);
	}
	void Follow()
	{
		/* Look at Player*/
		AuxVector3 = new Vector3((PlayerTransform.position.x - transform.position.x), (PlayerTransform.position.y - transform.position.y), (PlayerTransform.position.z - transform.position.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(AuxVector3), RotantionSpeed * Time.deltaTime);
		
		/* Move at Player*/
		transform.position += (transform.forward) * MoveSpeed * Time.deltaTime;
	}
	void Update2()
	{
		Follow();
	}
}
