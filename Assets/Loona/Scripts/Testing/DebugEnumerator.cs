using UnityEngine;
using System.Collections;

public class DebugEnumerator : MonoBehaviour {
	public bool CountChild=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CountChild)
			Debug.Log (gameObject.transform.childCount);
	}
}
