using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickArray : MonoBehaviour
{

    private ColorManager colorManager;
    private ToolManager toolManager;
    private GameObject[] clickedObjects; 
    public ClickArray instance;
    private Ammo ammoManager;
    private PlayerColorBehavior playerColorBehavior;

    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        toolManager = GameObject.FindGameObjectWithTag("Tool Manager").GetComponent<ToolManager>().GetInstance();
        colorManager = GameObject.FindGameObjectWithTag("Color Manager").GetComponent<ColorManager>();
        ammoManager = GameObject.FindGameObjectWithTag("Ammo").GetComponent<Ammo>().GetInstance();
        playerColorBehavior = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerColorBehavior>().GetInstance();
        clickedObjects = new GameObject[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[] getClickedObjects(){
        return clickedObjects;
    }

    public void AddClickedObject(GameObject newObject){


        if(clickedObjects[0] == null){
            clickedObjects[0] = newObject;
            //Performs the actions for erase or absorb
            if(toolManager.GetToolID() == 2 || toolManager.GetToolID() == 3){
                PerformToolAction();
            }
        }else if(newObject != clickedObjects[0]){
            clickedObjects[1] = newObject;
            PerformToolAction();
        }
    }

    public void ClearArray(){
        for(int i = 0; i < clickedObjects.Length; i++){
            clickedObjects[i] = null;
        }
    }

    private void PerformToolAction(){
        //If there are any available uses left
        if(ammoManager.GetRemainingShots() > 0){
            //If the paintbrush is equipped
            if(toolManager.GetToolID() == 1){
                colorManager.SwapColors(clickedObjects[0], clickedObjects[1]);
                colorManager.UpdateLists(clickedObjects[0], clickedObjects[1]);
            //If the eraser is equipped
            }else if(toolManager.GetToolID() == 2){
                Debug.Log("Erasing");
                colorManager.DeleteObject(clickedObjects[0]);
            //If the absorb tool is equipped
            }else if(toolManager.GetToolID() == 3){
                playerColorBehavior.SetColor(clickedObjects[0].GetComponent<MeshRenderer>().material.color);
                Debug.Log("Absorbing");
            }else if(toolManager.GetToolID() == 4){
                //Code for explosion
                colorManager.ExplosionCode(clickedObjects[0], clickedObjects[1]);
                colorManager.UpdateLists(clickedObjects[0], clickedObjects[1]);
            }
            ammoManager.UseShot();
        }

        ClearArray();
    }

    
}
