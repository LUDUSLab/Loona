using UnityEngine;
using System.Collections;

public class Shotter : MonoBehaviour
{
    private GameObject PlayerController;
    public string PlayerControllerTag = "PlayerController";
    public float TimeToDestroy, ScaleAddedToPlayer;
    public bool HurtAnimation;
    private GameObject player;
    private GameObject PlayerExpressions;
    public float DelayTimeAnimation = 1f;
    private bool AnimationEnabled = true;
    private Vector3 AuxVector3;
    private Transform PlayerTransform;
    public float RotantionSpeed = 50f;
    public float MoveSpeed = 25f;
    public float TimeStepUpdate = 0.0001f;
    // Use this for initialization
    void Start()
    {
        PlayerController = GameObject.FindGameObjectWithTag(PlayerControllerTag);
        player= GameObject.FindGameObjectWithTag("Player");
        PlayerExpressions = GameObject.FindGameObjectWithTag("PlayerExpressions");
        PlayerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(this.CompareTag("Enemy"))
            {
                
                if (HurtAnimation)
                {
                    if (AnimationEnabled)
                    {
                        PlayerController.GetComponent<Crescer>().MassAddUp(player, ScaleAddedToPlayer);
                        PlayerExpressions.GetComponent<Animator>().SetTrigger("Hurt");
                        AnimationEnabled = false;
                        Invoke("SetAnimationEnabled", DelayTimeAnimation);
                    }
                }
                else //eat animation
                {
                    PlayerController.GetComponent<Crescer>().MassAddUp(player, -ScaleAddedToPlayer);
                    if (AnimationEnabled)
                    {
                        PlayerExpressions.GetComponent<Animator>().SetTrigger("Eat");
                        AnimationEnabled = false;
                        Invoke("SetAnimationEnabled", DelayTimeAnimation);
                        InvokeRepeating("Update2", 0f, TimeStepUpdate);
                    }
                }
            }
            Destroy(gameObject);
        }
    }
    private void SetAnimationEnabled()
    {
        AnimationEnabled = true;
    }
    //<!--
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
    //-->
}