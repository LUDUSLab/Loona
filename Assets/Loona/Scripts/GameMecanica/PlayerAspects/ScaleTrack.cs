using UnityEngine;
using System.Collections;

public class ScaleTrack : MonoBehaviour {
    private Vector3 PlayerSize;
    private GameObject Player;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerSize = Player.GetComponent<MeshRenderer>().bounds.size;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public Vector3 CheckPlayerSize()
    {
        PlayerSize = Player.GetComponent<MeshRenderer>().bounds.size;
        return PlayerSize;
    }
}
