using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCMenuBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private keyboardInput keyboardInputScript;
    private GameObject NPCCharacterMenu;
    void Start()
    {
        keyboardInputScript = GameObject.Find("keyBoardInputManager").GetComponent<keyboardInput>();
        NPCCharacterMenu = GameObject.Find("Canvas/NPCCharacterMenu");
        NPCCharacterMenu.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && mouseOveringNPC() == 1)
            NPCCharacterMenu.SetActive(true);
        else if ((Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse0)) && mouseOveringNPCCharacterMenu() == 0)
            NPCCharacterMenu.SetActive(false);
    }

    int mouseOveringNPCCharacterMenu()
    {
        foreach (RaycastHit2D col in keyboardInputScript.onMouseOverHits)
        {
            if (col.transform.name == NPCCharacterMenu.name && col.transform.position == NPCCharacterMenu.transform.position)
                return (1);
        }
        return (0);
    }

    int mouseOveringNPC()
    {
        foreach (RaycastHit2D col in keyboardInputScript.onMouseOverHits)
        {
            if (col.transform.name == transform.name && col.transform.position == transform.position)
                return (1);
        }
        return (0);
    }
}
