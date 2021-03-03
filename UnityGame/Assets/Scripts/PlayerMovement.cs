using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    float horizontalMove = 0f;
    public float runspeed = 40f;
    bool jump = false;
    bool crouch = false;
    public Sprite newSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transformSprite();

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void transformSprite()
    {
        if (this.gameObject.transform.position.y < -2.9)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
    }
}
