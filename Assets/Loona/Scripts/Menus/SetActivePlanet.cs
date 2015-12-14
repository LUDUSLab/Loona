using UnityEngine;
using System.Collections;

public class SetActivePlanet : MonoBehaviour {


	// Use this for initialization
	void Start () {
		int MinStage = 1;
		int i = MinStage;
		int MaxStage = 1;
		string StagePrefix = "Level";
		string PlanetObjectTagPrefix = "Planet";
		while(PlayerPrefs.GetInt(StagePrefix + MinStage.ToString()) == 1 && i <= MaxStage)
		{
			i++;
			GameObject.FindGameObjectWithTag(PlanetObjectTagPrefix + i.ToString()).GetComponent<SpriteRenderer>().color = 
				new Color(255, 255, 255, 255);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
