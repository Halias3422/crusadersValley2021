using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersAttributesRegistry : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite hair0;
    public Sprite hair1;
    public Sprite hair2;
    public Sprite hair3;


    public Sprite eyes1;
    public Sprite eyebrows1;
    public Sprite pupils1;
    public Sprite eyes2;
    public Sprite eyebrows2;
    public Sprite pupils2;
    public Sprite eyes3;
    public Sprite eyebrows3;
    public Sprite pupils3;
    public Sprite eyes0;
    public Sprite eyebrows0;
    public Sprite pupils0;


    public Color32 skinColor0;
    public Color32 skinColor1;
    public Color32 skinColor2;
    public Color32 skinColor3;


    public Color32 hairColor0;
    public Color32 hairColor1;
    public Color32 hairColor2;
    public Color32 hairColor3;


    public Color32 eyesColor0;
    public Color32 eyesColor1;
    public Color32 eyesColor2;
    public Color32 eyesColor3;

    public List<Sprite> hairList;
    public List<Sprite[]> eyesList;
    public List<Color32> skinColorsList;
    public List<Color32> hairColorList;
    public List<Color32> eyesColorList;
    public bool attributeRegistryInitiated;
    void Start()
    {
        attributeRegistryInitiated = false;
        initiateAttributeLists();

        registerSkinColors();
        registerHairColors();
        registerEyesColors();

        registerHairStyles();
        registerEyesStyles();
        attributeRegistryInitiated = true;

    }

    void    registerEyesStyles()
    {
        Sprite[] eyeCollection0 = new Sprite[3];
        eyeCollection0[0] = eyes0;
        eyeCollection0[1] = eyebrows0;
        eyeCollection0[2] = pupils0;
        eyesList.Add(eyeCollection0);
        Sprite[] eyeCollection1 = new Sprite[3];
        eyeCollection1[0] = eyes1;
        eyeCollection1[1] = eyebrows1;
        eyeCollection1[2] = pupils1;
        eyesList.Add(eyeCollection1);
        Sprite[] eyeCollection2 = new Sprite[3];
        eyeCollection2[0] = eyes2;
        eyeCollection2[1] = eyebrows2;
        eyeCollection2[2] = pupils2;
        eyesList.Add(eyeCollection2);
        Sprite[] eyeCollection3 = new Sprite[3];
        eyeCollection3[0] = eyes3;
        eyeCollection3[1] = eyebrows3;
        eyeCollection3[2] = pupils3;
        eyesList.Add(eyeCollection3);
    }

    void    registerHairStyles()
    {
        hairList.Add(hair0);
        hairList.Add(hair1);
        hairList.Add(hair2);
        hairList.Add(hair3);
    }

    void    registerEyesColors()
    {
       eyesColor0 = new Color32(136, 214, 255, 255);
       eyesColorList.Add(eyesColor0);
       eyesColor1 = new Color32(166, 204, 52, 255);
       eyesColorList.Add(eyesColor1);
       eyesColor2 = new Color32(126, 97, 68, 255);
       eyesColorList.Add(eyesColor2);
       eyesColor3 = new Color32(0, 0, 0, 255);
       eyesColorList.Add(eyesColor3);
    }

    void    registerHairColors()
    {
       hairColor0 = new Color32(34, 35, 35, 255);
       hairColorList.Add(hairColor0);
       hairColor1 = new Color32(232, 210, 75, 255);
       hairColorList.Add(hairColor1);
       hairColor2 = new Color32(74, 53, 60, 255);
       hairColorList.Add(hairColor2);
       hairColor3 = new Color32(227, 120, 64, 255);
       hairColorList.Add(hairColor3);
    }

    void    registerSkinColors()
    {
       skinColor0 = new Color32(255, 226, 207, 255); 
       skinColorsList.Add(skinColor0);
       skinColor1 = new Color32(253, 247, 134, 255); 
       skinColorsList.Add(skinColor1);
       skinColor2 = new Color32(178, 144, 98, 255);
       skinColorsList.Add(skinColor2);
       skinColor3 = new Color32(69, 49, 37, 255);
       skinColorsList.Add(skinColor3);
    }

    void    initiateAttributeLists()
    {
        hairList = new List<Sprite>();
        eyesList = new List<Sprite[]>();
        skinColorsList = new List<Color32>();
        hairColorList = new List<Color32>();
        eyesColorList = new List<Color32>();
    }

}
