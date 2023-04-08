using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeExit : MonoBehaviour
{
    [SerializeField] int dodgeScore = 5; 
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            scoreKeeper.AddScore(dodgeScore);
        }
    }
}
