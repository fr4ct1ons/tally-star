using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] protected int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void DealDamage(int dmg) {
        health -= dmg;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
