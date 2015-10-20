using UnityEngine;
using System.Collections;

public class SpawnOnRandomPoints : MonoBehaviour {
    public GameObject ObjectToSpawn;
    public string SpawnPointsTag;
    public int InitialQuantityToSpawn;
    public int ConstantQuantity;
    public string ObjectParentTag;
    public float TimeToCheckSons;
    private GameObject[] SpawnPoints;
    private  GameObject ObjectParent;
    // Use this for initialization
    void Start () {
        SpawnPoints = GameObject.FindGameObjectsWithTag(SpawnPointsTag);
        ObjectParent = GameObject.FindGameObjectWithTag(ObjectParentTag);
        for (int i=0;i< InitialQuantityToSpawn; i++)
        {
            Spawn();
        }
        InvokeRepeating("CheckQuantity", 0, TimeToCheckSons);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void Spawn()
    {
        GameObject InstatiatedObject;
        int RandomNumber = (int)Random.Range(0, SpawnPoints.Length);
        Vector2 PositionToSpawn = SpawnPoints[RandomNumber].transform.position;
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles= new Vector3(0, 0, Random.Range(0,360));
        InstatiatedObject = Instantiate(ObjectToSpawn);
        InstatiatedObject.transform.position = PositionToSpawn;
        InstatiatedObject.transform.rotation = rotation;
        InstatiatedObject.transform.parent = ObjectParent.transform;
    }
    void CheckQuantity()
    {
        int CurrentChildren = ObjectParent.transform.childCount;
        int NumberToSpawn = ConstantQuantity - CurrentChildren;
        for(int i= 0; i < NumberToSpawn;i++) { 
            Spawn();
        }
    }
}
