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
    public string LoadingSceneName;
	private bool Active;
	private Animator Animation;
    public bool GameIsPaused = false;
    private float DelayTimeToPause = 0.1f;
	// Use this for initialization
	void Start () {
        
		Active = false;
        if(Application.loadedLevelName == "game")
        {
            Animation = GameObject.Find("Pivo").GetComponent<Animator>();
        }
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
        GameIsPaused = true;
		Time.timeScale = 0;
		Animation.SetTrigger (pause);

	}
	public void Play(string play)
	{
        Time.timeScale = 1;
		Animation.SetTrigger (play);
        Invoke("SetGamePausedFalse", DelayTimeToPause);
	}
	public void Restart()
    {
        GameIsPaused = false;
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }
    public void SetTriggerAnimator(string triggertoset)
    {
        Animation.SetTrigger(triggertoset);
    }

    public void PlayOnStart(GameObject PopUpToDestroy)
    {
        Time.timeScale = 1;
        Destroy(PopUpToDestroy);
        Invoke("PlayInTime",0.2f);
    }
    void PlayInTime()
    {
        Time.timeScale = 1;
    }
    void SetGamePausedFalse()
    {
        GameIsPaused = false;
    }
}
