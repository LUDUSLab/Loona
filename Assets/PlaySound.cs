using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

    [SerializeField]
    private AudioClip SoundClip;
    [SerializeField]
    private AudioSource source;

    // Use this for initialization
    void Start () {
        source = GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }
	
    public void Play()
    {
        source.PlayOneShot(SoundClip);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
