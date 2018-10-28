using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public bool isDead = false;

    public float maxSpeed = 25f;
    public float acceleration = 0.2f;
    public float baseSpeed = 10f;
    public float speed;
    bool facingRight = true;

    private float baseMaxSpeed;
    private float baseAcceleration;
    private float baseJumpForce;

    public bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 900;

    public bool canDoubleJump = false;
    bool doubleJump = false;

    public float powerUpDuration;
    public bool isPoweredUp = false;
    public bool hasAntiGravity = false;
    public bool hasSpeedBoost = false;

    public float jetFuel = 0;
    public bool isStunned = false;
    public float stunnedDuration = 0;

    float move;

    private Animator anim;
    public Animation animation;

    private Rigidbody2D player;

    public float knockedBackDuration = 0f;

	// Use this for initialization
	void Start ()
    {
        speed = baseSpeed;
        baseMaxSpeed = maxSpeed;
        baseAcceleration = acceleration;
        baseJumpForce = jumpForce;

        anim = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (grounded)
        {
            doubleJump = false;
            
            if (player.velocity.y <= 0)
                anim.SetBool("Is Falling", false);

            if (speed < maxSpeed)
                speed += acceleration;

            if (speed > maxSpeed)
                speed = maxSpeed;
        }

        anim.SetFloat("Run Multiplier", speed*0.05f);


        //if (!grounded) return;        //If used, player cannot control character while in the air.

        move = Input.GetAxis("Horizontal");

        if (knockedBackDuration <= 0)
            player.velocity = new Vector2(move * speed, player.velocity.y);

        else
        {
            speed = baseSpeed;
            knockedBackDuration -= Time.deltaTime;
        }


        //player.AddForce(new Vector2(move*speed, 0));

        if (move > 0 && !facingRight && !isStunned && !isDead)
        {
            Flip();
            speed = baseSpeed;
        }
        else if (move < 0 && facingRight && !isStunned && !isDead)
        {
            Flip();
            speed = baseSpeed;
        }

        if (move != 0)
            anim.SetBool("Is Running", true);


        if (move == 0 /*|| previousPosition == player.transform.position*/)
        {
            anim.SetBool("Is Running", false);
            speed = baseSpeed;
        }

        if (!grounded)
        {
            anim.SetBool("Is Running", false);
            
            if (player.velocity.y != 0)
                anim.SetBool("Is Falling", true);
        }
    }



    void Update()
    {
        //previousPosition = player.transform.position;

        if((grounded || !doubleJump && canDoubleJump) && Input.GetKeyDown(KeyCode.Space) && jetFuel <= 0)
        {
            player.velocity = new Vector2(player.velocity.x, 0);
            player.AddForce(new Vector2(0, jumpForce));

            if (!doubleJump && !grounded)
            {
                doubleJump = true;
                anim.SetTrigger("Double Jump");
            }
        }

        if (isPoweredUp)
        {
            powerUpDuration -= Time.deltaTime;

            if (powerUpDuration <= 0 && jetFuel <= 0)
            {
                powerDown();
            }
        }

        if (isStunned)
        {
            stunnedDuration -= Time.deltaTime;

            if (stunnedDuration <= 0)
            {
                isStunned = false;

                maxSpeed = baseMaxSpeed;
                jumpForce = baseJumpForce;
                speed = baseSpeed;
            }
        }

        if (jetFuel > 0 && Input.GetKey(KeyCode.Space) && !isStunned)
        {
            anim.SetBool("Is Flying", true);
            jetFuel -= Time.deltaTime;
            player.AddForce(new Vector2(0, 75));
            if (player.velocity.y > maxSpeed/2f)
            {
                player.velocity = player.velocity.normalized * maxSpeed/2f;
            }
        }
        
        else
            anim.SetBool("Is Flying", false);

        if (isDead)
        {
            maxSpeed = 0;
            jumpForce = 0;
            anim.SetBool("Is Running", false);

            if (isPoweredUp)
                powerDown();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void powerDown()
    {
        isPoweredUp = false;
        jetFuel = 0;
        powerUpDuration = 0;

        if (hasAntiGravity)
        {
            jumpForce /= 1.5f;
            canDoubleJump = false;
            hasAntiGravity = false;
        }

        if (hasSpeedBoost)
        {
            maxSpeed /= 2f;
            speed = maxSpeed;
            acceleration /= 1000f;
            hasSpeedBoost = false;
        }

    }
}
