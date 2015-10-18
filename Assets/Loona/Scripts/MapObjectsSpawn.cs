using UnityEngine;
using System.Collections;

//Made By JMG
public class MapObjectsSpawn : MonoBehaviour
{
    [SerializeField] private int MaxAmountObjects;
    //food = 100, enemy = ?
    [SerializeField] private GameObject ObjectPrefab;
    [SerializeField] private float HorizontalMaxCoordinate = 30;
    [SerializeField] private float VerticalMaxCoordinate = 15;
    [SerializeField] private string ObjectsParentTag;
    private GameObject ObjectsParentObject;
    private GameObject Object;
    private Vector3 vector3 = new Vector3();

    // Use this for initialization
    void Start()
    {
        ObjectsParentObject = GameObject.FindGameObjectWithTag(ObjectsParentTag);
        InstantiateMapObjects(MaxAmountObjects, ObjectPrefab);
    }
    public void InstantiateMapObjects(int amount, GameObject ObjectPrefabParam)
    {
        for (int i = 0; i < amount; i++)
        {
            Object = Instantiate(ObjectPrefabParam);

            vector3.x = (int)Random.Range(-HorizontalMaxCoordinate, HorizontalMaxCoordinate);
            while (vector3.x == 0)
            {
                vector3.x = (int)Random.Range(-HorizontalMaxCoordinate, HorizontalMaxCoordinate);
            }
            vector3.y = (int)Random.Range(-VerticalMaxCoordinate, VerticalMaxCoordinate);
            while (vector3.y == 0)
            {
                vector3.y = (int)Random.Range(-VerticalMaxCoordinate, VerticalMaxCoordinate);
            }
            vector3.z = 0;
            Object.transform.position = vector3;
            Object.transform.parent = ObjectsParentObject.transform;
        }
    }
}
