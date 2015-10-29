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
    // Use this for initialization
    void Start()
    {
        PlayerController = GameObject.FindGameObjectWithTag(PlayerControllerTag);
        player= GameObject.FindGameObjectWithTag("Player");
        PlayerExpressions = GameObject.FindGameObjectWithTag("PlayerExpressions");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController.GetComponent<Crescer>().MassAddUp(player, ScaleAddedToPlayer);
            if (HurtAnimation)
            {
                if(AnimationEnabled)
                {
                    PlayerExpressions.GetComponent<Animator>().SetTrigger("Hurt");
                    AnimationEnabled = false;
                    Invoke("SetAnimationEnabled", DelayTimeAnimation);
                }
            }
            Destroy(gameObject);
        }
    }

    private void SetAnimationEnabled()
    {
        AnimationEnabled = true;
    }
}