using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCMenuBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private keyboardInput keyboardInputScript;
    private GameObject NPCCharacterMenu;
    private NPCClass   NPCClass;

    private string NPCMainAttributes;
    void Start()
    {
        keyboardInputScript = GameObject.Find("keyBoardInputManager").GetComponent<keyboardInput>();
        NPCCharacterMenu = GameObject.Find("Canvas/NPCCharacterMenu");
        NPCCharacterMenu.SetActive(false); 
        NPCClass = GetComponent<characterInitialisation>().NPCClass;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && mouseOveringNPC() == 1)
        {
            NPCCharacterMenu.SetActive(true);
            setNPCCharacterMenuContent();
        }
        else if ((Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse0)) && mouseOveringNPCCharacterMenu() == 0)
            NPCCharacterMenu.SetActive(false);
    }

    void    setNPCCharacterMenuContent()
    {
        int index = 0;
        NPCMainAttributes = NPCCharacterMenu.GetComponentInChildren<TextMeshProUGUI>().text;
        while (NPCMainAttributes[index] != ':')
            index++;
            Debug.Log("index = " + index + " NPCCLass.name = " + NPCClass.name);
        NPCMainAttributes = NPCMainAttributes.Insert(++index, " " + NPCClass.name);
        while (NPCMainAttributes[index] != ':')
            index++;
        NPCMainAttributes = NPCMainAttributes.Insert(++index," " +  NPCClass.age);
        while (NPCMainAttributes[index] != ':')
            index++;
        NPCMainAttributes = NPCMainAttributes.Insert(++index," " +  NPCClass.health);
        while (NPCMainAttributes[index] != ':')
            index++;
       NPCMainAttributes =  NPCMainAttributes.Insert(++index," " +  NPCClass.profession);
        while (NPCMainAttributes[index] != ':')
            index++;
        NPCMainAttributes = NPCMainAttributes.Insert(++index," " +  NPCClass.religion);
        while (NPCMainAttributes[index] != ':')
            index++;
        NPCMainAttributes = NPCMainAttributes.Insert(++index," " +  NPCClass.relationship);
        NPCCharacterMenu.GetComponentInChildren<TextMeshProUGUI>().text = NPCMainAttributes;
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
