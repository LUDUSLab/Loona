using UnityEngine;
using System.Collections;

public class SelectedPlayer : MonoBehaviour {
    public int PositionInVector;
    public string LeveltoLoad;
   // private int conttouch= 0 ;
    // Use this for initialization

void OnMouseDrag()
    {
        PlayerPrefs.SetInt("PositionInCharacterVector", PositionInVector);
        Debug.Log(PositionInVector);
       
    }

    void OnMouseUpAsButton()
    {
        Application.LoadLevel(LeveltoLoad);
    }
    //void OnMouseExit()
    // {

    //  Application.LoadLevel(LeveltoLoad);

    // }




    // void Start () {

    //}
    // Update is called once per frame
    //void Update () {

    //}
}
