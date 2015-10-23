using UnityEngine;
using System.Collections;

//Made by JMG
public class Movimentacao : MonoBehaviour {

    private Vector2 direcao;
    [SerializeField] private int ForcaImpulso;
    private GameObject gosma;
    private GameObject RefPoints;
	private GameObject LostMass;
	[SerializeField] private string LostMassTag = "MassaPerdida";
	[SerializeField] private string PlayerTag = "Player";
	[SerializeField] private string ReferencePointsTag = "ReferencePoints";
	//[SerializeField] private string Controller = "GameController";
	//public float movimentPorcentReduction;

    // Use this for initialization
    void Start () {
        Invoke("GetRefPoints", 0.1f);
        gosma = GameObject.FindGameObjectWithTag(PlayerTag);
		LostMass = GameObject.FindGameObjectWithTag (LostMassTag);
		//GameController = GameObject.FindGameObjectWithTag (Controller);
    }
    public void Mover(float horizontal, float vertical, ForceMode2D mode)
    {
        direcao = new Vector2(-horizontal, -vertical);
        direcao.Normalize();
        direcao.Scale(new Vector2(ForcaImpulso, ForcaImpulso));
        // impulsionando o objeto pra direcao oposta
        for(int i = 0; i < RefPoints.transform.childCount; i++)
        {
			//GameController.GetComponent<Crescer>().MassAddUp(gosma,movimentPorcentReduction);
			RefPoints.transform.GetChild(i).GetComponent<Rigidbody2D>().AddForce(direcao, ForceMode2D.Impulse);


        }
		//
		/*for(int i = 1; i < RefPoints.transform.childCount; i++)
		{
			Physics2D.IgnoreCollision(RefPoints.transform.GetChild(i).GetComponent<CircleCollider2D>(), LostMass.GetComponent<CircleCollider2D>());
		}*/
        //RefPoints.GetComponentInChildren<Rigidbody2D>().AddForce(direcao, ForceMode2D.Impulse);
        //gosma.GetComponent<UnityJellySprite>().AddForce(direcao);
    }
    void GetRefPoints()
    {
        RefPoints = GameObject.FindGameObjectWithTag(ReferencePointsTag);
    }
}
