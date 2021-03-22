using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHealth : MonoBehaviour
{
    public float maxHealth = 30;// Health at start.

    public float currentHealth;// health per update.

    public Mob mobsScript;
    void Start()
    {
        mobsScript = GetComponent<Mob>();
        currentHealth = maxHealth;
    }

    
    void Update()
    {
        if(currentHealth<=0)
        {
            mobsScript.isDead = true;
        }
    }

    public void DecreaseHealth(float _damage)
    {
        currentHealth -= _damage;
    }

    private void OnDisable()
    {
        currentHealth = maxHealth;
    }


}
