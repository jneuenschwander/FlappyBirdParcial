using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private float scrollVelocity = -2.5f;
    [SerializeField] private TextMeshProUGUI _uiText;
    private bool gameOver=false;
    private int score;
    public float ScrollVelocity
    {
        get => scrollVelocity;
        set => scrollVelocity = value;
    }

    

    public bool GameOver
    {
        get => gameOver;
        set => gameOver = value;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        
        
        if (GameController.instance == null)
        {
            GameController.instance = this;
        }else if (GameController.instance != this)
        {
            Destroy(gameObject);
            Debug.LogWarning("GameController a sido instanciado por segunda vez, evento ilegal.");
        }
        
    }

    public void BirdScored()
    {
        if(gameOver) return;
        score++;
        _uiText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void BirdDie()
    {
       gameOverText.SetActive(enabled);
       gameOver = true;
    }

    private void OnDestroy()
    {
        if (GameController.instance == this)
        {
            GameController.instance = null;
        }
    }
}
