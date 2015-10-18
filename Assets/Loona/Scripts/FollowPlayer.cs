using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public float speed = .01f;
	public string ObjectTagToBeFollowed;
    public float RotantionSpeed, MoveSpeed;
	private GameObject Enemy;
	private Vector2 shootTarget;
	private bool CanIShoot= true;
    private NavMeshAgent agent;
    private Transform PlayerTransform;
    private Vector3 AuxVector3;
    private Vector3 Tranfer;
    private Vector3 otherPosition;
    void Start(){
        //Enemy = GameObject.FindGameObjectWithTag ("ComidaGordurosa");
        PlayerTransform = GameObject.FindGameObjectWithTag (ObjectTagToBeFollowed).transform;
    }
	void OnTriggerStay2D(Collider2D other){
		if(other.gameObject.tag == ObjectTagToBeFollowed){
            
            /* Look at Player*/
            AuxVector3 = new Vector3((PlayerTransform.position.x - transform.position.x), (PlayerTransform.position.y - transform.position.y), (PlayerTransform.position.z - transform.position.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(AuxVector3), RotantionSpeed * Time.deltaTime);

            /* Move at Player*/
            transform.parent.position += (transform.forward) * MoveSpeed * Time.deltaTime ;
            if (CanIShoot){

				Invoke("Shoot",5f);
               
                GetComponent<Shoot>().GerarTiro(other.transform.position - this.transform.position, this.transform.position);
               
				
				CanIShoot = false;
			}
		
		}
	}
	void Shoot(){
		CanIShoot = true;
	}
}