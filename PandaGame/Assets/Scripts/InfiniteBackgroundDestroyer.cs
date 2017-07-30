using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackgroundDestroyer : MonoBehaviour {

    public GameObject backgroundDestructionPoint;

	void Start () {
        backgroundDestructionPoint = GameObject.Find("InfiniteBackgroundDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x < backgroundDestructionPoint.transform.position.x)
        {
            Debug.Log("inactive background");

            //  Destroy(gameObject);
            gameObject.SetActive(false);
        }
		
	}
}
