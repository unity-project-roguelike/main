using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{

    public Camera gameCamera;
    public float characterSpeed;
    public bool characterFacingRight = true;

    private SpriteRenderer sprite;
    private Rigidbody2D rigidbody2D;
    private Vector3 characterMovement;    
    private Vector2 mousePosition;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        characterMovement = Vector3.zero;
        characterMovement.x = Input.GetAxisRaw("Horizontal");
        characterMovement.y = Input.GetAxisRaw("Vertical");

        mousePosition = gameCamera.ScreenToWorldPoint(Input.mousePosition);
    }


    void FixedUpdate()
    {
        Move();
        UpdateDirection();       
    }


    void UpdateDirection()
    {
        Vector2 lookDirection = mousePosition - rigidbody2D.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        
        if((angle < 90 && angle > -90) && !characterFacingRight)
        {
            FlipCharacter();
        }
       else 
       if((angle > 90 || angle < -90) && characterFacingRight)
        {
            FlipCharacter();    
        }
    }


    void Move()
    {
        rigidbody2D.MovePosition(transform.position + characterMovement * characterSpeed * Time.deltaTime);
    }


    private void FlipCharacter()
	{
		characterFacingRight = !characterFacingRight;
        sprite.flipX = !sprite.flipX;
		
	}

}
