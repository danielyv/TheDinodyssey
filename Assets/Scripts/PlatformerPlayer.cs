using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour {
    public float speed = 10f;
    public static int stars;
    bool facinRight = true;
    Rigidbody2D myRigidBody;

    Animator anim;
    
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        stars = 0;
    }

    private void Update()
    {
        /*
        
        myRigidBody.velocity = new Vector2(move*maxSpeed, myRigidBody.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            Physics.gravity *= -1;
        }*/

        InputMovement();

    }
    void InputMovement()
    {

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetFloat("Speed", 1);

            moveRight(speed);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            anim.SetFloat("Speed", 1);

            moveLeft(speed);

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            flipY();
            anim.SetFloat("Speed", 0);

            myRigidBody.gravityScale *= -1;

        }
        else
        {
            anim.SetFloat("Speed", 0);

        }

    }
        private void moveRight(float speed)
    {
        if (!facinRight)
            flipX();
        transform.localPosition += transform.right * speed * Time.deltaTime;
    }

    private void moveLeft(float speed)
    {
        if (facinRight)
            flipX();
        
        transform.localPosition -= transform.right * speed * Time.deltaTime;
    }
    void flipX()
    {
        facinRight = !facinRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void flipY()
    {
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
    }
    // Update is called once per frame
}
