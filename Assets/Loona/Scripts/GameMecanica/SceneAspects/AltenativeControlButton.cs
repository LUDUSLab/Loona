using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AltenativeControlButton : MonoBehaviour {

    [SerializeField]
    private Sprite ButtonOLD, ButtonNEW;
    [SerializeField]
    private string ControlButtonNAME = "AlternativeControl";
    [SerializeField]
    private string PushOrPopPlayerPrefs = "PushOrPopPlayerPrefs";
    private GameObject ControlButton;
    [SerializeField]
    // Use this for initialization
    void Start () {
        ControlButton = GameObject.Find(ControlButtonNAME);
        if(PlayerPrefs.GetInt(PushOrPopPlayerPrefs) == 1)
        {
            ControlButton.GetComponent<Image>().sprite = ButtonNEW;
        }
        else
        {
            ControlButton.GetComponent<Image>().sprite = ButtonOLD;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AlternateControl()
    {
        int OldValue = PlayerPrefs.GetInt(PushOrPopPlayerPrefs);

        Sprite ButtonSprite = new Sprite();
        //1 - new movement
        //0 - old movement

        int InverseValue;

        if (OldValue == 1)
        {
            InverseValue = 0;
            ControlButton.GetComponent<Image>().sprite = ButtonOLD;
        }
        else
        {
            InverseValue = 1;
            ControlButton.GetComponent<Image>().sprite = ButtonNEW;
        }
        PlayerPrefs.SetInt(PushOrPopPlayerPrefs, InverseValue);
    }
}
