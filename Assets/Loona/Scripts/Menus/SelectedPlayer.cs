using UnityEngine;
using System.Collections;

public class SelectedPlayer : MonoBehaviour {
    public int PositionInVector;
    public string LeveltoLoad;
    public GameObject Fade;
   // private int conttouch= 0 ;
    // Use this for initialization

void OnMouseDrag()
    {
        PlayerPrefs.SetInt("PositionInCharacterVector", PositionInVector);
        Debug.Log(PositionInVector);
       
    }

    void OnMouseUpAsButton()
    {
        Fade.GetComponent<Animator>().SetBool("Fade", true);
        PlayerPrefs.SetString("NextScene", LeveltoLoad);
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
