using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCClass
{
    public string name;
    public string age;
    public string health;
    public string profession;
    public string religion;
    public string relationship;

    public Sprite hair;
    public Sprite[] eyes;
    
    public Color32 hairColor;
    public Color32 eyesColor;
    public Color32 skinColor;
    
    private CharactersAttributesRegistry charactersAttributesRegistry;
   public NPCClass()
   {
       charactersAttributesRegistry = GameObject.Find("CharactersAttributesRegistry").GetComponent<CharactersAttributesRegistry>();
       name = "Guigui";
       age = "18";
       health = "healthy";
       profession = "Woodcutter";
       religion = "Atheist";
       relationship = "Single";

        setNPCPhysicalAttributes();
   } 

   void setNPCPhysicalAttributes()
   {
       int hairNb = Random.Range(0, charactersAttributesRegistry.hairList.Count);
       hair = charactersAttributesRegistry.hairList[hairNb];
       int eyesNb = Random.Range(0, charactersAttributesRegistry.eyesList.Count);
       eyes = charactersAttributesRegistry.eyesList[eyesNb];
       int hairColorNb = Random.Range(0, charactersAttributesRegistry.hairColorList.Count);
       hairColor = charactersAttributesRegistry.hairColorList[hairColorNb];
       int eyesColorNb = Random.Range(0, charactersAttributesRegistry.eyesColorList.Count);
       eyesColor = charactersAttributesRegistry.eyesColorList[eyesColorNb];
       int skinColorNb = Random.Range(0, charactersAttributesRegistry.skinColorsList.Count);
       skinColor = charactersAttributesRegistry.skinColorsList[skinColorNb];
   }
}
