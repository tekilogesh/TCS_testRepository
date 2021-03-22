using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowbullets : MonoBehaviour
{
    public float moveSpeed = 20f;//Bullets move speed.

    public float damageOnenemy = 5f;// Damage on mob during collision.

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Mob"))
        {
            Debug.Log("Mob hit");
            gameObject.SetActive(false);
            other.GetComponent<MobHealth>().DecreaseHealth(damageOnenemy);
        }
    }
}
