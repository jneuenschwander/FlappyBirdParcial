using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb2d;
    
    
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb2d.velocity = Vector2.right *GameController.instance.ScrollVelocity ;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.GameOver)
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
