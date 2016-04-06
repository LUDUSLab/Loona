using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour {

    // Use this for initialization

    public GameObject target;


    void Start () {
  
	}
    // Update is called once per frame
	void Update () {
        transform.position = target.transform.position;
	}
}
