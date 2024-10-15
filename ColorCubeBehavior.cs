using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCubeBehavior : MonoBehaviour
{
    public Material white;
    public Material black;
    public Material pink;
    public Material blue;
    public Material yellow;
    private Color myColor;
    private MeshRenderer myMesh;
    private Vector3 xMove = Vector3.right;
    private Vector3 yMove = Vector3.up;
    private Rigidbody myRB;
    private PlayerColorBehavior playerColor;

    // Start is called before the first frame update
    void Start()
    {
        myMesh = GetComponent<MeshRenderer>();
        myRB = GetComponent<Rigidbody>();
        playerColor = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerColorBehavior>().GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        myColor = myMesh.material.color;

        if(myColor == white.color || myColor == black.color){
            myRB.constraints = RigidbodyConstraints.FreezeAll;
        }else{
            myRB.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
        }

        if(myColor == blue.color){
            RunBlueCode();
            xMove = Vector3.right;
        }else if(myColor == yellow.color){
            RunYellowCode();
            yMove = Vector3.up;
        }else{
            yMove = Vector3.up;
            xMove = Vector3.right;
        }

        //Debug.Log(myRB.velocity);
    }

    //Will make the block travel up until it hits something, then travel down
    private void RunBlueCode(){
        transform.Translate(yMove * Time.deltaTime);
    }

    //Will make the block travel right until it hits something, then travel left
    private void RunYellowCode(){
        transform.Translate(xMove * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Player")){
            //Do nothing
        }else{
            //Reverses velocity on the blue blocks
            if(myColor == blue.color){
                yMove *= -1;
            }else if(myColor == yellow.color){
                xMove *= -1;
            }
        }
    }

    public void SetColor(Color color){
        myColor = color;
        
    }

    public Vector3 GetXMove(){
        return xMove;
    }

    public Vector3 GetYMove(){
        return yMove;
    }
}
