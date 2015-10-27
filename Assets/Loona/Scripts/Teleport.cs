using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
    public GameObject TeleportController;
    private string PlayerTag, TeleportTag,ReferencePointTag,CentralPointTag;
    private Vector2 PlayerCurrentPosition, PlayerNextPosition;
    private GameObject[] Teleporters,ReferencePoints;
    private GameObject CentralPoint;
    private int RandomNumber;
    private float CoolDown;
    // Use this for initialization
    void Start () {
        PlayerTag = TeleportController.GetComponent<TeleportController>().PlayerTag;
        TeleportTag = TeleportController.GetComponent<TeleportController>().TeleportTag;
        CentralPointTag = TeleportController.GetComponent<TeleportController>().CentralPointTag;
        CoolDown = TeleportController.GetComponent<TeleportController>().Cooldown;
        Teleporters = GameObject.FindGameObjectsWithTag(TeleportTag);
        Invoke("GetReferentialPoints", 1f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D cool){
        if (cool.tag == PlayerTag)
        {
            DesactivateCollider();
            do
            {
                RandomNumber = (int)Random.Range(0, Teleporters.Length);
            } while (Teleporters[RandomNumber].name == gameObject.name);
            DesactivateDestinationTeleport(Teleporters[RandomNumber]);
            PlayerNextPosition = Teleporters[RandomNumber].transform.position;
            CentralPoint.transform.position = PlayerNextPosition;
            for (int i = 0; i < ReferencePoints.Length; i++)
            {
                ReferencePoints[i].transform.position = PlayerNextPosition;
            } 
            Invoke("ActivateCollider", CoolDown);
            Invoke("ActivateDestinationTeleport", CoolDown);
        }
    }
    void DesactivateCollider()
    {
        GetComponent<Collider2D>().enabled = false;
    }
    void ActivateCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }
    void DesactivateDestinationTeleport(GameObject Teleporter)
    {
        Teleporter.GetComponent<Collider2D>().enabled = false;
        Teleporter.transform.GetComponentInChildren<CircleCollider2D>().enabled = false;
    }
    void ActivateDestinationTeleport()
    {
        Teleporters[RandomNumber].GetComponent<Collider2D>().enabled = true;
        Teleporters[RandomNumber].transform.GetComponentInChildren<CircleCollider2D>().enabled = true;
    }
    void GetReferentialPoints()
    {
        ReferencePoints = GameObject.FindGameObjectsWithTag(PlayerTag);
        CentralPoint = GameObject.FindGameObjectWithTag(CentralPointTag);
    }
}
