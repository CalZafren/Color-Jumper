using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour
{

    private ToolManager toolManager;
    private Text goalText;
    private string goal;

    // Start is called before the first frame update
    void Start()
    {
        goalText = GameObject.FindGameObjectWithTag("Goal").GetComponentInChildren<Text>();
        toolManager = GameObject.FindGameObjectWithTag("Tool Manager").GetComponent<ToolManager>().GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        SetGoalText();
        goalText.text = goal;
    }

    void SetGoalText(){
        switch(toolManager.GetToolID()){
            case 0:
                goal = "Reach the Exit";
                break;
            case 1:
                goal = "Use 'Shift' to select two blocks to switch the colors";
                break;
            case 2:
                goal = "Use 'Shift' and click a block to erase it";
                break;
            case 3:
                goal = "Use 'Shift' to absorb the color and properties of a block";
                break;
            case 4:
                goal = "Use 'Shift' to select two blocks and assign them random colors";
                break;
        }
    }
}
