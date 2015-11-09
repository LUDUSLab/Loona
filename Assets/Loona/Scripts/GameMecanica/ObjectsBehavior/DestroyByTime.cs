using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public float TimeToDestroy;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void StartDestroying()
    {
        Invoke("DestroyBy", TimeToDestroy);
    }

    void DestroyBy()
    {
        Destroy(gameObject);
    }
}
