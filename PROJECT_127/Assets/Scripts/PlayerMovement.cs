using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Player;
    public IQTimer iqTimerScript;
    public LevelEnd levelEndScript;

    //AUDIO

    public AudioSource audio_salto;
   

    //ANIMACIÓN

    public Animator animator;
    public bool death;
    public float contador_muerte;

    // VELOCIDAD
    public float speed = 8f;
    public float speedSprint = 20f;
    public bool _sprint;

    // RIGIDBODY
    public Rigidbody2D rb;
    // BOXCOLLIDER
    public BoxCollider2D bc;

    public SpriteRenderer sr;

    //FLIP SPRITE
    public bool facingRight;

    //TP
    public bool canTP;
    public bool TPed;
    public float dashValue = 500;


    //DOBLE SALTO
    public bool jumped;
    public bool canJump;
    public bool doubleJumped;

    //SALTO EN LA PARED
    public float wallspeed = 2;
    public float walljump = 8;
    public bool walljumped;
    public bool wallAir;
    public bool wallstucked;
    public bool _walljump;




    // SALTO Y GRAVEDAD
    public float jumpHeight = 2f;
    public float gravity = -7f;
    public float vert;
    public float horizont;
    // GROUNDED¿?
    public bool isGrounded;
    public GameObject groundChecked;
    public LayerMask groundMask;

    // WALL¿?
    public bool wall;
    public LayerMask wallMask;



    //START
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        bc.GetComponent<BoxCollider2D>();
        sr.GetComponent<SpriteRenderer>();
        death = false;

        facingRight = true;

        audio_salto = GetComponent<AudioSource>();



    }

    //UPDATEh
    void Update()
    {
        //MOVIMIENTO

        if (Input.GetKey(KeyCode.LeftShift) && walljumped == false)
        {
            _sprint = true;
        }
        else
        {
            _sprint = false;
        }








        //salto
        if (iqTimerScript.seconds >= 30f && iqTimerScript.gameOver == false)
        {
            Jump();

        }


        //DOBLE SALTO
        if (iqTimerScript.seconds >= 45f && jumped == true && iqTimerScript.gameOver == false)
        {

            DoubleJump();


        }

        if (iqTimerScript.seconds >= 75f && canTP == true && iqTimerScript.gameOver == false)
        {
            Teleport();
        }


        if (walljumped == false && Input.GetButtonDown("Jump"))
        {
            _walljump = true;
        }

        if (wallAir == true)
        {
            _walljump = false;
            walljumped = true;
        }




        //CONDICIÓN WALL¿?


        wall = Physics2D.IsTouchingLayers(bc, wallMask);


        if (wall == true && isGrounded == false)
        {

            wallstucked = true;


        }






        //CONDICIÓN GROUNDED¿?
        isGrounded = Physics2D.IsTouchingLayers(bc, groundMask);


        if (isGrounded == true)
        {
            jumped = false;
            canJump = false;
            doubleJumped = false;
            canTP = true;
            walljumped = false;
            wallAir = false;
            wallstucked = false;
            animator.SetBool("jumped", false);





        }

        if (isGrounded && _sprint == false)
        {
            speed = 8f;
            jumpHeight = 2f;
        }

        if (isGrounded == false && _sprint == false)
        {
            speed = 6f;
            jumpHeight = 2f;


        }


        if(iqTimerScript.gameOver == true && levelEndScript.levelEnd == false)
        {
            
            animator.SetBool("jumped", false);
            animator.SetBool("gameOver", true);
            death = true;
            
           

            if(death == true)
            {

                contador_muerte += Time.deltaTime;
                

                if(contador_muerte >= 1.6f)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
                }
            }
        }








        //Salir del juego

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }



    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");


        Vector2 horiz = Player.transform.right * x * speed * Time.deltaTime;

       
        animator.SetFloat("Speed", Mathf.Abs(x));
        




        if (x > 0.0f && iqTimerScript.gameOver == false && iqTimerScript.seconds >= 15 && wallstucked == false)
        {

            rb.transform.Translate(horiz);


            facingRight = true;



        }

        if (x < 0.0f && iqTimerScript.gameOver == false && iqTimerScript.seconds >= 15 && wallstucked == false)
        {

            rb.transform.Translate(horiz);




            facingRight = false;








        }

        if (iqTimerScript.seconds >= 15f && _sprint && iqTimerScript.gameOver == false)
        {
            Sprint();
        }

        if (facingRight == true)
        {

            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            Player.transform.rotation = Quaternion.Euler(0, 180, 0);

        }

        if (iqTimerScript.seconds >= 60f && isGrounded == false)
        {
            if (facingRight == true && iqTimerScript.gameOver == false)
            {
                WallJumpR();
            }

            if (facingRight == false && iqTimerScript.gameOver == false)
            {
                WallJumpL();
            }


        }



    }



    void Sprint()
    {
        if (_sprint)
        {
            speed = speedSprint;
        }

        if (_sprint && isGrounded == false)
        {
            speed = 8f;
            jumpHeight = 3f;
            animator.SetBool("jumped", true);
        }
    }






    //FUNCIÓN SALTO
    void Jump()
    {


        if (isGrounded == false)
        {
            animator.SetBool("jumped", true);
            jumped = true;

            if (jumped == true && doubleJumped == false)
            {
                canJump = true;
            }

        }

        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {

            audio_salto.Play();
            vert = Mathf.Sqrt(jumpHeight * -2 * gravity);
            rb.velocity = new Vector2(0, vert) * Player.transform.up;

            animator.SetBool("jumped", true);



        }

    }

    //DOBLE SALTO
    void DoubleJump()
    {




        if (Input.GetButtonDown("Jump") && canJump == true && wall == false)
        {

            vert = Mathf.Sqrt(jumpHeight * -2 * gravity);
            rb.velocity = new Vector2(0, vert) * Player.transform.up;
            doubleJumped = true;

            if (jumped == true && doubleJumped == true)
            {

                canJump = false;
            }




        }


    }

    void Teleport()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl) && facingRight == true)
        {
            Vector3 dash = Player.transform.right * dashValue * Time.deltaTime;
            rb.transform.Translate(dash);
            TPed = true;

            if (TPed == true)
            {
                canTP = false;
            }


        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && facingRight == false)
        {
            Vector3 dash = Player.transform.right * -dashValue * Time.deltaTime;
            rb.transform.Translate(dash);


            if (TPed == true)
            {
                canTP = false;
            }
        }
    }

    void WallJumpR()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector2 vectorWJH = wallspeed * x * Player.transform.right;
        Vector2 vectorWJV = walljump * Player.transform.up;


        if (wallAir == true)
        {
            rb.gravityScale = 1;
            

        }





        if (wall == true)
        {
            Player.transform.rotation = Quaternion.Euler(0, 180, 0);
            walljumped = false;
            wallAir = false;
            doubleJumped = false;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            



            if (wallAir == false && x > 0.0f)
            {
                facingRight = true;
                rb.gravityScale = 1;
                
            }





            if (_walljump)
            {


                rb.transform.Translate(0.1f, 0, 0);
                rb.velocity = new Vector2(x * wallspeed, walljump);
                walljumped = true;
                wallAir = true;
                wallstucked = false;














            }











        }

        else
        {
            facingRight = true;
            rb.gravityScale = 1;
            
        }




    }

    void WallJumpL()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector2 vectorWJH = wallspeed * x * Player.transform.right;
        Vector2 vectorWJV = walljump * Player.transform.up;


        if (wallAir == true)
        {
            rb.gravityScale = 1;

        }





        if (wall == true)
        {
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            walljumped = false;
            wallAir = false;
            doubleJumped = false;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;



            if (wallAir == false && x < 0.0f)
            {
                facingRight = false;
                rb.gravityScale = 1;
            }





            if (_walljump)
            {


                rb.transform.Translate(0.1f, 0, 0);
                rb.velocity = new Vector2(x * wallspeed, walljump);
                walljumped = true;
                wallAir = true;
                wallstucked = false;











            }











        }

        else
        {
            facingRight = false;
            rb.gravityScale = 1;
        }




    }




}

