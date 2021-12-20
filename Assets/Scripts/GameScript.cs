using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject Player;
    public Text scoreText;
    public GameOver gameOver;
    public Text maxScoreText;
    Rigidbody2D player_rb;
    private int nbjump = 0;
    private int nbMaxJump = 2;
    private int score;
    private int maxScore;


    void Awake()
    {
        Time.timeScale = 0;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        player_rb.mass = 0.6f;
        player_rb.gravityScale = 1.4f;
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
        }

        if(Input.GetKeyDown(KeyCode.Space) && nbjump < nbMaxJump)
        {
            float jumpVelocity = 13.5f;
            player_rb.velocity = Vector2.up * jumpVelocity;
            nbjump++;
        }

        if(score > maxScore)
        {
            maxScore = score;
        }

        maxScoreText.text = (maxScore.ToString());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform"){
            nbjump = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BorderMax")
        {
            //Debug.Log("Joueur mort");
            Destroy(Player.gameObject);
            gameOver.GameOverPop();

        }

        else if(collision.tag == "Coin")
        {
            //Debug.Log("Point sup detecté");
            Destroy(collision.gameObject);
            score += 100;
            scoreText.text = (score.ToString());
        }

    }

}
