using UnityEngine;
using System.Collections;

public class ScaleTrack : MonoBehaviour {
    private Vector3 PlayerSize;
    private GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("ColisorPlayer");
        PlayerSize = Player.GetComponent<CircleCollider2D>().bounds.size;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public Vector3 CheckPlayerSize()
    {
        PlayerSize = Player.GetComponent<CircleCollider2D>().bounds.size;
        return PlayerSize;
    }
}
