using UnityEngine;
using System.Collections;

public class Tiro : MonoBehaviour {

    private Vector2 direction;
    private GameObject gosma;
	//public float movimentPorcentReduction;
	//private float down;
	// Use this for initialization
	void Start () {
        //Debug.Log("startTiro!1");
        gosma = GameObject.FindGameObjectWithTag("Player");
	}
	// Update is called once per frame
	void Update () {
		//down = -1 * gosma.transform.lossyScale.x * movimentPorcentReduction / 100;
	}
    public void Atirar(float horizontal, float vertical, ForceMode2D mode)
    {
        //Debug.Log("atirou!1");
        //<!-- mesmo vetor de direcao do toque
        direction = new Vector2(horizontal, vertical);
        //-->
        //<!-- lanca o projetil do centro para a direcao do toque
        GetComponent<MassaPerdidaSpawn>().GerarMassaPerdida(direction, gosma.transform.position);
        //-->
       // GetComponent<Crescer>().MassAddUp(gosma,movimentPorcentReduction);             
    }
}
