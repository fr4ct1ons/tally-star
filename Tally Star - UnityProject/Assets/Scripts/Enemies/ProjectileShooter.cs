using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    
    [SerializeField] GameObject myProjectile;
    [SerializeField] float timeBetweenShots;

    bool canShoot = true;
    Vector2 bufferVector;

    // Start is called before the first frame update
    void Start()
    {
        bufferVector = FindObjectOfType<PlayerController>().gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
            StartCoroutine(WaitBeforeShooting());
    }

    private IEnumerator WaitBeforeShooting()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShots / 2f);
        GameObject newBullet = Instantiate(myProjectile, transform.position, Quaternion.identity);
        newBullet.tag = "Enemy";
        newBullet.layer = 11;
        int newX, newY;
        do
        {
            newX = Random.Range(-1, 2);
            newY = Random.Range(-1, 2);
        } while (newX == 0 && newY == 0);
        newBullet.GetComponent<Projectile>().SetDirection(newX, newY);
        yield return new WaitForSeconds(timeBetweenShots / 2f);
        canShoot = true;
    }
}
