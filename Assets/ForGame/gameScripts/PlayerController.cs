using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    [SerializeField] bool IsJumpping = false;

    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        anim.SetFloat("walk", Mathf.Abs(moveInput));

        
        // Flip char
        if (moveInput != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && !IsJumpping)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jumpForce));

        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            IsJumpping = false;
            anim.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            IsJumpping = true;
            anim.SetBool("jump", true);
        }
    }
}

