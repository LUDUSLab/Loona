using UnityEngine;
using System.Collections;

public class ObstaclesMoviment : MonoBehaviour {
    public float xRange, yRange;
  
    // Use this for initialization
    void Start () {
    Vector2 MovimentForce = new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange));
    GetComponent<Rigidbody2D>().AddForce(MovimentForce);
    }
	
	// Update is called once per frame
	void Update () {

    }
}
