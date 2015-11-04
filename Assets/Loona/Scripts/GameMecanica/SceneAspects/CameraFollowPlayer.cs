using UnityEngine;
using System.Collections;

public class CameraFollowPlayer : MonoBehaviour {
    public float Velocity, minDistance, followDistance;
    private GameObject target;
    public Vector3 offset;
    public float MaxX,MinX, MaxY,MinY;
    private GameObject MainCamera;
    private float RelativeVelocity;
    private bool CanMove=true;
	Vector3 targetPos,CameraInitialPosition;
	// Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        targetPos = transform.position;
        MainCamera = Camera.main.gameObject;
        //InvokeRepeating("Follow", 0, TimeStepUpdate);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
            Vector3 LimitVectorChecker;
            Vector3 posNoZ = MainCamera.transform.position;
            posNoZ.z = target.transform.position.z;
            Vector3 targetDirection = (target.transform.position - posNoZ);
		    CameraInitialPosition=MainCamera.transform.position;
            RelativeVelocity = targetDirection.magnitude * Velocity;

            targetPos = MainCamera.transform.position + (targetDirection.normalized * RelativeVelocity * Time.deltaTime);
            LimitVectorChecker = Vector3.Lerp(MainCamera.transform.position, targetPos + offset, 0.25f);
            //CheckLimits(LimitVectorChecker);
			MainCamera.transform.position = CheckLimits (LimitVectorChecker);
		/*if (!CanMove) 
			Invoke (("GoToInitialPosition"), Time.deltaTime);*/
    }
	Vector3 CheckLimits(Vector3 LimitVectorChecker)
    {
        if (LimitVectorChecker.x > MaxX)
        {
			LimitVectorChecker= new Vector3(MaxX,LimitVectorChecker.y,LimitVectorChecker.z);
        }
		if (LimitVectorChecker.x < MinX)
		{
			LimitVectorChecker= new Vector3(MinX,LimitVectorChecker.y,LimitVectorChecker.z);
		}
		if (LimitVectorChecker.y > MaxY)
		{
			LimitVectorChecker= new Vector3(LimitVectorChecker.x,MaxY,LimitVectorChecker.z);
		}
		if (LimitVectorChecker.y < MinY)
		{
			LimitVectorChecker= new Vector3(LimitVectorChecker.x,MinY,LimitVectorChecker.z);
		}
		return LimitVectorChecker;
    }
	void OnTriggerEnter2D(Collider2D other){
		CanMove = false;
	}
	void OnTriggerExit2D( Collider2D cool){

		CanMove = true;
	}
	void OnTriggerStay2D( Collider2D cool){
		CanMove = true;
	}
	void GoToInitialPosition(){
		MainCamera.transform.position = CameraInitialPosition;
	}
	public void SetXlimit(float Xlimit){
		if (Xlimit < 0) {
			MinX = Xlimit;
		} else
			MaxX = Xlimit;
	}
	public void SetYlimit(float Ylimit){
		if (Ylimit < 0) {
			MinY = Ylimit;
		} else
			MaxY = Ylimit;
	}
	public void ResetLimits(){
		MaxX = 60;
		MinX = -60;
		MaxY = 60;
		MinY = -60;
	}
}