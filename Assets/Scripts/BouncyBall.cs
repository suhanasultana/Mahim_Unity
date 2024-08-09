using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BouncyBall : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxVelocity = 15f;
    Rigidbody2D rb;
    
    public GameObject gOB;
    Rigidbody2D rbPaddle;
    
    int score = 0;
    int lives = 5;
    
    public TextMeshProUGUI scoreTxt;
    public GameObject[] livesImage;
    public GameObject gameOverPanel;
    public GameObject youWinPanel;
    int brickCount=160;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down*5.0f;
        
        //brickCount = FindObjectOfType<LevelGenerator>().transform.childCount;
        
        //Debug.Log("Start Brick count = "+brickCount);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < minY)
        {
			if(lives<=0)
			{
				GameOver();
			}
			else
			{
				 transform.position = Vector3.zero;
				 rb.velocity = Vector2.down*5.0f;//Vector3.zero; 
			 
				 gOB.transform.position =  Vector3.zero;//(0.0f, -4.5f, 1.0f);
				 lives--;
				 livesImage[lives].SetActive(false);
			}
		 
        }
		
        
        if(rb.velocity.magnitude> maxVelocity)
        {
         rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
	//Debug.Log(collision.gameObject.name);
	
	if(collision.gameObject.CompareTag("brick"))
	{
	  Destroy(collision.gameObject);
	  score +=10;
	  scoreTxt.text =  score.ToString("00000");
	  brickCount--;
	  //Debug.Log("breaking Brocks = "+brickCount);
	  if(brickCount<=0)
	  {
	  	//Debug.Log("Display WIn = "+brickCount);
	  	youWinPanel.SetActive(true);
	  	Time.timeScale = 0;
	  }
	}
	
    }	 
    
    void GameOver()
	{
		//Debug.Log("Imside Game Over");
		gameOverPanel.SetActive(true);
		
		Time.timeScale = 0;
		Destroy(gameObject);
		
	}  
}
