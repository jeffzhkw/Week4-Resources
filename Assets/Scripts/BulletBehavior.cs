using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float baseDamage;
    public float speed;
    public int bulletType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            int enemyType = collision.gameObject.GetComponent<EnemyBehavior>().enemyType;
            //TODO: bonus damage
            switch (bulletType)
            {
                case 0:
                    if(enemyType == 0)
                    {

                    }
                    break;
                case 1:
                    if (enemyType == 1)
                    {

                    }
                    break;
                case 2:
                    if (enemyType == 2)
                    {

                    }
                    break;
            }
        }

        else if (collision.gameObject.CompareTag("Environment")) Destroy(gameObject);

        
    }
}
