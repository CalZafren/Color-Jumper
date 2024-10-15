using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player;

    public Vector2 min;
    public Vector2 max;
    private Vector3 clampedPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GetClampedPosition(player.position);
    }

    private Vector3 GetClampedPosition(Vector3 position){
        position.x = Mathf.Clamp(position.x, min.x, max.x);
        position.y = Mathf.Clamp(position.y, min.y, max.y);
        clampedPos = new Vector3(position.x, position.y, transform.position.z);
        return clampedPos;
        
    }
    
}
