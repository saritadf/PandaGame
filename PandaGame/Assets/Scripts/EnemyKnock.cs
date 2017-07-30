using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnock : MonoBehaviour {

    private Player player;
    private CopsWalk copswalk;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        copswalk = GameObject.FindGameObjectWithTag("Enemy").GetComponent<CopsWalk>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //if something with the tag player colides with the sprite
      
        if (col.CompareTag("Player"))
        {
            //Debug.Log("TOUCHED the panda");
            player.Die();   
           // player.Damage(1);
           
           copswalk.running = false;      
            //  StartCoroutine(player.Knockback(0.02f, 350, player.transform.position));
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("knock out");
       copswalk.running = true;
    }
}
