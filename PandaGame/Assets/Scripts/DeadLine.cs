using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour {

    private Player player;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //if something with the tag player colides with the sprite

        if (col.CompareTag("Player"))
        {
            Debug.Log("DEAD");
            player.Die();   
          

         
        }

    }

 
}
