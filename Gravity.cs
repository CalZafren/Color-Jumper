using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public float gravityScale = 1f;
    private float currentGravityScale;
    private float globalGravity = -9.81f;
    public float additionalLength;
    public bool grounded;
    public RaycastHit groundedObject;
    private Color rayColor;

    Rigidbody myRB;
    Collider myCol;
    private Transform target;

    void OnEnable(){
        FindComponents();
        myRB.useGravity = false;
        currentGravityScale = gravityScale;
    }

    void Update(){
      //Performs the ground check
      grounded = Physics.Raycast(myCol.bounds.center, Vector3.down, (myCol.bounds.extents.y) + additionalLength);
      Physics.Raycast(myCol.bounds.center, Vector3.down, out groundedObject, (myCol.bounds.extents.y) + additionalLength);
      

      //Handles functionality for grounded vs not grounded
      if(grounded){
        rayColor = Color.green;
        currentGravityScale = 0;
      }else{
        rayColor = Color.red;
        currentGravityScale = gravityScale;
      }
      //Draws the ray
      Debug.DrawRay(myCol.bounds.center, Vector3.down, rayColor, (myCol.bounds.extents.y) + additionalLength);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
      if(myRB != null){
        Vector3 gravity = globalGravity * currentGravityScale * Vector3.up;
        myRB.AddForce(gravity, ForceMode.Acceleration);
      }  
    }

    void FindComponents(){
      myRB = GetComponent<Rigidbody>();
      myCol = transform.GetComponent<Collider>();
    }
}
