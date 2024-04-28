using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableTracker : MonoBehaviour
{
    public int pyramidCount;
    public Text pyramidCountTxt;

    public static CollectableTracker collectableTrackerSingleton;

    private void Awake()
    {
        collectableTrackerSingleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pyramidCount = 0;
        pyramidCountTxt.text = "Power Pyramids: " + pyramidCount + "/8";
    }

    public void AddPyramid()
    {
        pyramidCount++;
        pyramidCountTxt.text = "Power Pyramids: " + pyramidCount + "/8";
    }
}
