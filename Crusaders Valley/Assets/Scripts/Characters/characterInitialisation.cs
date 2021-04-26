using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterInitialisation : MonoBehaviour
{
    public NPCClass    NPCClass;
    private CharactersAttributesRegistry charactersAttributesRegistry;
    private GameObject hairObject; 
    private GameObject eyesContourObject;
    private GameObject eyebrowsObject;
    private GameObject pupilsObject;
    private bool characterInitiated;
    // Start is called before the first frame update
    void Start()
    {
        charactersAttributesRegistry = GameObject.Find("CharactersAttributesRegistry").GetComponent<CharactersAttributesRegistry>();
        characterInitiated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (characterInitiated == false)
            initiateCharacterAttributes();
    }

    void    initiateCharacterAttributes()
    {
        StartCoroutine(waitForAttributeRegistryInitialisation());
        NPCClass = new NPCClass();
        hairObject = transform.Find("appearance/hair").gameObject;
        eyesContourObject = transform.Find("appearance/eyes/eyesShape").gameObject;
        eyebrowsObject = transform.Find("appearance/eyes/eyebrows").gameObject;
        pupilsObject = transform.Find("appearance/eyes/pupils").gameObject;

        GetComponent<SpriteRenderer>().color = NPCClass.skinColor;
        hairObject.GetComponent<SpriteRenderer>().sprite = NPCClass.hair;
        hairObject.GetComponent<SpriteRenderer>().color = NPCClass.hairColor;

        eyesContourObject.GetComponent<SpriteRenderer>().sprite = NPCClass.eyes[0];

        eyebrowsObject.GetComponent<SpriteRenderer>().sprite = NPCClass.eyes[1];
        eyebrowsObject.GetComponent<SpriteRenderer>().color = NPCClass.hairColor;

        pupilsObject.GetComponent<SpriteRenderer>().sprite = NPCClass.eyes[2];
        pupilsObject.GetComponent<SpriteRenderer>().color = NPCClass.eyesColor;

        characterInitiated = true;
    }
    
    IEnumerator waitForAttributeRegistryInitialisation()
    {
        yield return new WaitUntil(() => charactersAttributesRegistry.attributeRegistryInitiated = true);
    }
}
