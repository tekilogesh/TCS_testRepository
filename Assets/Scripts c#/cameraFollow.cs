using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform targetToFollow; // Target 

    public float speed; // moveSpeed 

    public Vector2 offset;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,new Vector3(targetToFollow.position.x+offset.x,targetToFollow.position.y+offset.y,transform.position.z), speed*Time.fixedDeltaTime);
    }
}
