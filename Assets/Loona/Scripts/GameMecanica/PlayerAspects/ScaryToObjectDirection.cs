using UnityEngine;
using System.Collections;

public class ScaryToObjectDirection : MonoBehaviour {

    public string ObjectTag = "Enemy";
    public GameObject PlayerExpressions;
    public string ScaryLeftTrigger = "Enemy_Left";
    public string ScaryRightTrigger = "Enemy_Right";

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(ObjectTag))
        {
            if(other.transform.position.x > this.transform.position.x)
            {
                PlayerExpressions.GetComponent<Animator>().SetTrigger(ScaryRightTrigger);
                Debug.Log("scaryright");
            }
            else
            {
                PlayerExpressions.GetComponent<Animator>().SetTrigger(ScaryLeftTrigger);
                Debug.Log("scaryleft");
            }
        }
    }
}
