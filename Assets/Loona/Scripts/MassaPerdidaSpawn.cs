using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Made By JMG
public class MassaPerdidaSpawn : MonoBehaviour {

    [SerializeField] private GameObject massaPerdida;
    private GameObject MassaPerdidaObj;
	private GameObject gosma;
    //private GameObject gosmaReferencePoints;
    //[SerializeField] private float EscalaAPerder = 0.1f;
    //[SerializeField] private float MassaAPerder = 0.1f;
    [SerializeField] private int ForcaImpulso;

    private float i;

	// Use this for initialization
	void Start () {
        //massaPerdida = GameObject.FindGameObjectWithTag("MassaPerdida");
		gosma = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void GerarMassaPerdida(Vector2 direction, Vector3 position)
    {
        //Debug.Log("Instanciou");
        MassaPerdidaObj = (GameObject) Instantiate(massaPerdida);
        direction.Normalize();
        direction.Scale(new Vector2(ForcaImpulso, ForcaImpulso));
        MassaPerdidaObj.transform.position = position;
        MassaPerdidaObj.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);
		// // Modified By JMG RemoverMassaGosma();
    }

	/* // Modified By JMG
	 * private void RemoverMassaGosma()
    {
        gosma.GetComponent<UnityJellySprite>().m_Mass -= MassaAPerder;
        if (gosma.GetComponent<UnityJellySprite>().m_Mass <= 0)
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<FimDeJogo>().Morrer();
        }
    }*/
}
