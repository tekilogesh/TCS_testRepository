using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public float moveSpeed;// float variable to assign speed.
    float currentSpeed;
    
    public Transform[] patrolPoints;// patrol points for the mob to move in between.

    [SerializeField] Transform target;

    public bool isDead;

    public All_UI all_UI;

    public Transform[] fireports;

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
                move();
                currentSpeed = moveSpeed * 4;
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
    void fire()
    {
        if(currentFirerate<=0)
        {
            currentFirerate = fireRate;
            for (int i = 0; i <fireports.Length; i++)
            {
                GameObject temp = Instantiate(enemybulletsPrefab, fireports[i].position, fireports[i].rotation);
                temp.transform.forward = fireports[i].forward;
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
