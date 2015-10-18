using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Crescer : MonoBehaviour {
	//[SerializeField] private float ScaleAdd,ScaleDown,ScaleDownMove;
	public GameObject Player;
	public int Interactions;
	//public GameObject Camera;
	private GameObject controller;
    private Vector3 SUp, SDown,SDownMove;
	public float MaxSize;// Modified By JMG maxscale
	private bool GrowLoop,InteractionsController;
	//public int Interactions;
	private int InteractionsCounter;
	void Start () {
		//SUp = new Vector3 (ScaleAdd,ScaleAdd, 1);
		//SDown = new Vector3 (ScaleDown, ScaleDown, 1);
		//SDownMove = new Vector3 (ScaleDownMove,ScaleDownMove,1);
		Player = GameObject.FindGameObjectWithTag("Player");
		controller = GameObject.FindGameObjectWithTag ("GameController");
	}
	public void MassAddUp(GameObject Player,float ScaleAdd){
		// Modified By JMG if (Player.GetComponent<UnityJellySprite> ().m_Mass < MaxSize) {
		if(Player.transform.localScale.x < MaxSize)
		{
			iTween.ScaleAdd(Player,new Vector3 (ScaleAdd,ScaleAdd,1),1f);
			//Camera.main.orthographicSize = Camera.main.orthographicSize + ScaleAdd/2;
		}
		if(Player.gameObject.transform.localScale.x <= 0.2)
		{
			controller.GetComponent<FimDeJogo>().Morrer();
		}


	//void GrowPlis(){
		// Modified By JMG Player.GetComponent<UnityJellySprite> ().m_Mass += MassAdd/Interactions;
		//Player.gameObject.transform.localScale += SUp;
		//Camera.main.orthographicSize = Camera.main.orthographicSize + ScaleAdd;
		//GrowLoop=true;
		//InteractionsCounter++;
		//if (InteractionsCounter >= Interactions) {
		//InteractionsController=false;
		//}
	//}
}
}