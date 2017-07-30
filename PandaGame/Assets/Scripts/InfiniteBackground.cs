using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour {

    //floats
    public float distancebetween;
    private float backgroundWidth;
    private float[] backgroundWidths;



    //int
    private int backgroundSelector;

    //References
    public GameObject theBackground;
    public Transform generationPoint;
    public ObjectPooler [] theObjectPools;
    // public GameObject[] theBackgrounds;

    /* to generate random distances btw*/
    // public float distanceBetweenMin;
    //  public float distanceBetweenMax;
   private Vector2 center;

    private void Start()
    {
        //backgroundWidth = theBackground.GetComponent<BoxCollider2D>().size.x;
        backgroundWidths = new float[theObjectPools.Length];
        for (int i = 0; i < theObjectPools.Length; ++i) {

            backgroundWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        center = theObjectPools[0].pooledObject.GetComponent<BoxCollider2D>().offset;
        transform.position = new Vector3(center.x, transform.position.y, transform.position.z);

    }


    private void Update()
    {
        

        if (transform.position.x < generationPoint.position.x)
        {


            //distancebetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
          

            backgroundSelector = Random.Range(0, theObjectPools.Length);

////////////--------------PRINTS--------------------------------------
          /*  Debug.Log("ANTES transform.position x " + transform.position.x);
            Debug.Log("Center " + center);
            Debug.Log("Width/2    " + backgroundWidths[backgroundSelector] / 2);*/



            transform.position = new Vector3(transform.position.x + (backgroundWidths[backgroundSelector]/2) + distancebetween, transform.position.y, transform.position.z);

            //Debug.Log("DESP transform.position" + transform.position.x);

            // Instantiate(/*theBackground*/ theBackgrounds[backgroundSelector], transform.position, transform.rotation);

            GameObject newBackGround= theObjectPools[backgroundSelector].GetPooledObject();

            newBackGround.transform.position = transform.position;
            newBackGround.transform.rotation = transform.rotation;
            newBackGround.SetActive(true);

            transform.position = new Vector3(transform.position.x + (backgroundWidths[backgroundSelector] / 2) , transform.position.y, transform.position.z);

        }


    }
}
