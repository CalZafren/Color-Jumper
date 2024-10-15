using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCreditBlock : MonoBehaviour
{
    public Material white;
    public Material pink;
    public Material blue;
    public Material yellow;
    private MeshRenderer myMesh;
    private float timeTillChange;

    // Start is called before the first frame update
    void Start()
    {
        myMesh = GetComponent<MeshRenderer>();
        timeTillChange = Random.Range(2f,7f);
        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        timeTillChange -= Time.deltaTime;

        if(timeTillChange <= 0){
            ChangeColor();
            timeTillChange = Random.Range(2f,7f);
        }
    }

    void ChangeColor(){
        int colorNum = Random.Range(1, 5);

        switch(colorNum){
            case 1:
                myMesh.material = white;
                break;
            case 2:
                myMesh.material = pink;
                break;
            case 3:
                myMesh.material = blue;
                break;
            case 4: 
                myMesh.material = yellow;
                break;
        }
    }
}
