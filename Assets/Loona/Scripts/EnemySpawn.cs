using UnityEngine;
using System.Collections;

//Made By JMG
public class EnemySpawn : MonoBehaviour
{

    [SerializeField]
    private int maxCount = 10;
    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject enemys;
    private GameObject enemyObject;
    private Vector3 vector3 = new Vector3();
    [SerializeField]
    private float xMax = 30;
    [SerializeField]
    private float yMax = 15;
    private string tagEnemys = "Enemys";

    // Use this for initialization
    void Start()
    {
        enemys = GameObject.FindGameObjectWithTag(tagEnemys);
        for (int i = 0; i < maxCount; i++)
        {
            enemyObject = Instantiate(enemyPrefab);

            //comidaObjeto.transform.SetParent(comidas.transform.parent);
            vector3.x = (int)Random.Range(-xMax, xMax);
            while (vector3.x == 0)
            {
                vector3.x = (int)Random.Range(-xMax, xMax);
            }
            vector3.y = (int)Random.Range(-yMax, yMax);
            while (vector3.y == 0)
            {
                vector3.y = (int)Random.Range(-yMax, yMax);
            }
            vector3.z = 0;
            enemyObject.transform.position = vector3;
            enemyObject.transform.parent = enemys.transform;
        }
    }
}
