using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {
	
	public string PlayerTag;
	public float RotantionSpeed, MoveSpeed;
    public string PlayerColliderTag = "ColisorPlayer", ControllerTag = "GameController", EnemyTag = "Enemy";
	private GameObject controller;
	private GameObject PlayerCollider;
	private Transform PlayerTransform;
	private Vector3 AuxVector3, ScalePlayer, ScaleThisObject;
	public float TimeToDestroy,TimeStepUpdate,ScaleAddedToPlayer;
	
	void Start ()
	{
		controller = GameObject.FindGameObjectWithTag(ControllerTag);
		PlayerCollider = GameObject.FindGameObjectWithTag(PlayerColliderTag);
		PlayerTransform = PlayerCollider.transform;
	}
	void OnTriggerEnter2D(Collider2D other){
		ScalePlayer = PlayerCollider.GetComponent<CircleCollider2D> ().bounds.size;
		ScaleThisObject = this.gameObject.GetComponent<CircleCollider2D> ().bounds.size;
		if ((other.gameObject.tag == PlayerColliderTag && this.gameObject.tag == EnemyTag) && (ScalePlayer.x > ScaleThisObject.x)) {
			Follow ();
			InvokeRepeating ("Update2", 0, TimeStepUpdate);
			Invoke ("DestroyNow", TimeToDestroy);
			controller.GetComponent<Crescer> ().MassAddUp (PlayerCollider, ScaleAddedToPlayer);
		} else if (ScalePlayer.x < ScaleThisObject.x) {
			controller.GetComponent<FimDeJogo>().Morrer();
		}
		if((other.gameObject.tag == PlayerTag)&& (ScalePlayer.x > ScaleThisObject.x))
		{
			InvokeRepeating("Update2", 0, TimeStepUpdate);
			Invoke("DestroyNow", TimeToDestroy);
			controller.GetComponent<Crescer>().MassAddUp(PlayerCollider,ScaleAddedToPlayer);
		}else if (ScalePlayer.x < ScaleThisObject.x){
			
			controller.GetComponent<FimDeJogo>().Morrer();
		}
	}
	void DestroyNow()
	{
        if(gameObject.tag == "ComidaGordurosa")
        {
            controller.GetComponent<MapObjectsSpawn>().InstantiateMapObjects(1, this.gameObject);
        }
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
