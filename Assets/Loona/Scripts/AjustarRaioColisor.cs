using UnityEngine;
using System.Collections;

public class AjustarRaioColisor : MonoBehaviour {

    private GameObject gosma;

	// Use this for initialization
	void Start () {
       
        //gosma = GameObject.FindGameObjectWithTag("Player");
        //InvokeRepeating("AjustarRaio", 0, 0.001f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //essa funcao vai ficar repetindo para ajustar o raio do colisor proporcionalmente ao peso da gosma
    private void AjustarRaio()
    {
        //raiocolisor = 2 x massa da gosma
        //GetComponent<CircleCollider2D>().radius = gosma.transform.localScale.x/4;
    }
}
