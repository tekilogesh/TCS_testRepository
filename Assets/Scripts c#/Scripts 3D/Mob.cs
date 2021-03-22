using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public float moveSpeed;// float variable to assign speed.
    float currentSpeed;
    
    public Transform[] patrolPoints;// patrol points for the mob to move in between.

    public Transform[] fastPatrolPoints;

    [SerializeField] Transform target;

    public bool isDead;

    public All_UI all_UI;

    public Transform fireports;

    public Transform[] fireportsArray;

    public float fireRate;
    [SerializeField] float currentFirerate;
    public bool canShoot;
    public GameObject enemybulletsPrefab;
    public enum mobStates
    {
        MOB_NOOB,
        MOB_QUAD,
        MOB_FAST,
    }

    public mobStates currentMobState;

    void Start()
    {
        all_UI = GameObject.Find("ALL_UI").GetComponent<All_UI>();

        if (currentMobState == mobStates.MOB_QUAD)
            target = fastPatrolPoints[0];
        else
            target = patrolPoints[1];
    }

   
    void Update()
    {if(currentFirerate>0)
        {
            currentFirerate -= Time.deltaTime;
        }
        switch (currentMobState)
        {
            case mobStates.MOB_NOOB:
                currentSpeed = moveSpeed;
                move();
                break;
            case mobStates.MOB_QUAD:
                currentSpeed = moveSpeed * 2;
                move();
                if(canShoot)
                fire();
                break;
            case mobStates.MOB_FAST:
                currentSpeed = moveSpeed * 4;
                if (canShoot)
                    firemoreAmmo();
                break;
            default:
                break;
        }
        if (!isDead)
        {
            move();
        }
        else
        {
            Death();
        }
    }
    void move()
    {
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            if (target == patrolPoints[0])
                target = patrolPoints[1];
            else if (target == patrolPoints[1])
                target = patrolPoints[0];
        }
        transform.position = Vector3.MoveTowards(transform.position, target.position, currentSpeed * Time.deltaTime);
    }

    void teleport()
    {
        //if (Vector3.Distance(transform.position, target.position) < 0.2f)
        //{
        //    if (target == fastPatrolPoints[0])
        //        target = fastPatrolPoints[1];
        //    else if (target == fastPatrolPoints[1])
        //        target = fastPatrolPoints[2];
        //    else if (target == fastPatrolPoints[2])
        //        target = fastPatrolPoints[3];
        //    else if (target == fastPatrolPoints[3])
        //        target = fastPatrolPoints[4];
        //    else if (target == fastPatrolPoints[4])
        //        target = fastPatrolPoints[5];
        //    else if (target == fastPatrolPoints[5])
        //        target = fastPatrolPoints[6];
        //    else if (target == fastPatrolPoints[6])
        //        target = fastPatrolPoints[7];
        //    else if (target == fastPatrolPoints[7])
        //        target = fastPatrolPoints[8];
        //    else if (target == fastPatrolPoints[8])
        //        target = fastPatrolPoints[9];
            
        //}
    }
    void fire()
    {
        if(currentFirerate<=0 && fireports)
        {
            currentFirerate = fireRate;
           
            {
                GameObject temp = Instantiate(enemybulletsPrefab, fireports.position, fireports.rotation);
   
                Destroy(temp, 2f);
            }
        }
    }

    void firemoreAmmo()
    {
        if(currentFirerate<=0 && fireportsArray.Length>0)
        {
            currentFirerate = fireRate;
            for (int i = 0; i < fireportsArray.Length; i++)
            {
                GameObject temp = Instantiate(enemybulletsPrefab, fireportsArray[i].position, fireportsArray[i].rotation);
                Destroy(temp, 2f);
            }
        }
    }
    void Death()
    {
        all_UI.levelWon = true;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        isDead = false;       
    }


}
