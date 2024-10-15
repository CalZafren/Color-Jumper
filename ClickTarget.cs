using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTarget : MonoBehaviour
{
    private ClickArray clickArray;
    private ToolManager toolManager;
    // Start is called before the first frame update
    void Start()
    {
        clickArray = GameObject.FindGameObjectWithTag("ClickArray").GetComponent<ClickArray>().instance;
        toolManager = GameObject.FindGameObjectWithTag("Tool Manager").GetComponent<ToolManager>().GetInstance();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown(){
        if(toolManager.ToolBeingUsed()){
            clickArray.AddClickedObject(gameObject);
        }
    }

}
