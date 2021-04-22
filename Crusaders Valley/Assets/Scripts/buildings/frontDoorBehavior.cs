using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("doorOpened = " + doorOpened);
        if (getDistanceWithPlayer() > 2f && col.isTrigger == true && GetComponentInParent<buildingBehavior>().playerIsInside == false)
        {
            GetComponentInParent<buildingBehavior>().roof.GetComponent<SpriteRenderer>().enabled = true;
            col.isTrigger = false;
            GetComponent<SpriteRenderer>().enabled = true;
            doorOpened = false;
        }
        
    }

    private void OnMouseOver() {
        if (getDistanceWithPlayer() > 2f)
            keyboardInputScript.cursorActiveTexture = keyboardInputScript.transparentActivatedCursorTexture;
        else
            keyboardInputScript.cursorActiveTexture = keyboardInputScript.activatedCursorTexture;
    }

    private void OnMouseDown() {
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

    float getDistanceWithPlayer()
    {
        return (Vector3.Distance(GameObject.Find("player").transform.position, transform.position));
    }
    private void OnMouseExit() {
        keyboardInputScript.cursorActiveTexture = keyboardInputScript.neutralCursorTexture;
    }
}
