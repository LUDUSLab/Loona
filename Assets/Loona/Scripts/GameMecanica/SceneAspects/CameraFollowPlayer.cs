using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {
    public float Velocity, minDistance, followDistance, TimeStepUpdate;
    public GameObject target;
    public Vector3 offset;
    public float MaxX,MinX, MaxY,MinY;
    private GameObject MainCamera;
    private float RelativeVelocity;
    private bool CanMove;
    Vector3 targetPos;
    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
        MainCamera = Camera.main.gameObject;
        InvokeRepeating("Follow", 0, TimeStepUpdate);
    }

    // Update is called once per frame
    void Follow()
    {
            Vector3 LimitVectorChecker;

            Vector3 posNoZ = MainCamera.transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            RelativeVelocity = targetDirection.magnitude * Velocity;

            targetPos = MainCamera.transform.position + (targetDirection.normalized * RelativeVelocity * Time.deltaTime);
            LimitVectorChecker = Vector3.Lerp(MainCamera.transform.position, targetPos + offset, 0.25f);
            CheckLimits(LimitVectorChecker);
            if (CanMove)MainCamera.transform.position = Vector3.Lerp(MainCamera.transform.position, targetPos + offset, 0.25f);
    }
    void CheckLimits(Vector3 LimitVectorChecker)
    {
        if ((LimitVectorChecker.x > MaxX) || (LimitVectorChecker.x < MinX))
        {
            CanMove = false;
        }
        else
        {
            if ((LimitVectorChecker.y > MaxY) || (LimitVectorChecker.y < MinY))
            {
                CanMove = false;
            }
            else CanMove = true;
        }
    }
}