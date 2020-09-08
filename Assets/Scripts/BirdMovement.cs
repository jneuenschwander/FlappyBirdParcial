using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///Logica del Movimiento y animaciones 
/// </summary>
public class BirdMovement : MonoBehaviour
{
    private bool isDead = false;
    [SerializeField] private float upForce = 200f;
    [SerializeField] private KeyCode upControl = KeyCode.Space;
    
    private Rigidbody2D rb2d;
    

    private Animator anim;
    // Start is called before the first frame update

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
    
        if (Input.GetKey(upControl))
        {
            rb2d.velocity = Vector2.zero;
            rb2d.AddForce(Vector2.up * upForce);
            anim.SetTrigger("Vuelo");
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isDead = true;
        anim.SetTrigger("Muerto");
        GameController.instance.BirdDie();
        rb2d.velocity = Vector2.zero;
    }
}
