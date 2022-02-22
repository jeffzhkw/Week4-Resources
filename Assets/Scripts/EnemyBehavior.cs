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
    void Start()
    {
        StartCoroutine(fireEnemyBullet());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator fireEnemyBullet()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            
            Instantiate(enemyBullet, transform.position + Vector3.right, enemyBullet.transform.rotation);
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

                    }
                    break;
                case 1:
                    if (bulletType == 1)
                    {

                    }
                    break;
                case 2:
                    if (bulletType == 2)
                    {

                    }
                    break;
            }
        }
    }
}
