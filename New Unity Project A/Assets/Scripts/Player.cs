using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private float jumpForce;

	private Rigidbody2D rb;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool isGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	public void FixedUpdate()
	{
		isGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	
	}



	void Update()
	{

		if (Input.GetKey(KeyCode.RightArrow))
			rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

		if (Input.GetKey(KeyCode.LeftArrow))
			rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);

		if (Input.GetKeyDown(KeyCode.Space) && isGround)
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
	}
}
