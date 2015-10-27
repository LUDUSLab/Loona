using UnityEngine;
using System.Collections;

public class TeleportDrag : MonoBehaviour {
    public GameObject PullOBJ;
    public float ForceSpeed;

    public void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == ("Player"))
        {
            PullOBJ = coll.gameObject;

            PullOBJ.transform.position = Vector3.MoveTowards
                (PullOBJ.transform.position,
                 transform.position,
                 ForceSpeed * Time.deltaTime);
        }
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
