using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPoints : MonoBehaviour {

    public int coinValue;
    
    private ScoreManager theScoreManager;
    private Player player;

	
	void Start () {
        theScoreManager = FindObjectOfType<ScoreManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
	
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Panda") {
            theScoreManager.coinWasPicked = true;
            //thescoremanager.cs function add score adds the value to the score
            theScoreManager.AddCoins(coinValue);
            //the coin dissappears
            gameObject.SetActive(false);
            player.PandaGoldFlash();

        }


    }
}
