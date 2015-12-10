using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
    public bool CanIShake = false;
    public float DirectionShakeX;
    public float DirectionShakeY;

    // Use this for initialization
    void Start() {

    }

    void FixedUpdate() {
        if (CanIShake == true)
        {
            StartCoroutine(ShakeTime());

        }
    }
    IEnumerator ShakeTime()
    {
        gameObject.transform.position += new Vector3(DirectionShakeX, DirectionShakeY, 0);
        yield return new WaitForSeconds(0.01f);
        gameObject.transform.position += new Vector3(-1*DirectionShakeX, -1*DirectionShakeY, 0);
        CanIShake = false;
    }

    public void SetTrueCanIShake()
    { 
        CanIShake = true;
    }
}

