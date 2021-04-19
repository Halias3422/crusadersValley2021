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
    void Start()
    {
        moveUpKey = KeyCode.W;
        //moveUpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), "KeyCode.W");
        moveDownKey = KeyCode.S;
        moveLeftKey = KeyCode.A;
        moveRightKey = KeyCode.D;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
