using UnityEngine;

public class Movement : MonoBehaviour
{

    private float idleTime = 5f;
    private float idleTimer = 0f;
    private float runTime = 5f;
    private float runTimer = 0f;
    private float jumpTime = 5f;
    private float jumpTimer = 0f;
    private bool isIdle = true;
    private bool isJump = false;
    private float direction = 1f; // Current movement direction (1 = right, -1 = left)
    // private SpriteRenderer TofuSprite;
    private Animator TofuAnimator;

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey("space"))
       {
            if (!isJump)
            {
                isJump = true;
                TofuAnimator.Play("tofu_jump");
                jumpTime = 1f;
            }
       }
       
       if (isJump)
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer >= jumpTime)
            {
                jumpTimer = 0f;
                runTimer = 0f;
                isJump = false;
                isIdle = true;
                idleTime = Random.Range(3f, 8f);
                idleTimer = 0f;
                TofuAnimator.Play("tofu_idle");
            }
        }
        else if (isIdle)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleTime)
            {
                idleTimer = 0f;
                isIdle = false;
                runTime = Random.Range(3f, 8f);
                TofuAnimator.Play("tofu_walk");
            }
        } 
        else 
        {
            runTimer += Time.deltaTime;
            if (runTimer >= runTime)
            {
                runTimer = 0f;
                isIdle = true;
                idleTime = Random.Range(3f, 8f);
                TofuAnimator.Play("tofu_idle");
            }
            // Move the object horizontally
            transform.Translate(Vector2.right * 0.5f * direction * Time.deltaTime);

            // Check if the object reaches the boundaries and change the direction
            if (transform.position.x <= -2f)
            {
                direction = 1f; // Change to move right
                Vector3 NewScale = transform.localScale;
                NewScale.x *= -1;
                transform.localScale = NewScale;
            }
            else if (transform.position.x >= 2f)
            {
                direction = -1f; // Change to move left
                Vector3 NewScale = transform.localScale;
                NewScale.x *= -1;
                transform.localScale = NewScale;
            }
        }
    }

    void Start()
    {
        // TofuSprite = this.GetComponent<SpriteRenderer>();
        TofuAnimator = this.GetComponent<Animator>();
        TofuAnimator.Play("tofu_idle");
        isIdle = true;
    }
}
