using UnityEngine;
using System.Collections;

public class OnAppPause : MonoBehaviour {// Controller that holds muted state
    private bool  MutedState;
    public bool CallPauseScreen;
    private bool Paused;
    // Use this for initialization
    void Awake()
    {
        Application.runInBackground = false;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnApplicationPause(bool pauseState)
    {
        MutedState =GetComponent<MuteSound>().GetMutedState();
        Paused = pauseState;

        if (Paused == true)
        {
            AudioListener.volume = 0.0f;
            if(!GameObject.Find("Tuto"))
                if (CallPauseScreen)
                    GetComponent<ButtonController>().Pause("Pause");
            Time.timeScale = 0;
        }

        else
        {
            //Caso desejem por Splash de pause no meio do jogo COMENTAR abaixo
            //(Seus "pauses gameobjects) devem despausar o jogo
            if (!GameObject.Find("Tuto") && (!CallPauseScreen)) Time.timeScale = 1;

            if (!MutedState) AudioListener.volume = 1.0f;
        }
    }
   /*void OnApplicationFocus(bool pauseState)
    {
        MutedState = GetComponent<MuteSound>().GetMutedState();
        bool Paused = pauseState;

        if (Paused == true)
        {
            AudioListener.volume = 0.0f;
            if (!GameObject.Find("Tuto"))
                if (CallPauseScreen)
                    GetComponent<ButtonController>().Pause("Pause");
            Time.timeScale = 0;
        }

        else
        {
            //Caso desejem por Splash de pause no meio do jogo COMENTAR abaixo
            //(Seus "pauses gameobjects) devem despausar o jogo
            if (!GameObject.Find("Tuto")) Time.timeScale = 1;

            if (!MutedState) AudioListener.volume = 1.0f;
        }
    }*/

}
