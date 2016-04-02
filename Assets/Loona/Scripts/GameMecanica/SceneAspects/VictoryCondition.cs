using UnityEngine;
using System.Collections;

public class VictoryCondition : MonoBehaviour {
    public float TimeToCheckSize;
	public float ScaleOffset;
	private bool WinningCondition=false;
    private GameObject MissionObjective;
    private GameObject PlayerController;
	private GameObject PlayerExpressions;
	private GameObject FullLoona;
    private Vector3 MissionObjectiveSize;
	private Vector3 PlayerSize;
    public bool Arrow;
    // Use this for initialization
    void Start () {
        MissionObjective = GameObject.FindGameObjectWithTag("MissionObjective");
        PlayerController=  GameObject.FindGameObjectWithTag("PlayerController");
		PlayerExpressions = GameObject.FindGameObjectWithTag ("PlayerExpressions");
		FullLoona = GameObject.Find ("Loona_Cheia");
        MissionObjectiveSize = MissionObjective.GetComponent<CircleCollider2D>().bounds.size;
		PlayerController.GetComponent<Crescer> ().MaxSize = MissionObjectiveSize.x + ScaleOffset; // Tamanho máximo
        InvokeRepeating("CompareSize", 0.2f, TimeToCheckSize);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void CompareSize()
    {
        PlayerSize = PlayerController.GetComponent<ScaleTrack>().CheckPlayerSize();
		if (MissionObjectiveSize.x + ScaleOffset> PlayerSize.x) //Tem que comparar pelo tamanho em X deles(diametro)
        {
            MissionObjective.GetComponent<CircleCollider2D>().isTrigger = false;
			FullLoona.GetComponent<Animator> ().enabled = false;
			SpriteRenderer[] ChildSprite = FullLoona.transform.GetComponentsInChildren<SpriteRenderer> ();
			for (int i = 0; i < ChildSprite.Length; i++)
				ChildSprite [i].enabled = false;
			PlayerExpressions.GetComponent<Animator> ().enabled = true;
			PlayerExpressions.GetComponent<SpriteRenderer> ().enabled = true;

            Arrow = false;
        }
        else
        {
			if (!WinningCondition) {
				MissionObjective.GetComponent<CircleCollider2D> ().isTrigger = true;
				SpriteRenderer[] ChildSprite = FullLoona.transform.GetComponentsInChildren<SpriteRenderer> ();
				for (int i = 0; i < ChildSprite.Length; i++)
					ChildSprite [i].enabled = true;
				FullLoona.GetComponent<Animator> ().enabled = true;
				PlayerExpressions.GetComponent<Animator> ().enabled = false;
				PlayerExpressions.GetComponent<SpriteRenderer> ().enabled = false;
				Arrow = true;
			}
        }
    }
	public bool GetWinningCurrentCondition(){
		return this.WinningCondition;
	}
	public void SetWinningCondition(){
		WinningCondition = true;
	}
	public bool CanStillGroll(){
		if (PlayerSize.x < MissionObjectiveSize.x + 2 * ScaleOffset) { // Tamanho para comer Mission objective igual a MissionObjectiveSize.x + ScaleOffset, Para comer ainda bombons MissionObjectiveSize.x + 2*ScaleOffset
			return true;
		} else
			return false;
	}
}