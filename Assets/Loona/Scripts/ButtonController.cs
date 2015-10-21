using UnityEngine;
using System.Collections;
using UnityEngine.UI; 
public class ButtonController : MonoBehaviour {
	public GameObject [] ButtonsHideAppear;
	public string OnTrigger, OffTrigger;
	public Sprite ButtonON, ButtonOFF;
	public int Speed;
	public GameObject ButtonToChange;
    public float DelayTimeToLoad;
    public string GameSceneName;
	private bool Active;
	private Animator Animation;
	// Use this for initialization
	void Start () {
		Active = false;
		Animation = GameObject.Find ("Pivo").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Appear(){
		if (!Active) {
			for (int i= 0; i< ButtonsHideAppear.Length; i++) {
				ButtonsHideAppear [i].GetComponent<Animator> ().speed= Speed;
				ButtonsHideAppear [i].GetComponent<Animator> ().SetTrigger (OnTrigger);
				ButtonToChange.GetComponent<Image>().sprite=ButtonOFF;
				Active=true;
			}
		}
		 else {
			for (int i= 0; i< ButtonsHideAppear.Length; i++) {
				ButtonsHideAppear [i].GetComponent<Animator> ().SetTrigger (OffTrigger);
				ButtonToChange.GetComponent<Image>().sprite=ButtonON;
				ButtonsHideAppear [i].GetComponent<Animator> ().speed= Speed;
				Active=false;
			}
		}
	}
	public void LoadScene(string Scene){
		 Application.LoadLevel (Scene);
	}
    public void LoadGame()
    {
        Application.LoadLevel(GameSceneName);
    }
    public void LoadGameByTime()
    {
        Invoke("LoadGame", DelayTimeToLoad);
    }
	public void Pause(string pause)
	{
		Time.timeScale = 0;
		Animation.SetTrigger (pause);

	}
	public void Play(string play)
	{
		Time.timeScale = 1;
		Animation.SetTrigger (play);
		
	}
	
	}
