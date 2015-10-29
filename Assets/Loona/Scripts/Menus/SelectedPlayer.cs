using UnityEngine;
using System.Collections;

public class SelectedPlayer : MonoBehaviour {
    public int PositionInVector;
    public string LeveltoLoad;
    // Use this for initialization

void OnMouseDown()
    {
        PlayerPrefs.SetInt("PositionInCharacterVector", PositionInVector);
        Application.LoadLevel(LeveltoLoad);
    }
   // void Start () {
	
	//}
    // Update is called once per frame
	//void Update () {
	
	//}
}
