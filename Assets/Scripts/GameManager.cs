using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerMovement Player;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public PauseMenu thePauseMenu;
    public DeathMenu theDeathScreen;

    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = Player.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            thePauseMenu.PauseGame();
            paused = true;
            Debug.Log("paised");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            thePauseMenu.ResumeGame();
            paused = false;
        }
    }

    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        Player.gameObject.SetActive(false);

        theDeathScreen.gameObject.SetActive(true);
        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        Player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        Player.gameObject.SetActive(true);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }

    /*public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;
        Player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for(int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        Player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        Player.gameObject.SetActive(true);
        theScoreManager.scoreCount = 0;
        theScoreManager.scoreIncreasing = true;
    }*/
}
