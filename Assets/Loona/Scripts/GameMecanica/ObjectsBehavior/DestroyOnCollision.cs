using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {
	
	public string PlayerTag;
	public float RotantionSpeed, MoveSpeed;
    public string PlayerColliderTag = "ColisorPlayer", ControllerTag = "GameController", EnemyTag = "Enemy";
    public string PlayerControllerTag = "PlayerController";
    public string SceneAspectsControllerTag = "SceneAspectsController";
    private GameObject PlayerController;
    private GameObject SceneAspectsController;
    private GameObject controller;
    private GameObject BGController;
    public string BGControllerTag = "BGController";
    private GameObject PlayerCollider,PlayerScaler;
	private Transform PlayerTransform;
	private Vector3 AuxVector3, ScalePlayer, ScaleThisObject;
	public float TimeToDestroy,TimeStepUpdate,ScaleAddedToPlayer;
	
	void Start ()
	{
        PlayerController = GameObject.FindGameObjectWithTag(PlayerControllerTag);
        BGController = GameObject.FindGameObjectWithTag(BGControllerTag);
        SceneAspectsController = GameObject.FindGameObjectWithTag(SceneAspectsControllerTag);
        PlayerCollider = GameObject.FindGameObjectWithTag(PlayerColliderTag);
		PlayerTransform = PlayerCollider.transform;
        PlayerScaler = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerEnter2D(Collider2D other){
		ScalePlayer = PlayerCollider.GetComponent<CircleCollider2D> ().bounds.size;
		ScaleThisObject = this.gameObject.GetComponent<CircleCollider2D> ().bounds.size;
		if ((other.gameObject.tag == PlayerColliderTag && this.gameObject.tag == EnemyTag) && (ScalePlayer.x > ScaleThisObject.x)) {
			Follow ();
			InvokeRepeating ("Update2", 0, TimeStepUpdate);
			Invoke ("DestroyNow", TimeToDestroy);
            PlayerController.GetComponent<Crescer> ().MassAddUp (PlayerScaler, ScaleAddedToPlayer);
		} else if (ScalePlayer.x < ScaleThisObject.x) {
			controller.GetComponent<FimDeJogo>().Morrer();
		}
		if((other.gameObject.tag == PlayerTag)&& (ScalePlayer.x > ScaleThisObject.x))
		{
			InvokeRepeating("Update2", 0, TimeStepUpdate);
			Invoke("DestroyNow", TimeToDestroy);
            PlayerController.GetComponent<Crescer>().MassAddUp(PlayerScaler, ScaleAddedToPlayer);
		}else if (ScalePlayer.x < ScaleThisObject.x){

            SceneAspectsController.GetComponent<FimDeJogo>().Morrer();
		}
	}
	void DestroyNow()
	{
        if(gameObject.tag == "ComidaGordurosa")
        {
            BGController.GetComponent<MapObjectsSpawn>().InstantiateMapObjects(1, this.gameObject);
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
