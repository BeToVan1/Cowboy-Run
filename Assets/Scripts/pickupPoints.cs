using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPoints : MonoBehaviour
{
    public int scoreToGive;
    private AudioSource coinSound;

    private ScoreManager theScoreManager;
    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        coinSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player_0")
        {
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
            if(coinSound.isPlaying)
            {
                coinSound.Stop();
                coinSound.Play();
            }
            else
                coinSound.Play();
        }
    }
}
