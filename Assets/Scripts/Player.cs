using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;


    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    

    [SerializeField] Button button;
    Shooter shooter;


    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    void Awake()
    {
       shooter = GetComponent<Shooter>();
       button = FindObjectOfType<Button>();
        
    }
    void Start()
    {
        InitBounds();

    }

    void Update()
    {
        Move();
        

    }
    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

        transform.position = newPos;

    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();

    }


    //void OnFire(InputValue value)
    //{
        
    //   if (shooter != null)
    //    {   
    //        Debug.Log("Firing");
    //        shooter.isFiring = value.isPressed;
    //    }

    //}

   public void StartFiring()
    {
        if (shooter != null)
        {
            Debug.Log("Firing");
            shooter.isFiring = true;
        }

    }
    public void StopFiring()
    {
        if (shooter != null)
        {
            Debug.Log("Firing");
            shooter.isFiring = false;
        }
    }

}
