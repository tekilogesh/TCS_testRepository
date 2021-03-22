using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class END : MonoBehaviour
{
    public bool playerHasReachedEnd;

    public Transform cameraDuringFightpoint;

    Vector3 startPostion;

    Vector3 startDirection;

    bool switchedCamPostion;

    public Mob mobScript;
    void Start()
    {
        startPostion = Camera.main.transform.position;
        startDirection = Camera.main.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHasReachedEnd )
        {
            Camera.main.transform.position = cameraDuringFightpoint.position;
            Camera.main.transform.forward = cameraDuringFightpoint.forward;
            if (!switchedCamPostion)
            {
                Camera.main.orthographic = true;
                switchedCamPostion = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerControls.pc_instance.canAutoMove = false;
            SnowBall.sb_instance.canShoot = true;
            if (!playerHasReachedEnd)
            {
                playerHasReachedEnd = true;
            }
            mobScript.canShoot = true;
        }
    }
}
