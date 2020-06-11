using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    Rigidbody2D rb;
	
	public float fallSpeed=2.5f;
	public float lowJumpSpeed=-2f;
	public float moveSpeed=0.6f;
	public float moveIf=0.5f;
	bool isJumpReleased;
	bool jumpPress;
	public Transform GroundCheck;
	public float GroundedRadius = 0.2f;
	public float jumpTime = 2;
	float jumpTimeCounter;

	public Animator anim;
	public SpriteRenderer sprite;
	public float walkingTreshold = 0.04f;


	void Start()
    {
        rb    =GetComponent<Rigidbody2D>();

	}

    // Update is called once per frame
    void Update()
    {
		var		 m_Grounded = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject){
                    m_Grounded = true;
                    jumpTimeCounter=jumpTime;
					break;
				}
			}

		var hor=Input.GetAxis("Horizontal");
        Debug.Log("hor"+hor+", m_Grounded"+m_Grounded+"col"+colliders.Length+" jump t "+jumpTimeCounter);


		if(rb.velocity.y<0){
        rb.velocity+=Vector2.up*Physics.gravity.y*(fallSpeed-1)*Time.deltaTime;
		}

		bool jumpThisFramePressed=Input.GetButton("Jump");
		isJumpReleased = jumpPress &&!jumpThisFramePressed;
		 jumpPress=jumpThisFramePressed;

//if(isJumpReleased){
//Debug.Log("Jump rel");
//}



if(isJumpReleased){
jumpTimeCounter=0;
}
		if((rb.velocity.y>=0 && jumpThisFramePressed && jumpTimeCounter>0) || (jumpPress && m_Grounded)){
		jumpTimeCounter -= Time.deltaTime;
		//Debug.Log("jump");
        rb.velocity+=Vector2.up*Physics.gravity.y*(lowJumpSpeed-1)*Time.deltaTime;
		}
		
		
		
		var curMove=Mathf.Abs(rb.velocity.x);
		//if(<moveIf){
		
		rb.velocity += Vector2.right*(moveSpeed-curMove)*hor;
		//}
		sprite.flipX = hor<0;
		anim.SetBool("walking", Math.Abs(rb.velocity.x) > walkingTreshold);
		sprite.flipX = hor>0; // transform.localScale = Vector3.forward * 
		//sprite.transform.localScale = new Vector3(hor<0?-1:1, 0, 0);
		
		

	}
}
