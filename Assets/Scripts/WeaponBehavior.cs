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
    private AudioSource audio;

    public AudioSource pickUpAudio;
    
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
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime;
        
    }

    public bool Fire()
    {
        if (ammoQuan == 0) Destroy(gameObject);
     
        else if (fireTimer <= 0)
        {
            ammoQuan--;
            audio.Play();
            Vector3 fireDir = PlayerController.mousePos - PlayerController.playerRb.position;
            //TODO: Different Weapon(bullet spawn) behavior
            switch (weaponType)
            {
                case 0://rifle
                    BulletBehavior a0Bullet = Instantiate(bullet, transform.position, bullet.transform.rotation).GetComponent<BulletBehavior>();//bullet 0
                    //TODO: refactor to
                    a0Bullet.FireAt(fireDir);
                    break;
                case 1://shotgun
                    for(int i = 0; i < 5; i++)
                    {
                        BulletBehavior a1Bullet = Instantiate(bullet, transform.position, bullet.transform.rotation).GetComponent<BulletBehavior>();//bullet 1
                        //bullet.transform.Rotate(new Vector3(0, 0, (20 * (i - 2))));
                        a1Bullet.FireAt(Quaternion.Euler(0, 0, (20f * (i - 2))) * fireDir.normalized);
                    }
                    
                    break;
                case 2://grenade launcher
                    BulletBehavior a2Bullet = Instantiate(bullet, transform.position, bullet.transform.rotation).GetComponent<BulletBehavior>();//bullet 2
                    a2Bullet.FireAt(fireDir);
                    break;
            }
            fireTimer = fireCD;
            return true;
        }

        return false;
        
    }

    public void PlayPickUp()
    {
        pickUpAudio.Play();
    }
    

    
}
