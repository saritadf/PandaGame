using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagsWalk : MonoBehaviour {
    private Rigidbody2D rb2d;
    public float bagSpeed;
    

    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb2d.AddForce(Vector2.right * bagSpeed);
    }
    public void Disappear() {
        gameObject.SetActive(false);
    }
}
