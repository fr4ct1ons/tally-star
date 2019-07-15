using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject myEnemy;
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
        Instantiate(myEnemy, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeBetweenShots / 2f);
        canShoot = true;
    }
}
