using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBags : MonoBehaviour {

    // public int scoreToGive;
    // private ScoreManager theScoreManager;
    private Player player;
    private BagsWalk bag;

    //references
  

    void Start () {
        // theScoreManager = FindObjectOfType<ScoreManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        bag= gameObject.GetComponentInParent<BagsWalk>();
    }


    void Update () {
      

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //theScoreManager.AddScore(scoreToGive);
            //Make object dissappear
            bag.Disappear();
            player.PlusLife(1);


        }
    }
}
