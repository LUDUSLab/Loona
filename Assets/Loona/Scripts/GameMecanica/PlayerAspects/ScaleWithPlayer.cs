using UnityEngine;
using System.Collections;

//Made By JMG
public class ScaleWithPlayer : MonoBehaviour {

    public GameObject PlayerObject;
    public string PlayerObjectTag = "Player";
    public GameObject ReferencePointsObject;
    public string ReferencePointsTag = "ReferencePoints";
    public float DelayTimeFindObject = 0.2f;
    public float DelayTimeUpdate = 0.001f;

    // Use this for initialization
    void Start () {
        PlayerObject = GameObject.FindGameObjectWithTag(PlayerObjectTag);
        Invoke("DelayFindObject", DelayTimeFindObject);
        InvokeRepeating("Update2", DelayTimeFindObject , DelayTimeUpdate);
	}
	
    private void DelayFindObject()
    {
        ReferencePointsObject = GameObject.FindGameObjectWithTag(ReferencePointsTag);
    }

	void Update2 () {
        
        for(int i = 0; i < ReferencePointsObject.transform.childCount; i++)
        {
            ReferencePointsObject.transform.GetChild(i).transform.localScale = PlayerObject.transform.localScale;
        }
	}
}
