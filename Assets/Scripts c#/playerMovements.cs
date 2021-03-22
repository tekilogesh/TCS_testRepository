using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovements : MonoBehaviour
{

    public float moveX; // Variable to store the value of an input.

    Rigidbody rb;

    public float moveSpeed; // speed to control playerMovement.

    public float jumpForce; // float value for jump.

    public float sphereRadius; // radius of an sphere to check whether player touches the ground.

    public bool isGrounded; // Bool to check ground.

    [SerializeField] Transform footPosition; // position of the player's foot.

    public LayerMask notPlayer;// A layer to neglect Player.
    public LayerMask enemylayer;// A layer to find enemy.

    [SerializeField] float clampPlayerXvelocity = 7f;// limit velocity of the player in xaxis.

    public bool lookingRight;// bool to check the player's forward.

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lookingRight = true;
    }


    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");

        //isGrounded = Physics.SphereCast(footPosition.position, sphereRadius, Vector3.down, out RaycastHit hitinfo, notPlayer);
        isGrounded = Physics.CheckSphere(footPosition.position, sphereRadius, notPlayer);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        rb.velocity = new Vector3(Mathf.Clamp(rb.velocity.x, -clampPlayerXvelocity, clampPlayerXvelocity), rb.velocity.y,rb.velocity.z);
        facingCheck();

        RaycastHit2D hit2D = Physics2D.Raycast(footPosition.position, Vector3.down, sphereRadius, enemylayer);

        if(hit2D == true)
        {
            if(hit2D.collider.CompareTag("Mob"))
            {
              
            }
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.right * moveX * moveSpeed *Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(footPosition.position, sphereRadius);
    }

    void facingCheck()
    {
        if (moveX == 0)
            return;

        if(moveX>0 && !lookingRight)
        {
            lookingRight = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(moveX<0 && lookingRight)
        {
            lookingRight = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void jump()
    {
        rb.AddForce(Vector2.up*jumpForce, ForceMode.Impulse);
    }
}
