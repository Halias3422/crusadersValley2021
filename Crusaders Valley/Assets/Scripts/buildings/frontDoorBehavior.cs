using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class frontDoorBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private keyboardInput keyboardInputScript;
    private BoxCollider2D col;
    public bool doorOpened;
    void Start()
    {
        doorOpened = false;
        keyboardInputScript = GameObject.Find("keyBoardInputManager").GetComponent<keyboardInput>(); 
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && mouseOveringFrontDoor() == 1)
            mouseDownOveringFrontDoor();
        if (getDistanceWithPlayer() > 2f && doorOpened == true && GetComponentInParent<buildingBehavior>().playerIsInside == false)
        {
            GetComponentInParent<buildingBehavior>().roof.GetComponent<SpriteRenderer>().enabled = true;
            GetComponentInParent<buildingBehavior>().walls.GetComponent<TilemapRenderer>().enabled = true;
            GetComponentInParent<buildingBehavior>().smallWalls.GetComponent<TilemapRenderer>().enabled = false;
            col.isTrigger = false;
            GetComponent<SpriteRenderer>().enabled = true;
            doorOpened = false;
        }
        
    }

    int mouseOveringFrontDoor()
    {
        foreach (RaycastHit2D col in keyboardInputScript.onMouseOverHits)
        {
            if (col.transform.name == transform.name && col.transform.position == transform.position)
                return (1);
        }
        return (0);
    }

    private void mouseDownOveringFrontDoor() {
        if (getDistanceWithPlayer() <= 2f)
        {
            if (col.isTrigger == false)
            {
                doorOpened = true;
                GetComponent<SpriteRenderer>().enabled = false;
                col.isTrigger = true;
            }
            else if (col.isTrigger == true)
            {
                doorOpened = false;
                GetComponent<SpriteRenderer>().enabled = true;
                if (GetComponentInParent<buildingBehavior>().playerIsInside == false)
                    GetComponentInParent<buildingBehavior>().roof.GetComponent<SpriteRenderer>().enabled = true;
                col.isTrigger = false;
            }
        }
    }

    public float getDistanceWithPlayer()
    {
        return (Vector3.Distance(GameObject.Find("player").transform.position, transform.position));
    }
}
