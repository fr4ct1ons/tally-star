using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAtk : BaseAct
{
    [SerializeField] GameObject projectileToShoot;

    float countdown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown > 0)
            countdown -= Time.deltaTime;
    }

    

    public override void DoAction()
    {
        if (countdown <= 0)
        {
            Debug.Log("Base ranged attack");
            float x = (float)GetComponent<PlayerController>().GetHorizontalLook();
            float y = (float)GetComponent<PlayerController>().GetVerticalLook();
            GameObject newProjectile = Instantiate(projectileToShoot, transform.position, Quaternion.identity);
            newProjectile.GetComponent<Projectile>().SetDirection(x, y);
            newProjectile.tag = "Player";
            newProjectile.layer = 10;
            countdown = cooldown;
        }
    }
}
