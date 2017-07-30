using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//66cm ancho del closets
public class Player : MonoBehaviour
{
    //Stats
    public int curtHealth;
    public int maxHealth;

    //Floats
    public float speed;
    public float jumpPower ;
    public float maxSpeed;
  
    //Booleans
    public bool grounded;
   
    public bool doubleJump;
    public bool running;
    public bool canDoubleJump;
    public bool air = false;
    private bool itDied;

    //References
    private Animation animatio;
    private Animator anim;
    private Rigidbody2D rb2d;
    private CopsWalk copsWalk;
    public LayerMask whatIsGround;

    public float jumpTime;
    private float jumpTimeCounter;
   
    private Collider2D myCollider;

    private void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        animatio = gameObject.GetComponent<Animation>();
        curtHealth = maxHealth=6;
        copsWalk = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CopsWalk>();
        myCollider = GetComponent<Collider2D>();
        jumpTimeCounter = jumpTime;
        itDied = false;
    }

    private void FixedUpdate()
    {



    }
    private void Update()
    {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);
       
        copsWalk.SetDestination(transform.position, 1.5f);


        //Print
        // Debug.Log("Update", gameObject);


        //Debug.Log("velocity" + rb2d.velocity.x);

       


        //left click
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            //if (Input.GetButtonDown("Jump"))

            air = true;


            if (grounded)
            {

                rb2d.velocity = new Vector2(0, jumpPower);
                canDoubleJump = true;
               
                }
            else
            {
                if (canDoubleJump)
                {
                    gameObject.GetComponent<Animation>().Play("Panda_DoubleJump");

                    canDoubleJump = false;
                    //resets y velocity to 0 so it jumps normally even if its falling down too fast ( velocity would be negative) or the other way arround
                    rb2d.velocity = new Vector2(rb2d.velocity.x / 6, jumpPower / 1.5f);
                    //you can divided by 1.75 so the second jump is not that powerful
                    // rb2d.AddForce(Vector2.up * jumpPower / 0.89f);

                }
            }
        }
       
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            air = false;
        

        //-------------if you hold a jump for some time-----------------
        //if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        //{
        //    if (jumpTimeCounter > 0)
        //    {
        //        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
        //        jumpTimeCounter -= Time.deltaTime;
        //    }
        //}
        //if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        //{
        //    jumpTimeCounter = 0;
        //}

        //if (grounded)
        //{
        //    jumpTimeCounter = jumpTime;
        //}
       //------------------------------------end HolD JUMP----------

            ////Para que salte infinito
            //if (Input.GetMouseButtonDown(0))
            //{
            //    rb2d.AddForce(Vector2.up * jumpPower);

            //}

         
       
        //Asigna valor a parametro de ANIMACIÓN
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", rb2d.velocity.x);

        if (rb2d.velocity.x <= 3.2f)
            anim.SetBool("Running", false);
        else
            anim.SetBool("Running", true);

        if (curtHealth > maxHealth)
        {
            curtHealth = maxHealth;
        }

        if (itDied)
        {

            Die();
        }


    }

    public void Die()
    {
      
        //restart scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }
    public void Damage(int dmg)
    {

        if ((curtHealth - dmg) < 0)
        {
            curtHealth = 0;
            itDied = true;
        }
        else
            curtHealth -= dmg;

        if (curtHealth <= 2)
        {
            animatio.PlayQueued("Panda_RedFlash", QueueMode.PlayNow);
            //animatio.PlayQueued("Panda_White", QueueMode.CompleteOthers);

        }
    }

    public void PlusLife(int life)
    {
        if ((curtHealth + life) >= maxHealth)
            curtHealth = maxHealth;
        else
            curtHealth += life;

        animatio.PlayQueued("Panda_GreenFlash", QueueMode.PlayNow);
        animatio.PlayQueued("Panda_White", QueueMode.CompleteOthers);
       /* gameObject.GetComponent<Animation>().Play("Panda_GreenFlash");*/
       

    }

    public void PandaGoldFlash()
    {

        animatio.PlayQueued("Panda_GoldFlash", QueueMode.PlayNow);
        animatio.PlayQueued("Panda_White", QueueMode.CompleteOthers);

    }

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        float timer = 0;
        Debug.Log("knock 2");
        while (knockDur > timer)
        {
            Debug.Log("knock 3");
            timer += Time.deltaTime;
            //go the opositive direction, go to the air (y axis), keep z the same
            rb2d.AddForce(new Vector3((knockbackDir.x + 1) * -100, (knockbackDir.y + 1)  * knockbackPwr, transform.position.z));

        }
        yield return 0;
    }

}
