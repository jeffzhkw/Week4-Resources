using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerHealth = 100;
    public float staminaVal = 100;
    public float speed;
    public static float score;
    public GameObject currWeapon = null;
    public GameObject secWeapon = null;
    public Text healthText;
    public Text scoreText;
    public Text staminaText;
    public Text ammoQuanText;
    public Camera cam;

    private WeaponBehavior currWeaponBehavior;
    public static Rigidbody2D playerRb;
    
    private Vector2 movement;
    public static Vector2 mousePos;

    private SpriteRenderer playerSp;

    void Start()
    {
        score = 0;
        if (currWeapon)
        {
            currWeaponBehavior = currWeapon.GetComponent<WeaponBehavior>();
        };
        playerRb = GetComponent<Rigidbody2D>();
        playerSp = GetComponent<SpriteRenderer>();
    }
   


    // Update: triggers the movement;
    void Update()
    {
        if(playerHealth <= 0){
            SceneManager.LoadScene("Game Over");
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (currWeapon){
            ammoQuanText.text = "Ammo:" + currWeaponBehavior.ammoQuan.ToString();
        }
        else{
            ammoQuanText.text = "Ammo: 0";
        }
        if (Input.GetMouseButton(0))
        {
            //fire currWeapon, checking ammon in WeaponBehavior.cs
            if (currWeapon)
            {
                //Debug.Log("Ammo:" + currWeaponBehavior.ammoQuan);
                bool didFire = currWeaponBehavior.Fire();
            }
            else Debug.Log("No weapon on hand");
        }
        
        scoreText.text = "Score: " + score.ToString();
        healthText.text = "Health: " + playerHealth.ToString();
        staminaText.text = "Stamina: " + staminaVal.ToString();
        if (Input.GetKey(KeyCode.Space) && staminaVal >= 10)
        {
            speed = 15;
            staminaVal -= 10;
            Stamina.SetStamina(staminaVal/100f);
            StartCoroutine(wait3sec());        
        }
        else if (staminaVal < 100) {
            speed = 10;
            StartCoroutine(waithalfsec());
            staminaVal +=.5f;
            Stamina.SetStamina(staminaVal/100f);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(currWeapon && secWeapon) switchWeapon();

            else if(!currWeapon && secWeapon){
                setCurrWeapon(secWeapon);
                secWeapon = null;
            }
            else Debug.Log("No need to switch");
        }
        HealthBar.SetHealthBarValue(playerHealth/100f);
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
        //TODO: can pickup animation?
        if (other.gameObject.CompareTag("Weapon") && Input.GetKeyDown(KeyCode.E))//Have both equiped and press E
        {
            
            Destroy(currWeapon);//TODO?: drop effect?
            setCurrWeapon(other.gameObject);
        }
    }

    //TODO: Player heath manage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            playerHealth -= collision.gameObject.GetComponent<BulletBehavior>().baseDamage;
            StartCoroutine(FlashRed(playerSp));
           
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHealth -= 10;
            StartCoroutine(FlashRed(playerSp));
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

    IEnumerator wait3sec()
    {
        yield return new WaitForSeconds(3f);
    }

    IEnumerator waithalfsec()
    {
        yield return new WaitForSeconds(.5f);
    }

    IEnumerator FlashRed(SpriteRenderer aSprite)
    {
        aSprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        aSprite.color = Color.white;
    }

}
