using UnityEngine;
using System.Collections;

public class AjustarCamera : MonoBehaviour {

    private float time = 0.001f;
    private GameObject gosma;
    private GameObject mainCamera;
    private Vector3 PlayerPosition2D;
    private int clockCamera = 0;
    private float CameraZ;
    // Use this for initialization
    void Start ()
    {
        gosma = GameObject.FindGameObjectWithTag("Player");
        CameraZ = Camera.main.transform.position.z;
        InvokeRepeating("Update2", 0, time);
	}
	
	// Update is called once per time
	private void Update2 ()
    {
        PlayerPosition2D = gosma.transform.position;
        PlayerPosition2D = new Vector3(PlayerPosition2D.x, PlayerPosition2D.y, CameraZ);
        Camera.main.transform.position = PlayerPosition2D;

    }
}
