using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject frontDoor;
    public GameObject roof;
    
    public bool playerIsInside;
    
    void Start()
    {
        playerIsInside = false;
        foreach (Transform child in transform)
        {
            if (child.name == "frontDoor")
                frontDoor = child.gameObject;
            else if (child.name == "roof")
                roof = child.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "player" && GetComponentInChildren<frontDoorBehavior>().doorOpened == true)
        {
            playerIsInside = true;
            roof.GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "player")
            playerIsInside = false; 
    }
}
