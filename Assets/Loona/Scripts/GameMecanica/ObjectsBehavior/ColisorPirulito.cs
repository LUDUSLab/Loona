using UnityEngine;
using System.Collections;

public class ColisorPirulito : MonoBehaviour {
    public float TimeStepUpdate, MoveSpeed, RotantionSpeed;
    public AnimationClip VictoryAnimation;
    [SerializeField] private Animator AnimatorTarget;
    private GameObject controller;
    private Transform PlayerTransform;
    private Vector3 ScalePlayer;
    public float DelayTimeAnimation = 6f;
    public float DelayTimeVictory = 1f;
    private bool AnimationEnabled = true;
	public bool IsMenuAnimation = false;
    // Use this for initialization
    void Start () {
        // Modified By JMG
        PlayerTransform = GameObject.FindGameObjectWithTag("ColisorPlayer").transform;
        AnimatorTarget = GameObject.FindGameObjectWithTag ("PlayerExpressions").GetComponent<Animator>();
        controller = GameObject.Find("Pivo");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
            if(AnimationEnabled)
            {
                AnimatorTarget.SetTrigger("Collision");
                AnimationEnabled = false;
                Invoke("SetAnimationEnabled", DelayTimeAnimation);
            }
            
        }

    }

    private void SetAnimationEnabled()
    {
        AnimationEnabled = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Victory();
            AnimatorTarget.SetTrigger("Eat");
            GetComponent<CircleCollider2D>().enabled = false;
            Time.timeScale = 0.5f;
            AnimatorTarget.SetTrigger("Eat");
            Invoke("CallVictory", DelayTimeVictory);
        }
		else if (other.gameObject.tag == "ColisorPlayer")
		{
			Victory();
			AnimatorTarget.SetTrigger("Eat");
			GetComponent<CircleCollider2D>().enabled = false;
			Time.timeScale = 0.5f;
			AnimatorTarget.SetTrigger("Eat");
			Invoke("CallVictory", DelayTimeVictory);
		}
    }
    public void Victory() {
        //Invoke("CallVictory", VictoryAnimation.length);
        //InvokeRepeating("Follow", 0, TimeStepUpdate);
    }
     void CallVictory(){
        if (!IsMenuAnimation) {
			Time.timeScale = 0;
			controller.GetComponent<Animator> ().SetTrigger ("Victory");
		}
        Destroy(gameObject);
    }
    void Follow()
    {
        Vector3 AuxVector3;
        /* Look at Player*/
        AuxVector3 = new Vector3((PlayerTransform.position.x - transform.position.x), (PlayerTransform.position.y - transform.position.y), ( transform.position.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(AuxVector3), RotantionSpeed * Time.deltaTime);

        /* Move at Player*/
        transform.position += (transform.forward) * MoveSpeed * Time.deltaTime;
    }
}
