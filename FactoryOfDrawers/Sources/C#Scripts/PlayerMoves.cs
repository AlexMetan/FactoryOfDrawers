using UnityEngine;
using UnityEngine.UI;


public class PlayerMoves : MonoBehaviour {
	[Header("Player Settings")]
	
	public float moveSpeed;
	public float jumpHeight;
   
	[Header("Other")]
 
	public boxMoved boxMov;
	public Isgrouded Grounded;
	public Button jumpButton;
	Rigidbody2D rb;
	SpriteRenderer spriteRend;
	Animator _animator;
	bool isGrounded;
    public	bool isMoved;
	bool isBoxMoved;
	bool jumpedH;
	bool jumpButtonClicked;
	bool leftb,rightb,jumpb;
 	bool animatedMove;
	int ismovedBox;
   
    float velx, vely;
	void Start(){
        
        transform.position = new Vector2(Random.Range(-5,6),4);
		rb = GetComponent<Rigidbody2D> ();
		spriteRend = GetComponent<SpriteRenderer> ();
		_animator = gameObject.GetComponent<Animator> ();
	}
	void Update(){

       
        
		isBoxMoved = boxMov.moved;
        isGrounded = Grounded.isGroundedJump;
		AnimPlayer ();
		if (!isGrounded)
			jumpedH = true;
		else
			jumpedH = false;
        
	}

    void FixedUpdate() {
       
        PlayerMovesInput();
    }

	public void PlayerMovesInput ()
	{

        if (leftb || Input.GetKey(KeyCode.A))
        {
            isMoved = true;
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y );
            
            spriteRend.flipX = true;
        }
        else if (rightb || Input.GetKey(KeyCode.D))
        {
            isMoved = true;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y );
            spriteRend.flipX = false;
        }
        else isMoved = false;

        if (((Input.GetKeyDown(KeyCode.F)) || jumpb )&& isGrounded&&(!boxMov.moved||!isMoved))
        {


            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            jumpb = false;
	

		}

        
       
	} 

	public void LeftButton(bool left){leftb = left;}

	public void RightButton (bool right){rightb = right;}

   
	public void Jumpbut(){
        if (isGrounded)
            jumpb = true;
       
	}
	
	void AnimPlayer(){
		
		_animator.SetBool ("movingBox",isBoxMoved );
		_animator.SetBool ("grounded", isGrounded);
		_animator.SetBool ("moving", isMoved);
//		_animator.SetBool("jumps", jumpedH);
	}
}