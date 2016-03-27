using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {
    public Transform target,arrow;
    private Vector3 direction;
    private float angle;
    private Quaternion rotation;
    public float rotationSpeed;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("MissionObjective").transform;
        arrow = GameObject.FindGameObjectWithTag("Player").transform;
    }
     void FixedUpdate()
    { 
        direction = target.position-arrow.transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        //Debug.Log(direction)
    }
}
