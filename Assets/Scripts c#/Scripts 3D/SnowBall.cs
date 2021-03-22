using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    public static SnowBall sb_instance;
    private void Awake()
    {
        if (sb_instance == null)
        {
            sb_instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public Transform snowBallPoint;// snow ball position.

    public float increseValue;// this value is to increase the size of the snow ball.

    public float decreaseValue;// this value is to decrease the size of the snow ball.

    public float ammoValue = 0.05f;// his value is to increase the size of the snow ball when the player tries to shoot the mob.

    public bool canShoot;// bool to lock the shooting ability.

    public Transform[] fireports;// fireports arre the place where the bullets gets spawned.

    public GameObject snowAmmoPrefab;// Prefab of the ammo that the player shoots at mob.

    public float laserDistance;// distance required to cast ray.

    public LayerMask mobLayer;// Layer to detect the mob.

    void Start()
    { 
    }

    
    void Update()
    {
        transform.position = new Vector3(snowBallPoint.position.x,snowBallPoint.position.y+transform.localScale.y/2,snowBallPoint.position.z + transform.localScale.z/2);
        Shoot();
    }
    // The below function is to alter the size of the snow ball.
    public void AlterSize(float _Value)
    {
        if (transform.localScale.magnitude > 0.2f)
            transform.localScale = transform.localScale + new Vector3(_Value, _Value, _Value);
        else
            canShoot = false;
    }
    // This below function enables the ability to shoot at mob.
    public void Shoot()
    {
        if(canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < fireports.Length; i++)
            {
                Instantiate(snowAmmoPrefab, fireports[i].position, fireports[i].rotation);
                AlterSize(ammoValue);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Add"))
        { 
            AlterSize(increseValue);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("Remove"))
        {
            AlterSize(decreaseValue);
            Destroy(collision.gameObject);
        }
    }
}
