using UnityEngine;
using System.Collections;

public class Shotter : MonoBehaviour
{
    private GameObject controller;
    public float TimeToDestroy, ScaleAddedToPlayer;
    private GameObject player;
    private GameObject PlayerExpressions;
    // Use this for initialization
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
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
            controller.GetComponent<Crescer>().MassAddUp(player, ScaleAddedToPlayer);
            PlayerExpressions.GetComponent<Animator>().SetTrigger("Hurt");
            Destroy(gameObject);
        }
    }
}