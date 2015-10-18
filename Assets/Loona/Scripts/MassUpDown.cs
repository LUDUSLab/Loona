using UnityEngine;
using System.Collections;

public class MassUpDown : MonoBehaviour {
	[SerializeField] private string Enemy,Food;
	[SerializeField] private float EnemyAdd,FoodAdd;
	private GameObject Controller;
	private GameObject Player;
    private int clockCamera = 0;
	
	void Start () {
		Controller = GameObject.FindGameObjectWithTag ("GameController");
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
    void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.gameObject.tag == Food)
        {
		    Controller.GetComponent<Crescer>().MassAddUp(Player,FoodAdd);
            //Controller.GetComponent<AjustarCamera>().Contar(1);
        }
        else
        {
		    if (other.gameObject.tag == Enemy)
            {
			    Controller.GetComponent<Crescer>().MassAddUp(Player,EnemyAdd);
                //Controller.GetComponent<AjustarCamera>().Contar(-1);
            }
        }
    }
}
