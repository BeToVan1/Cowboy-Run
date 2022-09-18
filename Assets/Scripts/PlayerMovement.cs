using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _boxcollider;
    public float JumpForce;
    public float MovementSpeed = 1;
    public bool facingRight = true;
    public Animator animator;
    public float jumpTime;
    private float jumpTimeCounter;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    public GameManager theGameManager;
    private float speedMilestoneCountStore;
    private float moveSpeedStore;
    public float speedIncreaseMilestoneStore;

    public AudioSource jumpSound;
    public AudioSource deathSound;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxcollider = GetComponent<BoxCollider2D>();
        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = MovementSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
    }

    private void Update()
    {
        //var movement = Input.GetAxis("Horizontal");

        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone += speedIncreaseMilestone * speedMultiplier;

            MovementSpeed = MovementSpeed * speedMultiplier;
        }

        transform.position += new Vector3(1, 0, 0) * Time.deltaTime * MovementSpeed;

        animator.SetFloat("Speed", 1);

        //if (movement < 0 && facingRight)
            //();
        //else if (movement > 0 && !facingRight)
            //flip();

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            //_rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, JumpForce);
            animator.SetBool("isJumping", true);
            //jumpSound.Play();
            
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if (jumpTimeCounter > 0)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, JumpForce);
                animator.SetBool("isJumping", true);
                jumpTimeCounter -= Time.deltaTime;
                jumpSound.Play();
            }
            
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            jumpTimeCounter = 0;
        }
        if(transform.position.y <= -6.63)
        {
            deathSound.Play();
            theGameManager.RestartGame();
            MovementSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            animator.SetBool("isJumping", false);
            jumpTimeCounter = jumpTime;
        }
        else if(collision.gameObject.tag == "death")
        {
            deathSound.Play();
            theGameManager.RestartGame();
        }
        
    }

    /*private void flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }*/
}

