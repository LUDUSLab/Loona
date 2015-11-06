
using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class MuteSound : MonoBehaviour {
	public string SoundButtonNAME;
	public Sprite ButtonON, ButtonOFF;
	private bool muted;
	private GameObject SoundButton;
	// Use this for initialization
	void Start () {
		SoundButton= GameObject.Find (SoundButtonNAME);
		if (AudioListener.volume == 0.0f) {
			muted= true;
			SoundButton.GetComponent<Image>().sprite=ButtonOFF;

		} else {
			muted = false;
			SoundButton.GetComponent<Image>().sprite=ButtonON;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Mute(){
		if (!muted)
		{
			AudioListener.volume = 0.0f;
			muted = true;
			SoundButton.GetComponent<Image>().sprite=ButtonOFF;
		}
		else
		{
			AudioListener.volume = 1.0f;
			muted = false;
			SoundButton.GetComponent<Image>().sprite=ButtonON;
		}
	}
	public bool GetMutedState(){
		return this.muted;
	}
}