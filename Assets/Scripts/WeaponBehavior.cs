using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public int ammoQuan = 100;
    public int weaponType;
    public GameObject bullet;

    private int fireRate;

    void Start()
    {
        switch (weaponType)
        {
            case 0:
                fireRate = 10; //10 bullets per second
                break;
            case 1:
                fireRate = 5;
                break;
            case 2:
                fireRate = 1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool fire()
    {
        if (ammoQuan == 0)
        {
            return false;
        }
        else
        {
            ammoQuan--;
            //TODO: fireRate;
            switch (weaponType)//TODO: Different Weapon behavior
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                

            }
            Instantiate(bullet, transform.position, bullet.transform.rotation);//bullet
            return true;
        }
    }
    
}
