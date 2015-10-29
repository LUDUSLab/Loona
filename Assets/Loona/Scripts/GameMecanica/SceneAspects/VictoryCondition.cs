using UnityEngine;
using System.Collections;

public class VictoryCondition : MonoBehaviour {
    public float TimeToCheckSize;
    private GameObject MissionObjective;
    private GameObject PlayerController;
    private Vector3 MissionObjectiveSize;
    // Use this for initialization
    void Start () {
        MissionObjective = GameObject.FindGameObjectWithTag("MissionObjective");
        PlayerController=  GameObject.FindGameObjectWithTag("PlayerController");
        MissionObjectiveSize = MissionObjective.GetComponent<CircleCollider2D>().bounds.size;
        InvokeRepeating("CompareSize", 1, TimeToCheckSize);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void CompareSize()
    {
        Vector3 PlayerSize = PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize();
        if (MissionObjectiveSize.x > PlayerSize.x) //Tem que comparar pelo tamanho em X deles(diametro)
        {
            MissionObjective.GetComponent<CircleCollider2D>().isTrigger = false;
        }
        else
        {
            MissionObjective.GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
}
