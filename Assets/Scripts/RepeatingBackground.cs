using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;

    public float GroundHorizontalLength { get; set; }

    // Start is called before the first frame update
    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        GroundHorizontalLength = groundCollider.size.x;
    }

    private void RepositionBackground()
    {
        transform.Translate(Vector2.right * (2 * GroundHorizontalLength));
    }
    
    
    

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(transform.position.x - (-GroundHorizontalLength)) < 0.1)
        {
            RepositionBackground();
        }
    }
}
