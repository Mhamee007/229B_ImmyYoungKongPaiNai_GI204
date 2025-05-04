using UnityEngine;
using UnityEngine.Events;
public class PlayerController : MonoBehaviour
{

    Rigidbody2D rd2D;
    Vector2 moveInput;
    bool isGrounded;
    bool isJump = false;

     float horizontalMove = 0f;

    [SerializeField] float speed = 40f;
    [SerializeField] float jumpForce = 30f;
    public CharacterController controller2D;
    public Animator animator;

    void Start()
    {
        rd2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rd2D.AddForce(moveInput * speed);
//animator.SetFloat("walk", moveInput);

        if (Input.GetButtonDown("Jump") && !isJump)
        {
            rd2D.AddForce(new Vector2(rd2D.velocity.x, jumpForce));
            isJump = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJump = true;
        }
    }
}
