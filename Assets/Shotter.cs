using UnityEngine;
using System.Collections;

public class Shotter : MonoBehaviour
{
    private GameObject controller;
    public float TimeToDestroy, ScaleAddedToPlayer;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = GameObject.FindGameObjectWithTag("GameController");
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
            Destroy(gameObject);
        }
    }
}