using UnityEngine;
using System.Collections;

public class SelectedPlayer : MonoBehaviour {
    public int PositionInVector;
    // Use this for initialization

void OnMouseDown()
    {
        PlayerPrefs.SetInt("PositionInCharacterVector", PositionInVector);
        Application.LoadLevel("game");
    }
   // void Start () {
	
	//}
    // Update is called once per frame
	//void Update () {
	
	//}
}
