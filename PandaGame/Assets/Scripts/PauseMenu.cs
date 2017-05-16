using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


//Script attatched to Main Camera
public class PauseMenu : MonoBehaviour
{

    //asign panel PauseUI in unity (inspector of main camera - script - PauseUi : Drag the PauseUI object there)
    public GameObject PauseUI;
    public string playGameScene;

    private bool paused = false;
    private CameraFollow cam;

    void Start()
    {
        //to enable or disable the panel: PAUSEUI ( hide or show) in unity you could check the box or uncheck
        PauseUI.SetActive(false);
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }

    //void Update()
    //{

    //    /*click escape to get the pause menu*/
    //    if (Input.GetButtonDown("Pause"))
    //    {
    //        //if (Input.GetButtonDown("PauseButton"))
    //        //    {

    //        paused = !paused;
    //    }

    //    if (paused)
    //    {
    //        PauseUI.SetActive(true);
    //        /*  timeScale == 1.0 //real time
    //            timeScale == 0.5 //2x slower than real time
    //            timeScale == 0 //paused - FixedUpdate functions will not be called
    //            //if you lower Time.timeScale you should low Time.fixesDeltaTime by the same amount
    //         */
    //        Time.timeScale = 0;
    //    }

    //    if (!paused)
    //    {
    //        PauseUI.SetActive(false);
    //        Time.timeScale = 1;
    //    }
    //}


    public void PauseGame() {
        PauseUI.SetActive(true);
        cam.paused = true;
        Time.timeScale = 0;

    }
    public void Resume()
    {
        // paused = false;
        PauseUI.SetActive(false);
        cam.paused = false;
        Time.timeScale = 1;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        cam.paused = false;

        //   Application.LoadLevel(Application.loadedLevel);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        //   Application.LoadLevel(0);
        cam.paused = false;
    }

    public void Quit()
    {
        //It quit the whole app uncomment when you build the game
         Application.Quit();
    }

}
