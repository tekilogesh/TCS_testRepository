using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class world : MonoBehaviour
{
    public Transform player;

    public float rotateSpeed= 10;

    public Vector3 direction;
    void Start()
    {
        
    }

    
    void Update()
    {
        direction = player.position - transform.position;
        transform.Rotate(direction.normalized* Time.deltaTime * rotateSpeed);
    }
}
