using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform target;

    public float lerpSpeed;
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed*Time.fixedDeltaTime);
    }
}
