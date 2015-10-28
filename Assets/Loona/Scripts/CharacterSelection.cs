using UnityEngine;
using System.Collections;

public class CharacterSelection : MonoBehaviour {

    public  GameObject [] personagens;

    void Start () {
        DontDestroyOnLoad(gameObject);

    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 3)

            Instantiate(personagens[PlayerPrefs.GetInt("PositionInCharacterVector")]);
    }


    void Update () {

	}
}
