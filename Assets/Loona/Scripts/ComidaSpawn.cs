using UnityEngine;
using System.Collections;

//Made By JMG
public class ComidaSpawn : MonoBehaviour
{
    [SerializeField] private int MaxAmountObjects = 100;
    [SerializeField] private GameObject ObjectPrefab;
    //private GameObject FoodsObject;
    private GameObject Object;
    private Vector3 vector3 = new Vector3();
    [SerializeField] private float HorizontalMaxCoordinate = 30;
    [SerializeField] private float VerticalMaxCoordinate = 15;
    //[SerializeField] private string FoodsTag = "ComidasGordurosas";

    // Use this for initialization
    void Start()
    {
        //FoodsObject = GameObject.FindGameObjectWithTag(FoodsTag);
        InstantiateFoodObjects(MaxAmountObjects);

    }
    public void InstantiateFoodObjects(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Object = Instantiate(ObjectPrefab);

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
            //Object.transform.parent = FoodsObject.transform;
        }
    }
}
