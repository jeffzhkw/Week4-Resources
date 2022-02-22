using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float baseDamage;
    public float speed;
    public int bulletType;
    Rigidbody2D bulletBody;
    GameObject playerObj;
    // Start is called before the first frame update
    void Start()
    {
        bulletBody = GetComponent<Rigidbody2D>();
        playerObj = GameObject.Find("Player");
        Vector3 lookDir = playerObj.transform.position - bulletBody.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;//angle in rad between x axis and the 2D vector;
        float bulletForceX = speed * Mathf.Cos(angle * Mathf.PI / 180.0f);
        float bulletForceY = speed * Mathf.Sin(angle * Mathf.PI / 180.0f);
        //bulletBody.rotation = angle;
        bulletBody.AddForce(new Vector2(bulletForceX, bulletForceY), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Environment")) Destroy(gameObject);
        if (collision.gameObject.CompareTag("Player")) Destroy(gameObject);

        //TODO: Enemy Bullet will pass though enemy.

    }

    
}
