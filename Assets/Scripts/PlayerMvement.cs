using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvement : MonoBehaviour
{
	
	public float speed=5.0f;
	public float maxX = 8.5f;
	
	float movementHorizontal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
		
		if( (movementHorizontal> 0.0 && transform.position.x < maxX) || (movementHorizontal<0.0 && transform.position.x > -maxX) )
		{
			transform.position += Vector3.right*movementHorizontal*speed*Time.deltaTime;
		}
    }
}
