using UnityEngine;
using System.Collections;

public class VictoryCondition : MonoBehaviour {
    public float TimeToCheckSize;
	public float ScaleOffset;
	private bool WinningCondition=false;
    private GameObject MissionObjective;
    private GameObject PlayerController;
    private Vector3 MissionObjectiveSize;
    public GameObject Arrow;
    // Use this for initialization
    void Start () {
        MissionObjective = GameObject.FindGameObjectWithTag("MissionObjective");
        PlayerController=  GameObject.FindGameObjectWithTag("PlayerController");
        MissionObjectiveSize = MissionObjective.GetComponent<CircleCollider2D>().bounds.size;
		PlayerController.GetComponent<Crescer> ().MaxSize = MissionObjectiveSize.x + ScaleOffset; // Tamanho máximo
        InvokeRepeating("CompareSize", 1, TimeToCheckSize);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void CompareSize()
    {
        Vector3 PlayerSize = PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize();
		if (MissionObjectiveSize.x + ScaleOffset> PlayerSize.x) //Tem que comparar pelo tamanho em X deles(diametro)
        {
            MissionObjective.GetComponent<CircleCollider2D>().isTrigger = false;
			WinningCondition = false;
            Arrow.SetActive(false);
        }
        else
        {
            MissionObjective.GetComponent<CircleCollider2D>().isTrigger = true;
			WinningCondition = true;
            Arrow.SetActive(true);

        }
    }
	public bool GetWinningCurrentCondition(){
		return this.WinningCondition;
	}
}
