using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
    public string PlayerTag, TeleportTag,ReferencePointTag,CentralPointTag;
    private Vector2 PlayerCurrentPosition, PlayerNextPosition;
    private GameObject[] Teleporters,ReferencePoints;
    private GameObject CentralPoint;
    private int RandomNumber;
    public Vector2 Teste;
    public GameObject Player;
    public float CoolDown;
    // Use this for initialization
    void Start () {
        Teleporters = GameObject.FindGameObjectsWithTag(TeleportTag);
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D cool){
        if (cool.tag == PlayerTag)
        {
            RandomNumber = (int)Random.Range(0, Teleporters.Length);
            ReferencePoints = GameObject.FindGameObjectsWithTag(ReferencePointTag);
            CentralPoint = GameObject.FindGameObjectWithTag(CentralPointTag);
            PlayerNextPosition = Teleporters[RandomNumber].transform.position;
            DesactivateDestinationTeleport(Teleporters[RandomNumber]);
            StartCoroutine(ActivateDestinationTeleport(Teleporters[RandomNumber]));
            CentralPoint.transform.position = PlayerNextPosition;
            for (int i = 0; i < ReferencePoints.Length; i++)
            {
                ReferencePoints[i].transform.position = PlayerNextPosition;
            }
            DesactivateCollider();
            Invoke("ActivateCollider", CoolDown);
            
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
    }
    IEnumerator ActivateDestinationTeleport(GameObject Teleporter)
    {
        Teleporter.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(CoolDown);
    }
}
