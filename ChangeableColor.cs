using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeableColor : MonoBehaviour
{
    // A is white, B is black
    public bool GroupA;
    public bool GroupB;
    public bool pink;
    [HideInInspector]
    public MeshRenderer meshRend;
    [HideInInspector]
    public Text text;
    [HideInInspector]
    public Image image;
    public bool isThisText;
    public bool isThisImage;
    public bool isThisSprite;
    public Sprite spriteA;
    public Sprite spriteB;

    void OnEnable(){
        meshRend = GetComponent<MeshRenderer>();
        text = GetComponent<Text>();
        image = GetComponent<Image>();
    }

}
