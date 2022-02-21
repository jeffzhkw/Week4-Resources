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
            //TODO: Different Weapon(bullet spawn) behavior
            switch (weaponType)
            {
                case 0:
                    Instantiate(bullet, transform.position, bullet.transform.rotation);//bullet 0 
                    break;
                case 1:
                    Instantiate(bullet, transform.position, bullet.transform.rotation);//bullet 1
                    break;
                case 2:
                    Instantiate(bullet, transform.position, bullet.transform.rotation);//bullet 2
                    break;
            }
            fireTimer = fireCD;
            return true;
        }

        return false;
        
    }
    
}
