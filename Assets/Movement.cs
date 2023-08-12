using UnityEngine;

public class Movement : MonoBehaviour
{

    private float direction = 1f; // Current movement direction (1 = right, -1 = left)
    SpriteRenderer TofuSprite;
    Animator TofuAnimator;

    // Update is called once per frame
    void Update()
    {
        
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

    void Start()
    {
        TofuSprite = this.GetComponent<SpriteRenderer>();
        TofuAnimator = this.GetComponent<Animator>();
        TofuAnimator.Play("tofu_walk");

    }
}