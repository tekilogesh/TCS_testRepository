using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public static PlayerControls pc_instance;// making sure only one instance is available.

    private void Awake()
    {
        if (pc_instance == null)
        {
            pc_instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public bool canAutoMove;

    public float moveSpeed;// float to control player speed.

    public GameObject Sphere;// snow ball gameobject.

    public float clampX; // float to clamp the X position of the player.

    public float moveValue;// float to calculate input for horizontal.
    void Start()
    {
        Time.timeScale = 1;
    }

    
    void Update()
    {
        moveValue = Input.GetAxisRaw("Horizontal");
        if (canAutoMove)
        {
            transform.Translate(new Vector3(moveValue * moveSpeed, 0, moveSpeed) * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -clampX, clampX), transform.position.y, transform.position.z);
        }
        else
        {
            transform.Translate(new Vector3(moveValue * moveSpeed, 0, 0) * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -clampX, clampX), transform.position.y, transform.position.z);
        }
    }

    
}
