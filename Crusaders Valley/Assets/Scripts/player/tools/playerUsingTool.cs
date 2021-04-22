using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerUsingTool : MonoBehaviour
{
    // Start is called before the first frame update

    //tmp vars
    private bool holdingTool;
    public GameObject heldTool;
    
    public bool toolHitObject;
    private string swingDirection;
    [SerializeField] public int swingSpeed;
    void Start()
    {
        //tmp
        holdingTool = true;
        //
        heldTool = transform.Find("choppingAxe").gameObject;
        toolHitObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (holdingTool == true && Input.GetKey(keyboardInput.useEquippedToolKey) == true)
        {
            checkMousePositionRelativeToPlayer();
            heldTool.GetComponent<PolygonCollider2D>().enabled = true;
            //heldTool.GetComponent<Animator>().Play((heldTool.name + "Swinging" + swingDirection), 0);
            heldTool.GetComponent<Animator>().Play(("choppingAxeSwinging" + swingDirection), 0);
        }        
        else if (holdingTool == true && heldTool.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("idleState"))
        {
            //heldTool.GetComponent<PolygonCollider2D>().enabled = false;
            disableAllToolsColliders();
            toolHitObject = false;
        }

    }

    void    disableAllToolsColliders()
    {
        transform.Find("choppingAxe").gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        transform.Find("pickaxe").gameObject.GetComponent<PolygonCollider2D>().enabled = false;
    }

    void    checkMousePositionRelativeToPlayer()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float diffX =  Mathf.Abs(transform.position.x - mousePos.x);
        float diffY = Mathf.Abs(transform.position.y - mousePos.y); 
        if (diffY > diffX)
        {
            if (mousePos.y >= transform.position.y)
                swingDirection = "Up";
            else
                swingDirection = "Down";
        }
        else
        {
            if (mousePos.x >= transform.position.x)
                swingDirection = "Right";
            else
                swingDirection = "Left";
        }
    }
}
