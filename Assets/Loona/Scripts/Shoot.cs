using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public GameObject shoot;
	private GameObject aux;
	void Start () {
	}
	public void GerarTiro(Vector2 direction, Vector3 position)
	{
		aux = (GameObject) Instantiate(shoot) as GameObject;
		//direction.Normalize();
		//direction.Scale(new Vector2(500, 500));
		aux.transform.position = position;
		Vector2 force = new Vector2 (10, 10);
		aux.GetComponent<Rigidbody2D> ().velocity = direction*2;
		//aux.GetComponent<Rigidbody2D>().AddForce(force);
	}
}
