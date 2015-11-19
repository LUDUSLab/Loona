using UnityEngine;
using System.Collections;

public class CandyEater : MonoBehaviour
{
    private Transform PlayerTransform;
    public float TimeStepUpdate, MoveSpeed, RotantionSpeed;
    public float TimeToDestroy = 1f;
    // Use this for initialization
    void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("ColisorPlayer").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ColisorPlayer")
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            GetComponent<CircleCollider2D>().enabled = false;
            Invoke("DestroyNow", TimeToDestroy);
            InvokeRepeating("Follow", 0, TimeStepUpdate);

        }

        //if( anim_Animator.GetCurrentAnimatorStateInfo(0).IsName("MyAnimationName"))
    }
    void Follow()
    {
        Vector3 AuxVector3;
        /* Look at Player*/
        AuxVector3 = new Vector3((PlayerTransform.position.x - transform.position.x), (PlayerTransform.position.y - transform.position.y), (PlayerTransform.position.z - transform.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(AuxVector3), RotantionSpeed * Time.deltaTime);

        /* Move at Player*/
        transform.position += (transform.forward) * MoveSpeed * Time.deltaTime;
    }
    void DestroyNow()
    {
        Destroy(gameObject);
    }
}

