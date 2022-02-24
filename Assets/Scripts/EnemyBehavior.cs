using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100;
    public float speed;
    public float spawnRate = 1;
    public int enemyType;
    public GameObject enemyBullet;

    public float closestDistance = 4f;
    public float circlePlayer = 0;  //-1 for clockwise, 0 for none, 1 for anticlockwise
    public ParticleSystem explode;
    private GameObject playerObj;

    void Start()
    {
        playerObj = GameObject.Find("Player");
        StartCoroutine(fireEnemyBullet());
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
         
            Destroy(gameObject);
            Instantiate(explode, transform.position, explode.transform.rotation);
            
        }

        Vector3 dirToPlayer = (playerObj.transform.position - transform.position).normalized;
        float disToPlayer = (playerObj.transform.position - transform.position).magnitude;
        if (disToPlayer < closestDistance)
            transform.position += Vector3.Cross(Vector3.forward, dirToPlayer) * circlePlayer * speed*Time.deltaTime;      
        else
            transform.position += dirToPlayer * speed * Time.deltaTime;


        Vector2 lookDir = PlayerController.playerRb.position - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;//angle in rad between x axis and the 2D vector;
        transform.rotation = transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    IEnumerator fireEnemyBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            BulletBehavior aEBullet = Instantiate(enemyBullet, transform.position, enemyBullet.transform.rotation).GetComponent<BulletBehavior>();
            aEBullet.FireAt(PlayerController.playerRb.position- new Vector2(transform.position.x, transform.position.y));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            int bulletType = collision.gameObject.GetComponent<BulletBehavior>().bulletType;
            float bulletBaseDamage = collision.gameObject.GetComponent<BulletBehavior>().baseDamage;
            //TODO: bonus damage
            switch (enemyType)
            {
                case 0:
                    if (bulletType == 0)
                    {
                        health -= bulletBaseDamage*1.5f;
                    }
                    health -= bulletBaseDamage;
                    break;
                case 1:
                    if (bulletType == 1)
                    {
                        health -= bulletBaseDamage * 1.5f;
                    }
                    health -= bulletBaseDamage;
                    break;
                case 2:
                    if (bulletType == 2)
                    {
                        health -= bulletBaseDamage * 1.5f;
                    }
                    health -= bulletBaseDamage;
                    break;
            }
        }
    }

    
}
