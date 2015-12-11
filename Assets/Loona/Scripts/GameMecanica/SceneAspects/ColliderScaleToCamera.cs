using UnityEngine;
using System.Collections;

public class ColliderScaleToCamera : MonoBehaviour {
    private bool CanAjust = true;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate() {
        if (CanAjust)
        {
            SetBoxCollider();
        }
    }
	void SetBoxCollider(){
        /*float height =  Camera.main.orthographicSize;
		float width = height * Camera.main.aspect;*/
        float height = 2* Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;
        GetComponent<BoxCollider2D> ().size = new Vector2 (width, height);
	}
    public void SetCanAjust(bool Ajust)
    {
        CanAjust = Ajust;
    }
}