using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public int ammoQuan = 100;
    public int weaponType;
    public GameObject bullet;

    private float fireCD;
    private float fireTimer;

    void Start()
    {
        switch (weaponType)
        {
            case 0:
                fireCD = 0.2f; //5 bullets per second
                break;
            case 1:
                fireCD = 0.5f;
                break;
            case 2:
                fireCD = 1;
                break;
        }
        fireTimer = fireCD;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime;
        
    }

    public bool fire()
    {
        if (ammoQuan == 0) Destroy(gameObject);
     
        else if (fireTimer <= 0)
        {
            ammoQuan--;
            Vector2 lookDir = PlayerController.mousePos - PlayerController.playerRb.position;
            //TODO: Different Weapon(bullet spawn) behavior
            switch (weaponType)
            {
                case 0://rifle
                    BulletBehavior a0Bullet = Instantiate(bullet, transform.position, bullet.transform.rotation).GetComponent<BulletBehavior>();//bullet 0
                    //TODO: refactor to
                    a0Bullet.FireAt(lookDir);
                    break;
                case 1://shotgun
                    BulletBehavior a1Bullet = Instantiate(bullet, transform.position, bullet.transform.rotation).GetComponent<BulletBehavior>();//bullet 1
                    a1Bullet.FireAt(lookDir);
                    break;
                case 2://grenade launcher
                    BulletBehavior a2Bullet = Instantiate(bullet, transform.position, bullet.transform.rotation).GetComponent<BulletBehavior>();//bullet 2
                    a2Bullet.FireAt(lookDir);
                    break;
            }
            fireTimer = fireCD;
            return true;
        }

        return false;
        
    }
    
}
