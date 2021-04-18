using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{

    public float characterSpeed;
    private Rigidbody2D rigidbody2D;
    private Vector3 characterMovement;
    bool characterFacingRight = true;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        
    }


    void Update()
    {
        characterMovement = Vector3.zero;
        characterMovement.x = Input.GetAxisRaw("Horizontal");
        characterMovement.y = Input.GetAxisRaw("Vertical");
    }


    void FixedUpdate()
    {
        if(characterMovement != Vector3.zero)
        {
            Move();
        }
    }


    void Move()
    {

        if (characterMovement.x > 0 && !characterFacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (characterMovement.x < 0 && characterFacingRight)
			{
				// ... flip the player.
				Flip();
			}

        rigidbody2D.MovePosition(transform.position + characterMovement * characterSpeed * Time.deltaTime);
    }


    private void Flip()
	{
		
		characterFacingRight = !characterFacingRight;
        
		Vector3 characterScale = transform.localScale;
		characterScale.x *= -1;
		transform.localScale = characterScale;
	}

}
