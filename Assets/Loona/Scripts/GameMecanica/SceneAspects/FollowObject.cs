using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {
    public bool SearchByTag;
    public string TagToBeFollowed;
    public GameObject ToFollow;
    public float MoveSpeed, RotationSpeed;
    public float TimeStepUpdate;
    public bool IsCamera, IsZStatic, Rotate;
    private float ObjectZ;
    public GameObject Hunter;
    // Use this for initialization
    void Start () {
        if(SearchByTag) ToFollow = GameObject.FindGameObjectWithTag(TagToBeFollowed);
        if (IsCamera) Hunter = Camera.main.gameObject;
        ObjectZ = Hunter.transform.position.z;
        InvokeRepeating("Follow", 0, TimeStepUpdate);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void Follow()
    {
        Vector3 AuxVector3;
        /* Look at Player*/
        //Calculating On X axis:
        float Xposition = ToFollow.transform.position.x - Hunter.transform.position.x;
        //Calculating On Y axis:
        float Yposition = ToFollow.transform.position.y - Hunter.transform.position.y;
        //Calculating On Z axis:
        float Zposition = ToFollow.transform.position.z - Hunter.transform.position.z;
        //Vector 3 of the shortest distance
        if (!IsZStatic) AuxVector3 = new Vector3(Xposition, Yposition, Zposition);
        else AuxVector3 = new Vector3(Xposition, Yposition, ObjectZ);

        //Rotation Transform
         Hunter.transform.rotation = Quaternion.Slerp(Hunter.transform.rotation, Quaternion.LookRotation(AuxVector3), RotationSpeed * Time.deltaTime);
        /* Move at Player*/
        Hunter.transform.position += (Hunter.transform.forward) * MoveSpeed * Time.deltaTime;
    }
}
