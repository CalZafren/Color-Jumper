using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    private GameObject[] AllObjects;
    private List<GameObject> GroupA = new List<GameObject>();
    private List<GameObject> GroupB = new List<GameObject>();
    private List<GameObject> textObjects = new List<GameObject>();
    private List<GameObject> images = new List<GameObject>();
    private List<GameObject> sprites = new List<GameObject>();
    private ChangeableColor changeableColor;
    private ChangeBackground changeBackground;
    private MeshRenderer meshRend;

    //Group A starts as white and Group B starts as black
    public Material groupAColor;
    public Material groupBColor;
    public Material pinkColor;
    public Material blueColor;
    public Material yellowColor;

    // Start is called before the first frame update
    void Start()
    {
        //Gathers all the changeable objects into an array
        AllObjects = GameObject.FindGameObjectsWithTag("Changeable");
        changeBackground = GameObject.FindGameObjectWithTag("BackgroundManager").GetComponent<ChangeBackground>();

        //Sorts the two groups into their respective lists, so we can edit them as a group (Also sets their OG color)
        SortLists(); 
        HideAndShowObjects();
    }

    private void SortLists(){
        foreach (GameObject thisObject in AllObjects)
        {
            //Gathering the components of that object
            changeableColor = thisObject.GetComponent<ChangeableColor>();

            //Putting the component in the correct list and setting its color
            if(changeableColor.GroupA){
                GroupA.Add(thisObject);
                changeableColor.meshRend.material.color = groupAColor.color;       
            }else if(changeableColor.GroupB){
                GroupB.Add(thisObject);
                changeableColor.meshRend.material.color = groupBColor.color;
            }else if(changeableColor.isThisText){
                textObjects.Add(thisObject);
                changeableColor.text.color = groupBColor.color;
            }else if(changeableColor.isThisImage){
                images.Add(thisObject);
                changeableColor.image.color = groupBColor.color;
            }else if(changeableColor.isThisSprite){
                sprites.Add(thisObject);
                changeableColor.image.sprite = changeableColor.spriteB;
            }
        }
    }

    public void HideAndShowObjects(){
        // 0 is black and 1 is white
        if(changeBackground.GetBackgroundColor() == 0){
            //Disables objects in Group B and sets group A objects active
            foreach (GameObject thisObject in GroupB)
            {
                thisObject.SetActive(false);
            }

            foreach (GameObject thisObject in GroupA)
            {
                thisObject.SetActive(true);
            }
        }else{
            //Disables objects in Group A and sets group B objects active
            foreach (GameObject thisObject in GroupB)
            {
                thisObject.SetActive(true);
            }

            foreach (GameObject thisObject in GroupA)
            {
                thisObject.SetActive(false);
            }
        }
    }

    public void ChangeTextColor(){
        foreach (GameObject textItem in textObjects)
        {
            Text text = textItem.GetComponent<Text>();
            //0 is black and 1 is white
            if(changeBackground.GetBackgroundColor() == 0){
                text.color = groupAColor.color;
            }else{
                text.color = groupBColor.color;
            }
        }
    }

    public void ChangeImageColors(){
        foreach (GameObject imageItem in images)
        {
            Image image = imageItem.GetComponent<Image>();
             //0 is black and 1 is white
            if(changeBackground.GetBackgroundColor() == 0){
                image.color = groupAColor.color;
            }else{
                image.color = groupBColor.color;
            }
        }
    }

    public void ChangeSpriteColors(){
        foreach (GameObject spriteItem in sprites)
        {
            Image image = spriteItem.GetComponent<Image>();
            ChangeableColor script = spriteItem.GetComponent<ChangeableColor>();

            //0 is black and 1 is white
            if(changeBackground.GetBackgroundColor() == 0){
                image.sprite = script.spriteA;
            }else{
                image.sprite = script.spriteB;
            }
        }
    }

    public void StartFunctions(){
        HideAndShowObjects();
        ChangeImageColors();
        ChangeTextColor();
        ChangeSpriteColors();
    }

    public void SwapColors(GameObject object1, GameObject object2){
        //Swaps the physical material
        var temp = object1.GetComponent<MeshRenderer>().material;
        object1.GetComponent<MeshRenderer>().material = object2.GetComponent<MeshRenderer>().material;
        object2.GetComponent<MeshRenderer>().material = temp;

    }

    public void UpdateLists(GameObject object1, GameObject object2){
        //Deletes them from the old lists
        List<GameObject> TempList1 = WhichListContains(object1);
        List<GameObject> TempList2 = WhichListContains(object2);

        if(TempList1 != null){
           TempList1.Remove(object1);
        }

        if(TempList2 != null){
           TempList2.Remove(object2);
        }

        Color object1Color = DetermineColor(object1);
        Color object2Color = DetermineColor(object2);

        if(object1Color == groupAColor.color){
            GroupA.Add(object1);
        }else if(object1Color == groupBColor.color){
            GroupB.Add(object1);
        }

        if(object2Color == groupAColor.color){
            GroupA.Add(object2);
        }else if(object2Color == groupBColor.color){
            GroupB.Add(object2);
        }
    }

    private List<GameObject> WhichListContains(GameObject thisObject){
        if(GroupA.Contains(thisObject)){
            return GroupA;
        }else if(GroupB.Contains(thisObject)){
            return GroupB;
        }else{
            return null;
        }
    }

    private Color DetermineColor(GameObject thisObject){
        Color thisColor = thisObject.GetComponent<MeshRenderer>().material.color;
        //If this object is white
        if(thisColor == groupAColor.color){
            return groupAColor.color;
        //If it is black
        }else if(thisColor == groupBColor.color){
            return groupBColor.color;
        //If it is pink
        }else if(thisColor == pinkColor.color){
            return pinkColor.color;
        }else if(thisColor == blueColor.color){
            return blueColor.color;
        }else if(thisColor == yellowColor.color){
            return yellowColor.color;
        }else{
            return Color.clear;
        }
    }

    public void DeleteObject(GameObject object1){
        List<GameObject> TempList1 = WhichListContains(object1);

        if(TempList1 != null){
           TempList1.Remove(object1);
        }

        Destroy(object1);
    }

    public void ExplosionCode(GameObject object1, GameObject object2){
        int randNum;
        ColorCubeBehavior cubeBehavior;
        MeshRenderer myMesh;
        GameObject[] explosionObjects = {object1, object2};

        
        foreach (GameObject item in explosionObjects)
        {
            randNum = Random.Range(1,6);
            myMesh = item.GetComponent<MeshRenderer>();
            cubeBehavior = item.GetComponent<ColorCubeBehavior>();
            Debug.Log(cubeBehavior);
            switch(randNum){
                case 1:
                    myMesh.material = groupAColor;
                    if(changeBackground.GetBackgroundColor() == 1){
                        item.SetActive(false);
                    }
                    Debug.Log("Should set color" + cubeBehavior.white.color);
                    break;
                case 2:
                    myMesh.material = groupBColor;
                    if(changeBackground.GetBackgroundColor() == 0){
                        item.SetActive(false);
                    }
                    Debug.Log("Should set color" + cubeBehavior.black.color);
                    break;
                case 3:
                    myMesh.material = pinkColor;
                    Debug.Log("Should set color" + cubeBehavior.pink.color);
                    break;
                case 4:
                    myMesh.material = blueColor;
                    Debug.Log("Should set color" + cubeBehavior.blue.color);
                    break;
                case 5:
                    myMesh.material = yellowColor;
                    Debug.Log("Should set color" + cubeBehavior.yellow.color);
                    break;
            }
        }
    }


}
