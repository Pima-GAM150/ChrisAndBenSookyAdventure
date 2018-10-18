using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

    public Transform Player;
    public BoxCollider2D Mycollidor;
    public Rigidbody2D RigidBodyChar;
    public Animator animator;
    private Vector3 offset;
    private int AirJumps;
    private float PushForce = 2;
    private Vector2 localToWorldRight;
    public float PlayerHealth;
    
   //	private CollisionDetectionMode2D TheGround;
    private bool Grounded = false;
    private float buttonX;
    private bool buttonY;
   	private bool buttonZ;
    // Use this for initialization
    void Start()
    {   
     //	TheGround = CollisionDetectionMode2D.Continuous;
        offset = new Vector3(0f,.5f,0f); 
        PlayerHealth = UpgradeManager.singleton.MaxPlayerHealth;
    }
    // Update is called once per frame
    void Update(){
    	// variables for movement and animation
        buttonX = Input.GetAxis("Horizontal");
        buttonY = Input.GetButtonDown("Jump");
       	buttonZ = Input.GetButtonDown("Fire1");
       	localToWorldRight = (Vector2)transform.right;


       	//Button press to attack, calls a function
   	if(buttonZ){
   		Attack();
   	}
   	else {
   		animator.SetBool("Hitting", false);
   	}

    // Cast a ray down. If ray its hit distance is less than .05 it will allow jumping. els eit will not.   
        RaycastHit2D hit = Physics2D.Raycast(Player.position - offset, Vector2.down);
        if (hit.collider != null)
        {
            if (hit.distance < .05f) {
                Grounded = true;
                AirJumps = 0;
            }
        }
        else {
            Grounded = false;
        }
       
        //press button down to jump. if no contacts then no jump
        if (buttonY){
            if (Grounded || AirJumps < UpgradeManager.singleton.MaxNumberOfAirJumps){
                    Jump();
                    Grounded = false;
            }
        }

        //animator for character
        animator.SetFloat("Hmove", buttonX);

        if (buttonX < 0f){
            Player.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (buttonX > 0f){
            Player.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    void FixedUpdate()
        {
		//speed of the character
        RigidBodyChar.velocity = new Vector3(buttonX * UpgradeManager.singleton.speed, RigidBodyChar.velocity.y, 0f);
    }

    void Jump()
        //jump of the character
    {
        RigidBodyChar.AddForce(Vector2.up * UpgradeManager.singleton.jumpPower, ForceMode2D.Impulse);
        if( Grounded == false ) AirJumps++;
        Grounded = false;
    }
    
    void Attack(){
    	animator.SetBool("Hitting", true);
    	RaycastHit2D Smash = Physics2D.Raycast(Player.position, localToWorldRight);
    	if (Smash.collider != null)
        {
            if (Smash.distance < .7f) {
                // check if there is a script of type "Enemy" (or a type that inherits from Enemy) on the same game object as this collider
            	Enemy enemy = Smash.collider.GetComponent<Enemy>();

            	if( enemy ) { // if there is a script of type "Enemy" (and this includes anything that inherits from Enemy like BadGhost)
            		enemy.TakeDamage();
            		// (requires that the Enemy type has a method called TakeDamage that takes a float and that you have one to feed it)

            		enemy.body.AddForce(localToWorldRight * PushForce, ForceMode2D.Impulse );
            		// (requires that the Enemy type has a public Rigidbody2D called 'body' and that you've calculated a direction to push it in and an amount of force to push it by)
            	}
            }
        }
    }
    void OnCollisionEnter2D(Collision2D Touch)
    {
        if (Touch.gameObject.tag == "Enemy")
        {
            
            PlayerHealth--;
        }
        else
        {
            
        }
    }
}