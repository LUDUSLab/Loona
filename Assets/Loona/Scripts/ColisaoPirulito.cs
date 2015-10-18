using UnityEngine;
using System.Collections;

public class ColisaoPirulito : MonoBehaviour {

	private GameObject controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlanetaPirulito")
        {
            if(transform.localScale.x > 3.5f)
            {
                Debug.Log("Missao concluida");
            }
        }
		/*if (other.tag == "Enemy") 
		{
			Debug.Log ("era pra destruir");
			if(GetComponent<UnityJellySprite>().m_Mass > other.GetComponent<Rigidbody2D>().mass)
			{
				Debug.Log ("era pra destruir");
				controller.GetComponent<Crescer>().MassAddUp(this.gameObject);
				Destroy(other.transform.parent.gameObject);
			}
		}*/
    }
}
