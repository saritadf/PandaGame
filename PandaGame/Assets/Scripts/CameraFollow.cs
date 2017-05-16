using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    /*Follow player in X axis*/
    public Player thePlayer;
    private Vector3 lastPlayerPosition;
    public float distanceToMove;
    /*----------*/

    private Vector2 velocity;

    //float
    public float smoothTimeY;
    public float smoothTimeX;

    //references
    public GameObject player;

    //bools
    public bool bounds;
    public bool paused;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    // Use this for initialization
    void Start()
    {
        /*Follow player in X axis*/
        thePlayer = GameObject.FindObjectOfType<Player>();
        /*----------------*/
        paused = false;

        //put a tag in Unity in the inspector to the Game Object Player to access easily
        player = GameObject.FindGameObjectWithTag("Player");
       // distanceToMove = 0.2f;
    }

    /*Follow player in X axis*/
    private void Update()
    {
        if (!paused)
        {
            //distanceToMove = thePlayer.transform.position.x - lastPlayerPosition.x;

            transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
            lastPlayerPosition = thePlayer.transform.position;

        }
    }
    /*-----------------------------*/
   

    /* void FixedUpdate()
     {
         /* Mathf.SmoothDamp:  Changes the value gradually to the desired value
            Mathf.SmoothDamp( CURRENT POSITION /camera,     POSITION TRYING TO REACH /player,    CURRENT VELOCITY,     VELOCITY TRYING TO REACH);*/
    //smoothTime is modified in Unity see in ispector and put a value = 0.05
    /*      float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
          float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);

          //change camera position
          transform.position = new Vector3(posX, posY, transform.position.z);

          //Limit or bound the Camera
          if (bounds)
          {
              //math clamp doesnt let exceed the current position to values not btw min and max 
              //set minCameraPos.Y in unity with the value of the bottom of the camera you want(moving manually the bounding box and seeing what value it sets)
              //maxCameraPos.Y , maxCameraPos.X put big values (like 1000) because you may want to go to the right or left or make stairs and go up
              //and minCameraPos.X put lox value if you may go back in the game (-100)  
              transform.position = new Vector3(
                  Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                  Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                  Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
          }


      }

      public void SetMinCamPosition()
      {
          //sets mincampos to the current position
          minCameraPos = gameObject.transform.position;
      }
      public void SetMaxCamPosition()
      {
          maxCameraPos = gameObject.transform.position;
      }

  */
}
