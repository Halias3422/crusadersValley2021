using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeBehavior : MonoBehaviour
{
    public string treeStatus;
    private int   treeHealth;
    // Start is called before the first frame update
    void Start()
    {
        treeStatus = "grown";
        treeHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
