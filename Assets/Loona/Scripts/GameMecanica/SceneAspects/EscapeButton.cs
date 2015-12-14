using UnityEngine;
using System.Collections;

public class EscapeButton : MonoBehaviour {

    public string SceneToLoad = "None";
    public float RepeatRate = 0.02f;
    public GameObject Controller;
    public bool IsInAboutScreen = false;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Update2", 0, RepeatRate);
	}

	// Update is called once per frame
	void Update2 () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneToLoad == "None")
            {
                if (IsInAboutScreen)
                {
                    ChangeCanvasScenes CCSObject = Controller.GetComponent<ChangeCanvasScenes>();
                    IsInAboutScreen = false;
                    CCSObject.ChangeIt("MenuPrincipal");
                }
                else
                {
                    ButtonController buttonController = Controller.GetComponent<ButtonController>();
                    buttonController.InvokeExitPopUp();
                }
            }
            else if(SceneToLoad == "Pause")
            {
                ButtonController PauseController = GameObject.FindGameObjectWithTag("SceneAspectsController").GetComponent<ButtonController>();
                if (!PauseController.GameIsPaused)
                {
                    PauseController.Pause(SceneToLoad);
                }
            }
            else
            {
                ButtonController buttonController = Controller.GetComponent<ButtonController>();
                buttonController.LoadScene(SceneToLoad);
            }
        }
	}
}
