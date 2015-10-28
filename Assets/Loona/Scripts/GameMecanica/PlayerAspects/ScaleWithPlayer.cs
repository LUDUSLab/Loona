using UnityEngine;
using System.Collections;

//Made By JMG
public class ScaleWithPlayer : MonoBehaviour {

    private GameObject player;
    private Vector3 vector3 = new Vector3();

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Update2", 0 , 0.001f);
	}
	
	// Update is called once per frame
	void Update2 () {
        //vector3 = transform.position;
        transform.localScale = player.transform.localScale;
        //transform.position = vector3;
	}
}
