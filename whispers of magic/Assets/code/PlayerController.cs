using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public float moveSpeed; //how fast the character moves
    public float jumpHeight; //how hight the character jump

    public bool isFacingRight; //check if the character facing right
    public KeyCode Spacebar; //character will jump by click on the spacebar

    //KEYCODE Y3NY BUTTON F EL KEYBOARD
    public KeyCode L; //L is the name we gave a keyboard button we chose to be the left movement button
    public KeyCode R; //R is the name we gave a keyboard button we chose to be the right movement button

    public Transform groundCheck; //we use it to see if the player is touching the ground

    public float groundCheckRadius; //close ad eh to the ground

    public LayerMask whatIsGround; //this variable stores what is considred a ground to the character
    private bool grounded; //check if the character is standing on soild ground

    private Animator anim;
    public CoinPickup cm;

    public Transform firePoint;
    public GameObject bullet;
    public GameObject bullet1;
    public KeyCode s;
    public KeyCode x;//s is the name we gave a keyboard button we chose 3shan adrb naar 3la el enemy


    //sooot lma b jump
    public AudioClip jump1;
    public AudioClip jump2;

    public float shootCooldown = 0.5f; // Set the desired cooldown time
    private bool canShoot = true; // Flag to control shooting cooldown


    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>(); //b3ml l el ' anim ' initialization f el start
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(s) && canShoot)
        { //When user presses the s buXon

            anim.SetBool("Shoot", true);
            Shoot();
            StartCoroutine(ShootCooldown()); // Start the cooldown timer
        }
            //Instantiate(bullet, firePoint.position, firePoint.rotation);

        
        if (Input.GetKeyDown(x) && canShoot) //When user presses the s buXon
        {
            Shoot1();
            StartCoroutine(ShootCooldown()); // Start the cooldown timer

            //Instantiate(bullet, firePoint.position, firePoint.rotation);

        }
        if (Input.GetKeyDown(Spacebar) && grounded) //When user presses the space buXon once
        {
            Jump();
        }
        if (Input.GetKey(L)) //When user presses the leY arrow buXon
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            if (isFacingRight) //eza bass ymeen
            {
                Flip(); //b3mlo flip
                isFacingRight = false; //w b5ly isFacingRight b false
            }
        }
        if (Input.GetKey(R)) //When user presses the right arrow buXon
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (!isFacingRight) //eza msh bass ymeen
            {
                Flip(); //b3mlo flip
                isFacingRight = true; //w b5ly isFacingRight b true
            }
        }
        anim.SetBool("Grounded", grounded); //check if grounded true or falce, true: state Idel, false: state jump

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x)); //bna5od el velocity bta3t el player w nohtha f el speed

    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    void Flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            audioManager.PlaySFX(audioManager.coin);
            Destroy(other.gameObject);
            cm.coinCount++;
        }
    }
    void Shoot()
    {
        audioManager.PlaySFX(audioManager.shoot1);
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);

        // Check the facing direction and adjust the bullet's scale accordingly
        if (!isFacingRight)
        {
            // If facing left, flip the bullet by changing its local scale
            Vector3 newScale = newBullet.transform.localScale;
            newScale.x *= -1;
            newBullet.transform.localScale = newScale;
        }
    }
    void Shoot1()
    {
        audioManager.PlaySFX(audioManager.shoot2);
        GameObject newBullet = Instantiate(bullet1, firePoint.position, firePoint.rotation);

        // Check the facing direction and adjust the bullet's scale accordingly
        if (!isFacingRight)
        {
            // If facing left, flip the bullet by changing its local scale
            Vector3 newScale = newBullet.transform.localScale;
            newScale.x *= -1;
            newBullet.transform.localScale = newScale;
        }
    }
    IEnumerator ShootCooldown()
    {
        canShoot = false; // Set to false to prevent shooting during cooldown
        yield return new WaitForSeconds(shootCooldown);
        GetComponent<Animator>().SetBool("Shoot", false);
        canShoot = true; // Set to true after the cooldown period
    }

}