using UnityEngine;

public class PlayerCont : MonoBehaviour {

    public Animator anim;

    public float speed = 15f;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    void Start () {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D> ();
    }

    private void FixedUpdate () {
        isGrounded = Physics2D.OverlapCircle (groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis ("Horizontal");
        rb.velocity = new Vector2 (moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0) {
            Flip ();
        } else if (facingRight == true && moveInput < 0) {
            Flip ();
        }

    }

    private void Update () {
        if (isGrounded == true) {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown (KeyCode.Space) && extraJumps > 0) {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if (Input.GetKeyDown (KeyCode.Space) && extraJumps == 0 && isGrounded == true) {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKeyDown (KeyCode.Space)) {
            anim.SetBool ("isJumping", true);
        } else {
            if (isGrounded == true) {
                anim.SetBool ("isJumping", false);
            }
        }

    }

    void Flip () {

        facingRight = !facingRight;
        transform.Rotate (0f, 180f, 0f);
        // Vector3 Scaler = transform.localScale;
        // Scaler.x *=-1;
        // transform.localScale = Scaler;

    }
}