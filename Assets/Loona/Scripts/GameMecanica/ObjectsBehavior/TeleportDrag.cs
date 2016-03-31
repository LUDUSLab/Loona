using UnityEngine;
using System.Collections;

public class TeleportDrag : MonoBehaviour {
    private GameObject PullOBJ;
    public float ForceSpeed;
    public float DelayTime = 0.5f;

    public void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == ("Player"))
        {
            PullOBJ = coll.gameObject;

            PullOBJ.transform.position = Vector3.MoveTowards
                (PullOBJ.transform.position,
                 transform.position,
                 ForceSpeed * Time.deltaTime);

            GetComponentInParent<Animator>().SetBool("PlaySound", true);
            Invoke("SetPlaySoundFalse", DelayTime);
            
        }
    }
    private void SetPlaySoundFalse()
    {
        GetComponentInParent<Animator>().SetBool("PlaySound", false);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
