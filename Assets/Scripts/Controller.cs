using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

    public Transform transformToFlip;
    public BoxCollider2D Mycollidor;
    public Rigidbody2D Ball;
    public float speed;
    public float jumpPower = 1f;
    public Animator animator;
    public Vector2 scale;
    public Vector2 originscale;
    public Vector2 direction;
    public Vector2 newoffset;
    public Vector2 oldoffset;
    public CollisionDetectionMode2D TheGround;
    int contacts = 0;
    public AudioSource Beat;


    private float buttonX;
    private bool buttonY;
    private bool buttonE;
    private bool buttonR;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.SetInt("lastLevel", SceneManager.GetActiveScene().buildIndex);

        scale = new Vector2(.5f, .5f);
        originscale = new Vector2(.6f, 1.3f);
        direction = new Vector2(0f, 1f);
        direction = direction.normalized;
        newoffset = new Vector2(-.03f, -.7f);
        oldoffset = new Vector2(-.03f, -.3f);
        TheGround = CollisionDetectionMode2D.Continuous;
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, direction);
        
        buttonX = Input.GetAxis("Horizontal");
        buttonY = Input.GetButtonDown("Jump");
        buttonE = Input.GetButtonDown("Fire1");
        buttonR = Input.GetButtonDown("Fire2");
        if (buttonY){
            if (Input.GetButtonDown("Jump"))
            {
                if (contacts > 0) Jump();
            }
        }
        if (buttonE)
        {           
            Mycollidor.size = scale;
            animator.SetBool("Crouch", true);
            Mycollidor.offset = newoffset;
            speed = 5f;
            Beat.Play();
        }
        if (buttonR)
        {
            if (hit.distance <= .5)
            {

            }
            else
            {
                Mycollidor.size = originscale;
                animator.SetBool("Crouch", false);
                Mycollidor.offset = oldoffset;
                speed = 10f;
                Beat.Stop();
            }
        }
        animator.SetFloat("Hmove", buttonX);

        if (buttonX < 0f)
        {
            transformToFlip.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        if (buttonX > 0f)
        {
            transformToFlip.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    void FixedUpdate()
    {
        //Controllers constant speed with velocity
        Ball.velocity = new Vector3(buttonX * speed, Ball.velocity.y, 0f);
    }
    void Jump()
    {
        Ball.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            
            contacts++;
        }
        else
        {
            
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Floor")
        {
            contacts = 0;
        }
    }

}
