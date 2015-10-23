using UnityEngine;
using System.Collections;

public class DestroyOnContact : MonoBehaviour {
    public bool Idie, Udie;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Idie)
        {
            Destroy(gameObject);
        }
        if (Udie)
        {
            Destroy(other.gameObject);
        }
    }
}
