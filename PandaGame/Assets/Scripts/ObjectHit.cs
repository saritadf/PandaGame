using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour {

    private Player player;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.running = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.running = true;
    }
}
