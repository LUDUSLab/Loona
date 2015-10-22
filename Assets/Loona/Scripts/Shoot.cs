using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public GameObject ShootPrefab;
    public float Cooldown;
    private GameObject aux;
    private bool CanIShoot;
  
    void Start()
    {
    }
    public void GerarTiro(Vector2 direction, Vector3 position)
    {
        aux = (GameObject)Instantiate(ShootPrefab) as GameObject;
        //direction.Normalize();
        //direction.Scale(new Vector2(500, 500));
        aux.transform.position = position;
        Vector2 force = new Vector2(10, 10);
        aux.GetComponent<Rigidbody2D>().velocity = direction * 2;
        //aux.GetComponent<Rigidbody2D>().AddForce(force);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GerarTiro(other.transform.position - this.transform.position, this.transform.position);
        GetComponent<Collider2D>().enabled = false;
        Invoke("CanShoot", Cooldown);
    }
    void CanShoot()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
