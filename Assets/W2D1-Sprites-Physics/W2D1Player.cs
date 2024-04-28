using UnityEngine;

namespace W2D1.SpritesPhysics
{
	public class W2D1Player : MonoBehaviour
	{
		public float Speed = 10f;
		public float JumpSpeed = 6f;
		public float GroundDistance = 0.1f;

		Rigidbody rb;
		Animator animator;


		// Start is called before the first frame update
		void Start()
		{
			// Get the Rigidbody once at the beginning, "rb" is now a shortcut to reference it
			rb = GetComponent<Rigidbody>();
			animator = GetComponent<Animator>();
		}

		// Update is called once per frame
		void Update()
		{
			CheckAndApplyWalking();
			CheckAndApplyIsGrounded();
			CheckAndApplyJumping();
			AlignSprite();
			AnimateWalkSpeed();
		}

		void CheckAndApplyWalking()
		{
			// Get the current velocity
			var velocity = rb.velocity;

			// Add any horizontal movement (arrows on the keyboard or joystick on a game controller)
			var xDelta = Input.GetAxis("Horizontal");
			velocity.x = xDelta * Speed;

			// Apply velocity changes
			rb.velocity = velocity;
		}

		void CheckAndApplyIsGrounded()
		{
			var collider = GetComponent<Collider>();
			var halfHeight = collider.bounds.size.y / 2f;
			var feetPos = transform.position;
			feetPos.y -= halfHeight;
			feetPos.y -= GroundDistance;
			var groundCheckSphereRadius = 0.001f;
			var isGrounded = Physics.CheckSphere(feetPos, groundCheckSphereRadius);

			animator.SetBool("IsGrounded", isGrounded);
		}

		void CheckAndApplyJumping()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				var isGrounded = animator.GetBool("IsGrounded");

				if (isGrounded)
				{
					// Start the Jump animation, as before
					animator.SetTrigger("Jump");

					// Add the Jump force
					var velocity = rb.velocity;
					velocity.y = JumpSpeed;
					rb.velocity = velocity;
				}
			}
		}

		void AlignSprite()
		{
			var velocity = rb.velocity;

			// Make the player face the direction they're moving in
			if (velocity.x != 0f)
			{
				var xSign = Mathf.Sign(velocity.x);
				var scale = transform.localScale;
				scale.x = xSign;
				transform.localScale = scale;
			}
		}

		void AnimateWalkSpeed()
		{
			var velocity = rb.velocity;

			var walkSpeed = Mathf.Abs(velocity.x);
			animator.SetFloat("WalkSpeed", walkSpeed);
		}
	}
}
