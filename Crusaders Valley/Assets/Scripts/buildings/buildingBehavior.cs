using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class buildingBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject frontDoor;
    public GameObject roof;
    public GameObject walls;
    public GameObject smallWalls;
    
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
            else if (child.name == "houseWallsTileMap")
                walls = child.gameObject;
            else if (child.name == "houseSmallWallsTileMap")   
                smallWalls = child.gameObject;
        }
        smallWalls.GetComponent<TilemapRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "player" && GetComponentInChildren<frontDoorBehavior>().doorOpened == true)
        {
            walls.GetComponent<TilemapRenderer>().enabled = false;
            smallWalls.GetComponent<TilemapRenderer>().enabled = true;
            playerIsInside = true;
            roof.GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.name == "player")
        {
            playerIsInside = false; 
            walls.GetComponent<TilemapRenderer>().enabled = true;
            roof.GetComponent<SpriteRenderer>().enabled = true;
            smallWalls.GetComponent<TilemapRenderer>().enabled = false;
        }
    }
}
