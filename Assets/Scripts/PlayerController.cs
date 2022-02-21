using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    public float playerHealth = 100;

    public GameObject currWeapon;
    public GameObject secWeapon;

    private WeaponBehavior currWeaponBehavior;
   
    void Start()
    {
        if (currWeapon.GetComponent<WeaponBehavior>())
        {
            currWeaponBehavior = currWeapon.GetComponent<WeaponBehavior>();
        };
    }

    // Update is called once per frame
    void Update()
    {
        

        playerMove();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //fire currWeapon, checking ammon in WeaponBehavior.cs
            Debug.Log(currWeaponBehavior.ammoQuan);
            bool didFire = currWeaponBehavior.fire();
            
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            switchWeaopn();
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        //TODO: PickUp Weapon
        if (other.gameObject.CompareTag("Weapon") && Input.GetKeyDown(KeyCode.E))
        {
            currWeapon = other.gameObject;
            currWeaponBehavior = currWeapon.GetComponent<WeaponBehavior>();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


    private void playerMove()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movingDir = (Vector3.right * horizontalInput + Vector3.up * verticalInput).normalized;
        transform.Translate(movingDir * speed * Time.deltaTime);
    }

    private void switchWeaopn()
    {
        GameObject temp;
        temp = currWeapon;
        currWeapon = secWeapon;
        secWeapon = currWeapon;
        currWeaponBehavior = currWeapon.GetComponent<WeaponBehavior>();
    }
    
}
