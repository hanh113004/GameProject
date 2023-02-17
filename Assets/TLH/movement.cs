using UnityEngine;

public class movement : MonoBehaviour
{
    private float horizontal;
    private float speed = 3f;
    float parryForce=8f;
    [SerializeField] private float jumpingPower = 6f;
    private bool isFacingRight = true;
    [SerializeField] Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] KeyCode parry;
    [SerializeField] LayerMask bounceLayer;
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("speed",Mathf.Abs(horizontal));
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        if(onBounce())
        {
            Jump();
        }
        if(!IsGrounded())  {anim.SetBool("jumping",true);}
        if(IsGrounded()) {anim.SetBool("jumping",false);anim.SetBool("parrying",false);}
        

        Flip();
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
    }
    void OnTriggerStay2D(Collider2D parryObject)
    {
        if(Input.GetKeyDown(parry))
            {
                    rb.velocity= new Vector2(rb.velocity.x,parryForce);
                    Destroy(parryObject);
                    anim.SetBool("parrying",true);
                    Debug.Log("he");
            }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    bool onBounce()
    {
        return Physics2D.OverlapCircle(groundCheck.position,0.2f, bounceLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}