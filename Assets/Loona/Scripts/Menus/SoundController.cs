using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {
	public AudioSource Menu;
	public AudioSource GameOver;
	public AudioSource Explosao;
	public AudioSource Stage;
    public AudioSource Botao;

	void Start(){
		DontDestroyOnLoad (gameObject);
		if (GameObject.FindGameObjectsWithTag ("SoundController").Length > 1) {
			Destroy(gameObject);	
		}
        //if (Application.loadedLevelName == "Menu")
       // {
            MusicaMenu();
        //}
	}
    public void StopMusicaStage()
    {
        Stage.Stop();    
    }
	public void MusicaMenu(){
		Menu.Play();		
	}
	public void MusicaExplosao(){
		Explosao.Play();
	}	
	public void MusicaStage(){	
		Stage.Play();
	}
	public void MusicaGameOver(){
		GameOver.Play();			
	}
    public void MusicaBotao()
    {
        Botao.Play();
    }

    //public void PlaySound(string sound){
		//switch (sound){
		//case "Explosao":MusicaExplosao(); break;
		//}
	//}
	void OnLevelWasLoaded(){
		if (Application.loadedLevelName == "Level1") {
            Menu.Stop();
            MusicaStage();
		}
        else if(Stage.isPlaying){
			Stage.Stop();
            MusicaMenu();
		}
	}
}