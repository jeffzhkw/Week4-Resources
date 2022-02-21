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
    public Camera cam;

    private WeaponBehavior currWeaponBehavior;
    private Rigidbody2D playerRb;
    
    private Vector2 movement;
    private Vector2 mousePos;

    void Start()
    {
        if (currWeapon.GetComponent<WeaponBehavior>())
        {
            currWeaponBehavior = currWeapon.GetComponent<WeaponBehavior>();
        };
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update triggers the movement;
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
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

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - playerRb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg;//angle in rad between x axis and the 2D vector;
        playerRb.rotation = angle;
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

    private void switchWeaopn()
    {
        GameObject temp;
        temp = currWeapon;
        currWeapon = secWeapon;
        secWeapon = currWeapon;
        currWeaponBehavior = currWeapon.GetComponent<WeaponBehavior>();
    }
    
}
