using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGrab : MonoBehaviour
{
    public bool canGrab;// bool to check whether player is near any grabbable item.

    public bool isholding;// bool  to check whether player is holding any obejcts.

    public float range;// float for the range of raycast. 

    public LayerMask l_grabbable;// to detect grabbable items.

    public GameObject temp;// to store the currentGrabbable item.

    public Transform holdPoint;
    public KeyCode grabKey;
    public KeyCode dropKey;
    void Start()
    {
        
    }

   
    void Update()
    {
        canGrab = Physics2D.Raycast(transform.position, transform.right, range, l_grabbable);

        if(canGrab && Input.GetKeyDown(grabKey) && !isholding)
        {
            grab();
        }
        else if(isholding && Input.GetKeyDown(dropKey))
        {
            drop();
        }

        if(isholding)
        {
            temp.transform.position = holdPoint.position;
        }
    }
    void grab()
    {
        temp = grabbableObject();
        if (temp)
        {
            Destroy(temp.GetComponent<Rigidbody2D>());
            temp.GetComponent<Collider2D>().isTrigger = true;
            isholding = true;
        }
    }

    void drop()
    {
        temp.AddComponent<Rigidbody2D>();
        isholding = false;
        temp.GetComponent<Collider2D>().isTrigger = false;
        temp = null;
    }
    GameObject grabbableObject()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.right, range, l_grabbable);
        if (hit2D)
        {
            return hit2D.collider.gameObject;
        }
        else
            return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position+ transform.right * range);
    }
}
