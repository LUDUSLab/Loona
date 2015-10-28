using UnityEngine;
using System.Collections;

//Made By JMG
public class FimDeJogo : MonoBehaviour {

    public GameObject PlayerParticleDeathPrefab;
    public GameObject PlayerObject;
    public float DelayTimeGameOverPopUp = 0.5f;
    [SerializeField]
    private string TagPlayer;
	// Use this for initialization
	void Start () {
        PlayerObject = GameObject.FindGameObjectWithTag(TagPlayer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Morrer()
    {
        PlayerObject.GetComponent<UnityJellySprite>().SetKinematic(true, false);
        Instantiate(PlayerParticleDeathPrefab, PlayerObject.transform.position, Quaternion.identity);
        Invoke("DelayGameOver", DelayTimeGameOverPopUp);
    }

    private void DelayGameOver()
    {
        GetComponent<ButtonController>().SetTriggerAnimator("GameOver");
        Time.timeScale = 0;
    }
}
