using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // The movement speed of the player
    private Vector2 fingerDown; // The starting position of the swipe
    private Vector2 fingerUp; // The ending position of the swipe

    private void Update()
    {
        // Check for user input
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            fingerDown = Input.GetTouch(0).position;
            fingerUp = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            fingerUp = Input.GetTouch(0).position;
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        // Calculate swipe distance and direction
        float deltaX = fingerUp.x - fingerDown.x;

        // Move player left or right based on swipe direction
        if (deltaX > 0)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else if (deltaX < 0)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}
