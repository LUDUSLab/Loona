using UnityEngine;
using System.Collections;

public class ColisorPirulito : MonoBehaviour {

	[SerializeField] private GameObject player;
	[SerializeField] private float minimunScaleLoona = 3;
	// Use this for initialization
	void Start () {
		// Modified By JMG
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log ("colidiu com pirulito");
		//Modified By JMG 

		if (other.gameObject.tag == "Player" && player.transform.localScale.x >= minimunScaleLoona)
		{
			Debug.Log("Missao concluida");
			Time.timeScale = 0;
		}
	}
}
