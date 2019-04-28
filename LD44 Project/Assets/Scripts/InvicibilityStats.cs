using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvicibilityStats : Stats
{

    [SerializeField] float invicibilityTime;
    [SerializeField] SpriteRenderer mySprite;

    bool canTakeDamage = true;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DealDamage(int dmg)
    {
        if (canTakeDamage)
        {
            health -= dmg;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            else
                StartCoroutine(Blink());
        }
    }

    private IEnumerator Blink()
    {
        bool blink = true;
        canTakeDamage = false;
        for(float i = 0; i < invicibilityTime; i+=0.25f)
        {
            if (blink)
                mySprite.color = Color.clear;
            else
                mySprite.color = Color.white;

            yield return new WaitForSeconds(0.25f);
            blink = !blink;
        }
        mySprite.color = Color.white;
        canTakeDamage = true;
    }
}
