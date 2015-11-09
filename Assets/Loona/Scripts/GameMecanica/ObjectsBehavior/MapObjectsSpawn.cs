using UnityEngine;
using System.Collections;

//Made By JMG
public class MapObjectsSpawn : MonoBehaviour
{
    [SerializeField] private int MaxAmountObjects;
    //food = 100, enemy = ?
    [SerializeField] private GameObject ObjectPrefab;
    public float HorizontalMaxCoordinate = 42;
    public float VerticalMaxCoordinate = 21;
    public float HorizontalMinCoordinate = -24;
    public float VerticalMinCoordinate = -21;
    [SerializeField] private string ObjectsParentTag;
    private GameObject ObjectsParentObject;
    private GameObject Object;
    private Vector3 vector3 = new Vector3();
    public GameObject PlanetObject;

    // Use this for initialization
    void Start()
    {
        ObjectsParentObject = GameObject.FindGameObjectWithTag(ObjectsParentTag);
        InstantiateMapObjects(MaxAmountObjects, ObjectPrefab);
    }
    public void InstantiateMapObjects(int amount, GameObject ObjectPrefabParam)
    {
        CircleCollider2D PlanetObjectSize = PlanetObject.GetComponent<CircleCollider2D>();
        float PlanetXMin = PlanetObjectSize.transform.position.x - PlanetObjectSize.radius + 1;
        float PlanetXMax = PlanetObjectSize.transform.position.x + PlanetObjectSize.radius + 1;
        float PlanetYMin = PlanetObjectSize.transform.position.y - PlanetObjectSize.radius + 1;
        float PlanetYMax = PlanetObjectSize.transform.position.y + PlanetObjectSize.radius + 1;

        for (int i = 0; i < amount; i++)
        {
            Object = Instantiate(ObjectPrefab);

            vector3 = new Vector3((int)Random.Range(HorizontalMinCoordinate, HorizontalMaxCoordinate),
                (int)Random.Range(VerticalMinCoordinate, VerticalMaxCoordinate),
                0);
            while (true)
            {   
                if((vector3.x < PlanetXMin || vector3.x > PlanetXMax) && (vector3.y < PlanetYMin || vector3.y > PlanetYMax))
                {
                    if (vector3.x != 0 && vector3.y != 0)
                    {
                        break;
                    }
                }
                vector3 = new Vector3((int)Random.Range(HorizontalMinCoordinate, HorizontalMaxCoordinate),
                (int)Random.Range(VerticalMinCoordinate, VerticalMaxCoordinate),
                0);
            }




            /*vector3.x = (int)Random.Range(HorizontalMinCoordinate, HorizontalMaxCoordinate);
            while (vector3.x == 0)
            {
                vector3.x = (int)Random.Range(HorizontalMinCoordinate, HorizontalMaxCoordinate);
            }
            vector3.y = (int)Random.Range(VerticalMinCoordinate, VerticalMaxCoordinate);
            while (vector3.y == 0)
            {
                vector3.y = (int)Random.Range(VerticalMinCoordinate, VerticalMaxCoordinate);
            }*/
            //vector3.z = 0;
            Object.transform.position = vector3;
            Object.transform.parent = ObjectsParentObject.transform;
        }
    }
}
