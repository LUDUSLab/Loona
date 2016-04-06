using UnityEngine;
using System.Collections;

public class ActivrObject : MonoBehaviour {

    // Use this for initialization
    private bool Arrow;
    public SpriteRenderer Seta;
    public SpriteRenderer Go;


    // Use this for initialization
    void Start()
    {
        /// Go.sortingLayerName = "Foreground";
        // Seta.sortingLayerName = "Foreground";
        Go.sortingLayerName = "Background";
        Seta.sortingLayerName = "Background";

    }

    // Update is called once per frame
    void Update()
    {
        Arrow = GameObject.FindGameObjectWithTag("SceneAspectsController").GetComponent<VictoryCondition>().Arrow;
        Seta = GameObject.FindGameObjectWithTag("Arrow").GetComponent<SpriteRenderer>();
        Go = GameObject.FindGameObjectWithTag("Go").GetComponent<SpriteRenderer>();

        if (Arrow)
        {
            Go.enabled = true;
            Seta.enabled = true;
            
            Debug.Log("True");

        }
        if (!Arrow)
        {
           
            Seta.enabled = false;
            Go.enabled = false;

            Debug.Log("false");

        }


    }
}
