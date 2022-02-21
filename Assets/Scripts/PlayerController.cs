using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerHealth = 100;
    public float speed;

    public GameObject currWeapon;
    public GameObject secWeapon;
    public Camera cam;

    private WeaponBehavior currWeaponBehavior;
    private Rigidbody2D playerRb;
    
    private Vector2 movement;
    private Vector2 mousePos;

    void Start()
    {
        if (currWeapon)
        {
            currWeaponBehavior = currWeapon.GetComponent<WeaponBehavior>();
        };
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update: triggers the movement;
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetKey(KeyCode.Space))
        {
            //fire currWeapon, checking ammon in WeaponBehavior.cs
            if (currWeapon)
            {
                Debug.Log("Ammo:" + currWeaponBehavior.ammoQuan);
                bool didFire = currWeaponBehavior.fire();
            }
            else Debug.Log("No weapon on hand");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(currWeapon && secWeapon) switchWeapon();

            else Debug.Log("No need to switch");
        }
    }

    //Player movement
    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - playerRb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg;//angle in rad between x axis and the 2D vector;
        playerRb.rotation = angle;
    }

    //Auto pick up weapon
    private void OnTriggerEnter2D(Collider2D other)
    {  
        if (other.gameObject.CompareTag("Weapon"))
        {
            if (!currWeapon) setCurrWeapon(other.gameObject);
            else if (!secWeapon) setSecWeapon(other.gameObject);  
        } 
    }

    //Player pickup weapon
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon") && Input.GetKeyDown(KeyCode.E))//Have both equiped and press E
        {
            Debug.Log("Here E");
            Destroy(currWeapon);//TODO?: drop effect?
            setCurrWeapon(other.gameObject);
        }
    }

    //TODO: Player heath manage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {

        }
        
    }

    //---Helper method.---//
    private void switchWeapon()
    {
        GameObject temp = currWeapon;
        setCurrWeapon(secWeapon);
        setSecWeapon(temp);   
    }

    private void setCurrWeapon(GameObject other)
    {
        currWeapon = other;
        other.transform.parent = gameObject.transform.GetChild(0);//attach to player's weapon pos
        other.transform.localPosition = new Vector3(0, 0, 0);
        other.transform.localScale = new Vector3(0.8f, 0.8f, 0);
        other.GetComponent<BoxCollider2D>().enabled = false;
        currWeaponBehavior = currWeapon.GetComponent<WeaponBehavior>();
    }

    private void setSecWeapon(GameObject other)
    {
        secWeapon = other;
        other.transform.parent = gameObject.transform;//attach to player's pos;
        other.transform.localPosition = new Vector3(0, 0, -1);
        other.transform.localScale = new Vector3(0.8f, 0.8f, 0);
        other.GetComponent<BoxCollider2D>().enabled = false;
    }
    
}
