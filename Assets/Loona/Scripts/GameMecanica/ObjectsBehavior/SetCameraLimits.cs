using UnityEngine;
using System.Collections;

public class SetCameraLimits : MonoBehaviour {
	public bool SetX, SetY;
    private float Limit;
	// Use this for initialization
	void Start () {
 
    }
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "MainCamera")
        {
            
            //ContactPoint2D contact = other.contacts[0];
            if (SetX)
            {
                Camera.main.GetComponent<CameraFollowPlayer>().SetXlimit(other.transform.position.x);
            }
            if (SetY)
            {
                Camera.main.GetComponent<CameraFollowPlayer>().SetYlimit(other.transform.position.y);
            }
            other.GetComponent<CameraScaleToPlayer>().SetCanAjust(false);
            other.GetComponent<ColliderScaleToCamera>().SetCanAjust(false);
        }
	}
	void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "MainCamera")
        {
            Camera.main.GetComponent<CameraFollowPlayer>().ResetLimits();
            other.GetComponent<CameraScaleToPlayer>().SetCanAjust(true);
            other.GetComponent<ColliderScaleToCamera>().SetCanAjust(true);
        }
    }
}
