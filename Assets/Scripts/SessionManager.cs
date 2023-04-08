using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    [Header("Score and Lives")]
    [SerializeField] int playerLives = 3;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;


    [Header("FX")]
    [SerializeField] ParticleSystem hitEffect;

    LevelManager levelManager;
    ScoreKeeper scoreKeeper;

    public bool isVulnerable = true;
   

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        hitEffect = FindObjectOfType<ParticleSystem>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    private void Start()
    {
        livesText.text = "X " + playerLives.ToString();
        scoreText.text = "Score: " + scoreKeeper.GetScore().ToString();

    }

    private void Update()
    {
        scoreText.text = "Score: " + scoreKeeper.GetScore().ToString();
    }

    public void ProcessDeath()
    {
        if(playerLives > 1)
        {
            //take live
            TakeLife();
            PlayHitEffect();
        }
        else
        {
            //Game Over
            scoreKeeper.ResetScore();
            levelManager.LoadMenu();
        }
    }

    //private void ProcessRespawn()
    //{
    //    throw new NotImplementedException();
    //}

    public void TakeLife()
    {
        playerLives--;
        livesText.text = "X " + playerLives.ToString();

        //ProcessRespawn();

        //scenepersists

    }

    private void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);

        }
    }
}
