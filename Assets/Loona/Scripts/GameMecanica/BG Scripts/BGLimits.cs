using UnityEngine;
using System.Collections;

public class BGLimits : MonoBehaviour {

    public string BGObjectTag = "BGObject";

    // Use this for initialization
    void Start ()
    {
       
        //Debug.Log(BGBounds.min.x + "/" + BGBounds.max.x);
    }

    public Bounds getBGLimits()
    {
        Bounds BGBounds = GameObject.FindGameObjectWithTag(BGObjectTag).GetComponent<SpriteRenderer>().bounds;
        Bounds BGBoundLimits = new Bounds();
        Vector3 BGBoundsMin = new Vector3();
        Vector3 BGBoundsMax = new Vector3();

        if (BGBounds.min.x < 0)
        {
            BGBoundsMin.x = BGBounds.min.x + 1;
        }
        else
        {
            BGBoundsMin.x = BGBounds.min.x - 1;
        }

        if (BGBounds.max.x < 0)
        {
            BGBoundsMax.x = BGBounds.max.x + 1;
        }
        else
        {
            BGBoundsMax.x = BGBounds.max.x - 1;
        }

        if (BGBounds.min.y < 0)
        {
            BGBoundsMin.y = BGBounds.min.y + 1;
        }
        else
        {
            BGBoundsMin.y = BGBounds.min.y - 1;
        }

        if (BGBounds.max.y < 0)
        {
            BGBoundsMax.y = BGBounds.max.y + 1;
        }
        else
        {
            BGBoundsMax.y = BGBounds.max.y - 1;
        }

        BGBoundLimits.SetMinMax(BGBoundsMin, BGBoundsMax);

        return BGBoundLimits;
    }
	// Update is called once per frame
	void Update () {

	}

    
}
