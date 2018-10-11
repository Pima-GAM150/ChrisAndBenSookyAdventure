using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

    public Transform Player;
    public BoxCollider2D Mycollidor;
    public Rigidbody2D RigidBodyChar;
    public float speed;
    public float jumpPower = 1f;
    public Animator animator;
    private Vector2 direction;
    private Vector3 offset;
   // private ray GroundIsHere;
    
    private CollisionDetectionMode2D TheGround;
    int contacts = 0;
    


    private float buttonX;
    private bool buttonY;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("lastLevel", SceneManager.GetActiveScene().buildIndex);

        direction = new Vector2(0f, 1f);
        direction = direction.normalized;
        TheGround = CollisionDetectionMode2D.Continuous;
        offset = new Vector3(0f,.5f,0f);

        
    }

    // Update is called once per frame
    void Update()
    {

       
    	//GroundIsHere = new Ray(this.transform.position, vector3.down);
    	RaycastHit2D hit = Physics2D.Raycast(Player.position- offset, Vector2.down);

    //	if( hit.distance < .1f) {
   // 		contacts = 1;
  //  	}
   // 	else{
   // 		contacts = 0;
   // 	}

    	Debug.DrawRay(Player.position - offset, Vector2.down);
    	if (hit.collider != null)
            {
            	if (hit.distance < .05f){
                Debug.Log(hit.collider.name);
             
                contacts = 1;
            }
        }
                else{
                	contacts = 0;
                }
            


        buttonX = Input.GetAxis("Horizontal");
        buttonY = Input.GetButtonDown("Jump");
        
        if (buttonY){
            if (Input.GetButtonDown("Jump"))
            {
                if (contacts > 0) Jump();
               contacts = 0;
            }
        }
        
        
        animator.SetFloat("Hmove", buttonX);

        if (buttonX < 0f)
        {
            Player.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (buttonX > 0f)
        {
            Player.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    void FixedUpdate()
    {
        //Controllers constant speed with velocity
        RigidBodyChar.velocity = new Vector3(buttonX * speed, RigidBodyChar.velocity.y, 0f);
    }
    void Jump()
    {
        RigidBodyChar.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

   // void OnCollisionEnter2D(Collision2D col)
   // {
    //    if (col.gameObject.tag == "Floor")
     //   {
            
     //       contacts = 1;
     //   }
    //    else
    //    {
            
   //     }
  //  }
  //  void OnCollisionExit2D(Collision2D col)
  //  {
   //     if (col.gameObject.tag == "Floor")
    //    {
         //   contacts = 0;
    //    }
  //  }

}
