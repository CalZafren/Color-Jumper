using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{

    public Camera mainCam;
    private SpriteRenderer player;
    private ColorManager colorManager;
    private PlayerColorBehavior playerColorBehavior;
    
    // Start is called before the first frame update
    void Start()
    {
       colorManager = GameObject.FindGameObjectWithTag("Color Manager").GetComponent<ColorManager>();
       playerColorBehavior = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerColorBehavior>().GetInstance();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>(); 
       mainCam.backgroundColor = colorManager.groupAColor.color;
       player.color = colorManager.groupBColor.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact")){
            if(GetBackgroundColor() == 1){
                mainCam.backgroundColor = colorManager.groupBColor.color;
                if(playerColorBehavior.changeable){
                    player.color = colorManager.groupAColor.color;
                }
            }else{
                mainCam.backgroundColor = colorManager.groupAColor.color;
                if(playerColorBehavior.changeable){
                    player.color = colorManager.groupBColor.color;
                }
            }

            colorManager.StartFunctions();
        }
    }


    //Returns the color of the background. 0 is black. 1 is white
    public int GetBackgroundColor(){

        //Handles the exception not accessign color manager yet
        if(colorManager == null){
            return 1;
        }

        if(mainCam.backgroundColor == colorManager.groupAColor.color){
            return 1;
        }else{
            return 0;
        }
    }
}
