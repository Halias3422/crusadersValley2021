using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeBehavior : MonoBehaviour
{
    public string treeStatus;
    private int   treeHealth;
    private int   rootsHealth;
    private bool trunkChoppedOff;
    private float choppingTimeElapsed;
    private float choppingLerpDuration;
    private float fallingTimeElapsed;
    private float fallingLerpDuration;
    private bool treeChopped;
    private int choppingDirection;
    private bool treeFalling;
    private float treeFallingAngle;
    private float fallingSpeed;
    private bool firstTreeSwing;
    private GameObject treeTrunk;
    private GameObject treeRoots;

    // Start is called before the first frame update
    void Start()
    {
        treeStatus = "grown";
        treeHealth = 100;
        rootsHealth = 50;
        treeChopped = false;
        treeFalling = false;
        treeFallingAngle = 0;
        choppingLerpDuration = 0.05f;
        fallingLerpDuration = 2f;
        fallingTimeElapsed = 0;
        treeTrunk = gameObject.transform.Find("treeTrunk").gameObject;
        treeRoots = gameObject.transform.Find("treeRoot").gameObject;
        trunkChoppedOff = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (trunkChoppedOff == false)
        {
            if (treeChopped == true && treeFalling == false)        
                treeBeingChoppedReaction(treeTrunk);
            else if (treeFalling == true)
                treeFallingReaction();
        }
        else if (treeHealth <= 0 && treeChopped == true)
        {
            if (rootsHealth <= 0)
                Destroy(this.gameObject, 0);
            else
                treeBeingChoppedReaction(treeRoots);
        }

    }

    void    treeFallingReaction()
    {
        fallingSpeed = Mathf.Lerp(0, 1f, fallingTimeElapsed / fallingLerpDuration);
        treeFallingAngle -= fallingSpeed * choppingDirection;
        treeTrunk.transform.rotation = Quaternion.Euler(0, 0, treeFallingAngle);
        if (treeTrunk.transform.rotation.eulerAngles.z > 0 && ((choppingDirection > 0 && treeTrunk.transform.rotation.eulerAngles.z <= 270) ||
        (choppingDirection < 0 && treeTrunk.transform.rotation.eulerAngles.z >= 90)))
        {
            treeTrunk.transform.rotation = Quaternion.Euler(0, 0, -90 * choppingDirection);
            treeFalling = false;
            Destroy(treeTrunk, 0);
            trunkChoppedOff = true;
        }
       //treeTrunk.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, 0, -90), choppingTimeElapsed / fallingLerpDuration));
       fallingTimeElapsed += Time.deltaTime;
    }

    void   treeBeingChoppedReaction(GameObject choppedPart)
    {
            if (firstTreeSwing == false && choppingTimeElapsed < choppingLerpDuration)
            {
                choppedPart.transform.localPosition = Vector3.Lerp(new Vector3(0, choppedPart.transform.localPosition.y, 0), new Vector3(0.05f * choppingDirection, choppedPart.transform.localPosition.y, 0), choppingTimeElapsed / choppingLerpDuration);
                choppingTimeElapsed += Time.deltaTime;
            }
            else if (firstTreeSwing == false && choppingTimeElapsed >= choppingLerpDuration)
            {
                firstTreeSwing = true;
                choppingTimeElapsed = 0;
                if (choppedPart.name.Contains("Trunk") && treeHealth <= 0)
                {
                    treeFalling = true;
                    fallingSpeed = 0;
                    treeChopped = false;
                }
            }
            else if (firstTreeSwing == true && ((choppingDirection > 0 && choppedPart.transform.localPosition.x > 0f) ||
                    (choppingDirection < 0 && choppedPart.transform.localPosition.x < 0f)))
            {
                choppedPart.transform.localPosition = Vector3.Lerp(new Vector3(0.05f * choppingDirection, choppedPart.transform.localPosition.y, 0), new Vector3(0, choppedPart.transform.localPosition.y, 0), choppingTimeElapsed / choppingLerpDuration);
                choppingTimeElapsed += Time.deltaTime;
            }
            else
            {
                Debug.Log("je passe ici");
                choppedPart.transform.localPosition = new Vector3(0, choppedPart.transform.localPosition.y, 0);
                treeChopped = false;
            }
    }

private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<toolAttributes>() && other.gameObject.GetComponent<toolAttributes>().toolType == ("choppingAxe") &&
            other.gameObject.transform.parent.GetComponent<playerUsingTool>().toolHitObject == false)
        {
            if (other.gameObject.transform.position.x >= transform.position.x)
                choppingDirection = -1;
            else
                choppingDirection = 1;
               other.gameObject.transform.parent.GetComponent<playerUsingTool>().toolHitObject = true;
               if (trunkChoppedOff == false)
                treeHealth -= other.gameObject.GetComponent<toolAttributes>().toolDamage;
                else
                    rootsHealth -= other.gameObject.GetComponent<toolAttributes>().toolDamage;
               choppingTimeElapsed = 0;
               firstTreeSwing = false;
                treeChopped = true;
        }
    }
}
