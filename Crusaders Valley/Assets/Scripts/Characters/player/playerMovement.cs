using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public int speed;
    private float horizontalAxis;
    private float verticalAxis;
    void Start()
    {
       horizontalAxis = 0f;
       verticalAxis = 0f; 
    }

    // Update is called once per frame
    void Update()
    {
        setMovementAxis();
        
    }

    void    setMovementAxis()
    {
        if (verticalAxis >= 0 && Input.GetKey(keyboardInput.moveUpKey) == true)
            verticalAxis = 1f;
        else if (verticalAxis <= 0 && Input.GetKey(keyboardInput.moveDownKey) == true)
            verticalAxis = -1f;
        else
            verticalAxis = 0f;
        if (horizontalAxis <= 0 && Input.GetKey(keyboardInput.moveLeftKey) == true)
            horizontalAxis = -1f;
        else if (horizontalAxis >= 0 && Input.GetKey(keyboardInput.moveRightKey) == true)
            horizontalAxis = 1f;
        else
            horizontalAxis = 0f;
        if (verticalAxis != 0 && horizontalAxis != 0)
        {
            verticalAxis *= 0.7f;
            horizontalAxis *= 0.7f;
        }
    }

    private void FixedUpdate() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(horizontalAxis * speed, verticalAxis * speed);
    }
}
