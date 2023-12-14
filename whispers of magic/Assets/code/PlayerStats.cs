using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int lives = 2;
    public float flickerDura1on = 0.1f;
    private float flickerTime = 0f;
    private SpriteRenderer spriteRenderer;
    public bool isImmune = false;
    public float immunityDura1on = 1.5f; //el w2t ely sonic 3mal ynor w ytfy
    private float immunityTime = 0f;

    private Animator animator;
    Rigidbody2D rb2d;

    public Image healthBar;
    public Image heartBar;

    // public int coinsCollected = 0;
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        //StartCoroutine(DestroyAfterDelay());
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDura1on)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (this.isImmune == false)
        {
            this.health = this.health - damage;
            healthBar.fillAmount = (float)this.health / 100f;

            if (this.health < 0f)
                this.health = 0;

            if (this.lives > 0f && this.health == 0f)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 100;
                this.lives--;
                heartBar.fillAmount -= 0.1f;
                ResetFillAmount();
            }
            else if (this.lives == 0 && this.health == 0)
            {
                (new NavigationController()).GoToGameOver();
                heartBar.fillAmount = 0f;
                Debug.Log("Gameover"); //add game over splash screen
                animator.SetTrigger("isDead");
                if (rb2d != null)
                {
                    rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
                }
                Destroy(gameObject, 4.0f);
            }
            Debug.Log("Player Health : " + this.health.ToString());
            Debug.Log("Player Lives : " + this.lives.ToString());
        }
        PlayHitReac1on();
    }

    void PlayHitReac1on()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }

    void SpriteFlicker()
    {
        if (this.flickerTime < this.flickerDura1on)
        {
            this.flickerTime = this.flickerTime + Time.deltaTime;
        }
        else if (this.flickerTime >= this.flickerDura1on)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }

    void ResetFillAmount()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = 1f;  // Set to 1 for maximum fill
        }
        else
        {
            Debug.LogWarning("Image component not assigned.");
        }
    }
} 