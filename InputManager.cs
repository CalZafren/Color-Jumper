using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    private GameObject toolWheel;
    [HideInInspector]
    public bool toolWheelActive = false;

    // Start is called before the first frame update
    void Start()
    {
        FindComponents();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInputs();
    }

    private void FindComponents(){
        toolWheel = GameObject.FindGameObjectWithTag("Tool Wheel");
    }

    private void CheckForInputs(){
        if(Input.GetButton("ToolWheel")){
            ShowToolWheel();
        }else{
            HideToolWheel();
        }
    }


    private void ShowToolWheel(){
        if(toolWheel != null){
            toolWheel.SetActive(true);
            toolWheelActive = true;
        }
    }

    private void HideToolWheel(){
        if(toolWheel != null){
            toolWheel.SetActive(false);
            toolWheelActive = true;
        }
    }
}
