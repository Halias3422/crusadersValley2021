using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choppingAxePolygonColliderUpdate : MonoBehaviour
{
    private PolygonCollider2D collid;
    // Start is called before the first frame update
    void Start()
    {
       collid = GetComponent<PolygonCollider2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void    setColliderSwingingRight0()
    {
        this.transform.parent.transform.parent.gameObject.GetComponent<playerUsingTool>().toolHitObject = false;
        collid.points = new[]{new Vector2(0, 1), new Vector2(0, 3), new Vector2(1, 2.8f), new Vector2(1.5f, 2.4f)};
    }
    void    setColliderSwingingRight1()
    {
        collid.points = new[]{new Vector2(0, 1), new Vector2(2, 1), new Vector2(1.9f, 1.8f), new Vector2(1.45f, 2.4f)};
    }
    void    setColliderSwingingRight2()
    {
        collid.points = new[]{new Vector2(0, 1), new Vector2(2, 1), new Vector2(1.85f, 0.2f), new Vector2(1.45f, -0.4f)};
    }
    void    setColliderSwingingRight3()
    {
        collid.points = new[]{new Vector2(0, 1), new Vector2(0, -1), new Vector2(0.8f, -0.85f), new Vector2(1.45f, -0.4f)};
    }

     void    setColliderSwingingLeft0()
    {
        this.transform.parent.transform.parent.gameObject.GetComponent<playerUsingTool>().toolHitObject = false;
        collid.points = new[]{new Vector2(0, 1), new Vector2(0, 3), new Vector2(-1, 2.8f), new Vector2(-1.5f, 2.4f)};
    }
    void    setColliderSwingingLeft1()
    {
        collid.points = new[]{new Vector2(0, 1), new Vector2(-2, 1), new Vector2(-1.9f, 1.8f), new Vector2(-1.45f, 2.4f)};
    }
    void    setColliderSwingingLeft2()
    {
        collid.points = new[]{new Vector2(0, 1), new Vector2(-2, 1), new Vector2(-1.85f, 0.2f), new Vector2(-1.45f, -0.4f)};
    }
    void    setColliderSwingingLeft3()
    {
        collid.points = new[]{new Vector2(0, 1), new Vector2(0, -1), new Vector2(-0.8f, -0.85f), new Vector2(-1.45f, -0.4f)};
    }  
     void    setColliderSwingingDown0()
    {
        this.transform.parent.transform.parent.gameObject.GetComponent<playerUsingTool>().toolHitObject = false;
        collid.points = new[]{new Vector2(0, 1), new Vector2(2, 1), new Vector2(1.85f, 0.2f), new Vector2(1.45f, -0.4f)};
    }
    void    setColliderSwingingDown1()
    {
        collid.points = new[]{new Vector2(0, 1), new Vector2(0, -1), new Vector2(0.8f, -0.85f), new Vector2(1.45f, -0.4f)};
    }
    void    setColliderSwingingDown2()
    {
        collid.points = new[]{new Vector2(0, 1), new Vector2(0, -1), new Vector2(-0.8f, -0.85f), new Vector2(-1.45f, -0.4f)};
    }
    void    setColliderSwingingDown3()
    {
        collid.points = new[]{new Vector2(0, 1), new Vector2(-2, 1), new Vector2(-1.85f, 0.2f), new Vector2(-1.45f, -0.4f)};
    }  
     void    setColliderSwingingUp0()
    {
        this.transform.parent.transform.parent.gameObject.GetComponent<playerUsingTool>().toolHitObject = false;
        collid.points = new[]{new Vector2(0, 1), new Vector2(-2, 1), new Vector2(-1.9f, 1.8f), new Vector2(-1.45f, 2.4f)};
    }
    void    setColliderSwingingUp1()
    {
        collid.points = new[]{new Vector2(0, 1), new Vector2(0, 3), new Vector2(-1, 2.8f), new Vector2(-1.5f, 2.4f)};
    }
    void    setColliderSwingingUp2()
    {
        collid.points = new[]{new Vector2(0, 1), new Vector2(0, 3), new Vector2(1, 2.8f), new Vector2(1.5f, 2.4f)};
    }
    void    setColliderSwingingUp3()
    {
        collid.points = new[]{new Vector2(0, 1), new Vector2(2, 1), new Vector2(1.9f, 1.8f), new Vector2(1.45f, 2.4f)};
    }  
}
