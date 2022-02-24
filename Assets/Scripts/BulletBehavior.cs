using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float baseDamage;
    public float speed;
    public int bulletType;
    private Rigidbody2D bulletBody;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //TODO: bullet movement behavior
    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Environment")) Destroy(gameObject);
        if (collision.gameObject.CompareTag("Enemy")) Destroy(gameObject);
        if (collision.gameObject.CompareTag("PlayerBullet")) Destroy(gameObject);
    }

    public void FireAt(Vector3 lookDir)
    {
        bulletBody = GetComponent<Rigidbody2D>();
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;//angle in rad between x axis and the 2D vector;
        float bulletForceX = speed * Mathf.Cos(angle * Mathf.PI / 180.0f);
        float bulletForceY = speed * Mathf.Sin(angle * Mathf.PI / 180.0f);
        bulletBody.rotation = angle;
        bulletBody.AddForce(new Vector2(bulletForceX, bulletForceY), ForceMode2D.Impulse);
    }
    

}
