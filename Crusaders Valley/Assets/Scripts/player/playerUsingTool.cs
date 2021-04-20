using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerUsingTool : MonoBehaviour
{
    // Start is called before the first frame update

    //tmp vars
    private bool holdingTool;
    public GameObject heldTool;

    //
    private string swingDirection;
    private Vector3 swingTargetAngle;
    private Vector3 swingStartAngle;
    private bool swingStarted;
    [SerializeField] public int swingSpeed;
    void Start()
    {
        //tmp
        holdingTool = true;
        //
        heldTool = transform.Find("choppingAxe").gameObject;
        swingStarted = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingTool == true && Input.GetKey(keyboardInput.useEquippedToolKey) == true)
        {
            checkMousePositionRelativeToPlayer();
            heldTool.transform.rotation = Quaternion.Euler(swingStartAngle.x, swingStartAngle.y, swingStartAngle.z);
            swingStarted = true;
            heldTool.GetComponent<Animator>().Play((heldTool.name + "Swinging" + swingDirection), 0);
        }        
    }

    void    checkMousePositionRelativeToPlayer()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float diffX =  Mathf.Abs(transform.position.x - mousePos.x);
        float diffY = Mathf.Abs(transform.position.y - mousePos.y); 
        if (diffY > diffX)
        {
            if (mousePos.y >= transform.position.y)
            {
                swingDirection = "Up";
                swingStartAngle = new Vector3(0, 0, 90);
                swingTargetAngle = new Vector3(0, 0, -90);
            }
            else
            {
                swingDirection = "Down";
                swingStartAngle = new Vector3(0, 0, -90);
                swingTargetAngle = new Vector3(0, 0, 90);
            }
        }
        else
        {
            if (mousePos.x >= transform.position.x)
            {
                swingDirection = "Right";
                swingStartAngle = new Vector3(0, 0, 0);
                swingTargetAngle = new Vector3(0, 0, -180);
            }
            else
            {
                swingDirection = "Left";
                swingStartAngle = new Vector3(0, 0, 0);
                swingTargetAngle = new Vector3(0, 0, 180);
            }
            Debug.Log("direction = " + swingDirection);
        }
    }
}
