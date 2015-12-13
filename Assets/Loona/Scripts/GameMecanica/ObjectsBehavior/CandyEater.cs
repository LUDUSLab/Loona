using UnityEngine;
using System.Collections;

public class CandyEater : MonoBehaviour
{
    private Transform PlayerTransform;
    private GameObject PlayerController, PlayerScaler;
    private MapObjectsSpawn MapsObjectsSpawnObject;
    public float TimeStepUpdate, MoveSpeed, RotantionSpeed, ScaleAddedToPlayer;
    public float TimeToDestroy = 1f;
    private GameObject Player;
    // Use this for initialization
    void Start()
    {
        PlayerController = GameObject.FindGameObjectWithTag("PlayerController");
        PlayerScaler = GameObject.Find("loona_v3(Clone)");
        PlayerTransform = GameObject.FindGameObjectWithTag("ColisorPlayer").transform;
        MapsObjectsSpawnObject = GameObject.FindGameObjectWithTag("BGController").GetComponent<MapObjectsSpawn>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ColisorPlayer")
        {
            Destroy(GetComponent<Rigidbody2D>());
            Player = other.gameObject;
            InvokeRepeating("Follow", 0, TimeStepUpdate);
            PlayerController.GetComponent<Crescer>().MassAddUp(PlayerScaler, ScaleAddedToPlayer);
            GetComponent<CircleCollider2D>().enabled = false;

        }

        //if( anim_Animator.GetCurrentAnimatorStateInfo(0).IsName("MyAnimationName"))
    }
    void Follow()
    {
        float Distance = transform.position.x - Player.transform.position.x;
        Distance = Mathf.Abs(Distance);
        if (Distance<0.1)
            Destroy(gameObject);
        Vector3 AuxVector3;
        /* Look at Player*/
        AuxVector3 = new Vector3((PlayerTransform.position.x - transform.position.x), (PlayerTransform.position.y - transform.position.y), (PlayerTransform.position.z - transform.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(AuxVector3), RotantionSpeed * Time.deltaTime);

        /* Move at Player*/
        transform.position += (transform.forward) * MoveSpeed * Time.deltaTime;

    }
    void DestroyNow()
    {
        MapsObjectsSpawnObject.InstantiateMapObjects(1, this.gameObject);
        Destroy(gameObject);
    }
}

