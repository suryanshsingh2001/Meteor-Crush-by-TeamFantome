using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int hits = 1;
    [SerializeField] int score = 10;
    [SerializeField] ParticleSystem hitEffect;


    private int currentHits;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;



    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();  
    }


    private void Start()
    {
        hitEffect = FindObjectOfType<ParticleSystem>();
        currentHits = hits; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            currentHits--;
            PlayHitEffect();
            audioPlayer.PlayDamageClip();
            

            if(currentHits == 0)
            {
                Destroy(gameObject);
                PlayHitEffect();
                audioPlayer.PlayDamageClip();

            }

            //TODO: Add score in scoreKeeper
            scoreKeeper.AddScore(score);
        }
    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);

        }
    }
}
