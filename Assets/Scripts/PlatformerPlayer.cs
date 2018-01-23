using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour {
    public float maxSpeed = 10f;
    bool facinRight = true;
    Rigidbody2D myRigidBody;

    Animator anim;
    
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        myRigidBody.velocity = new Vector2(move*maxSpeed, myRigidBody.velocity.y);
       
        
    }
    void flip()
    {
        facinRight = !facinRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    // Update is called once per frame
}
