using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] protected float speed;
    [SerializeField] protected int damage;

    protected Vector2 bufferVector;
    protected float dirX, dirY;

    // Start is called before the first frame update
    void Start()
    {
        bufferVector = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        bufferVector.Set(transform.position.x + dirX, transform.position.y + dirY);
        transform.position = Vector2.MoveTowards(transform.position, bufferVector, speed * Time.deltaTime);
    }

    public void SetDirection(float x, float y)
    {
        dirX = x;
        dirY = y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Stats>())
            collision.GetComponent<Stats>().DealDamage(damage);
        Destroy(gameObject);
    }
}
