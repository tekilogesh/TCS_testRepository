using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public float moveSpeed;// float variable to assign speed.
    
    public Transform[] patrolPoints;// patrol points for the mob to move in between.

    [SerializeField] Transform target;

    public bool isDead;
    void Start()
    {
       
        target = patrolPoints[1];
    }

   
    void Update()
    {
        if (!isDead)
        {
            if (Vector3.Distance(transform.position, target.position) < 0.2f)
            {
                if (target == patrolPoints[0])
                    target = patrolPoints[1];
                else if (target == patrolPoints[1])
                    target = patrolPoints[0];
            }
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            Death();
        }
        
    }

    void Death()
    {
        All_UI.ui_instance.
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        isDead = false;       
    }


}
