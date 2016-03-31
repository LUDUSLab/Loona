using UnityEngine;
using System.Collections;

public class PlayAnimatorSoundDelayed : MonoBehaviour {

    public float DelayTime = 0.3f;

    public void RestartAnimationWithNoSound()
    {
        Invoke("SetPlaySoundFalse", DelayTime);
    }
    private  void SetPlaySoundFalse()
    {
        gameObject.GetComponent<Animator>().SetBool("PlaySoundON", false);
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
