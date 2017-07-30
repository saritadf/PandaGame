using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopsWalk : MonoBehaviour
{
    //references 
    private Rigidbody2D rb2d;
    private Animator anim;

    //float
    public float speed;
    public float timeLeft = 50;

    public float t;
    public Vector2 startPosition;
    public Vector2 target;

    /*new*/
    private Transform Target;
    public float rotationSpeed = 3f;
   
    //------

    public float timeToReachTarget;
    public bool running;
    
    
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        startPosition = target = transform.position;

        /*new*/Target = GameObject.FindWithTag("Player").transform;
    }


    void Update()

    {

        anim.SetBool("Running", running);

        /* t += Time.deltaTime / timeToReachTarget;
         transform.position = Vector2.Lerp(startPosition, target,t);*/
       /* transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Target.position - transform.position), rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * speed * Time.deltaTime;*/
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Target.position.x, Target.position.y), speed * Time.deltaTime);
    }

    public void SetDestination(Vector2 destination, float time)
    {
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        destination = new Vector2(destination.x - 3, -4.5f);
        target = destination;

    }
}
