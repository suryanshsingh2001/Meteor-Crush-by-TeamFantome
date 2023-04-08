using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollusionHandler : MonoBehaviour
{
    SessionManager sessionManager;

    private void Start()
    {   
        sessionManager = FindObjectOfType<SessionManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") )
        {
            sessionManager.ProcessDeath();
            //TODO: Respawn Logic TakeLives()
        }
        
    }



}
