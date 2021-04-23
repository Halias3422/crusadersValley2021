using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardInput : MonoBehaviour
{
    // Start is called before the first frame update
    public static KeyCode moveUpKey;
    public static KeyCode moveDownKey;
    public static KeyCode moveLeftKey;
    public static KeyCode moveRightKey;
    public static KeyCode useEquippedToolKey;
    [SerializeField] public Texture2D neutralCursorTexture;
    [SerializeField] public Texture2D activatedCursorTexture;
    [SerializeField] public Texture2D transparentActivatedCursorTexture;
    public Texture2D cursorActiveTexture;
    public RaycastHit2D[] onMouseOverHits;

    void Start()
    {
        moveUpKey = KeyCode.W;
        //moveUpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), "KeyCode.W");
        moveDownKey = KeyCode.S;
        moveLeftKey = KeyCode.A;
        moveRightKey = KeyCode.D;
        useEquippedToolKey = KeyCode.Mouse0;
        cursorActiveTexture = neutralCursorTexture;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.SetCursor(cursorActiveTexture, Vector2.zero, CursorMode.Auto);
        customOnMouseOver();
        
    }

    void    customOnMouseOver()
    {
        bool overingFrontDoor = false;

        onMouseOverHits = Physics2D.RaycastAll(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
        foreach (RaycastHit2D col in onMouseOverHits)
        {
            if (col.transform.name == "frontDoor")
            {
                if (col.transform.GetComponent<frontDoorBehavior>().getDistanceWithPlayer() > 2f)
                    cursorActiveTexture = transparentActivatedCursorTexture;
                else
                    cursorActiveTexture = activatedCursorTexture;
                overingFrontDoor = true;
            }
        }
        if (overingFrontDoor == false)
            cursorActiveTexture = neutralCursorTexture;
    }
}
