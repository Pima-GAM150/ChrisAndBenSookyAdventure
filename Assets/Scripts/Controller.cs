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
    private int AirJumps;

    private CollisionDetectionMode2D TheGround;
    bool Grounded = false;

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

    // Cast a ray down. If ray its hit distance is less than .05 it will allow jumping. els eit will not. 
    {
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
        // variables for movement and animation
        buttonX = Input.GetAxis("Horizontal");
        buttonY = Input.GetButtonDown("Jump");

        //press button down to jump. if no contacts then no jump
        if (buttonY) {
            if (Grounded || AirJumps < UpgradeManager.singleton.MaxNumberOfAirJumps)
            {
                    Jump();
                    Grounded = false;
            }
        }
        
        //animator for character
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
        //speed of the character
    {
        RigidBodyChar.velocity = new Vector3(buttonX * speed, RigidBodyChar.velocity.y, 0f);
    }
    void Jump()
        //jump of the character
    {
        RigidBodyChar.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        if( Grounded == false ) AirJumps++;

        Grounded = false;
    }

}
