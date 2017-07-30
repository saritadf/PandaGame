using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*-----------------------------------------THIS CODE iS NOT BEING USED-----------------------------------------------------------*/
public class GroundCheck : MonoBehaviour
{

    private Player player;
 

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();

    }

  

    void OnTriggerEnter2D(Collider2D col)
    {
       // Debug.Log("Enter");
       // player.grounded =true;
     
    }

    //la función se llama cuando el trigger se mantiene en algo
    void OnTriggerStayD(Collider2D col)
    {
       // Debug.Log("Stays Colliding");
      //  player.grounded = true;

    }

    void OnTriggerExit2D(Collider2D col)
    {//
       // Debug.Log("exits");
      //  player.grounded = false;
    }


}
