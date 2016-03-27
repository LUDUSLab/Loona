using UnityEngine;
using System.Collections;

public class ArrowAtivation : MonoBehaviour {
    public GameObject Arrow;
    public float TimeToCheckSize;
    public float ScaleOffset;
    private GameObject MissionObjective;
    private GameObject PlayerController;
    private Vector3 MissionObjectiveSize;

    // Use this for initialization
    void Start () {
        MissionObjective = GameObject.FindGameObjectWithTag("MissionObjective");
        PlayerController = GameObject.FindGameObjectWithTag("PlayerController");
        MissionObjectiveSize = MissionObjective.GetComponent<CircleCollider2D>().bounds.size;
        PlayerController.GetComponent<Crescer>().MaxSize = MissionObjectiveSize.x + ScaleOffset; // Tamanho máximo
        InvokeRepeating("CompareSize", 1, TimeToCheckSize);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 PlayerSize = PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize();
        if (MissionObjectiveSize.x + ScaleOffset > PlayerSize.x) //Tem que comparar pelo tamanho em X deles(diametro)
        {
            MissionObjective.GetComponent<CircleCollider2D>().isTrigger = false;


        }
        else
        {
            MissionObjective.GetComponent<CircleCollider2D>().isTrigger = true;
            Arrow.SetActive(true);
        }

    }
}
