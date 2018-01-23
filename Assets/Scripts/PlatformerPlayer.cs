using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour {
    public float maxSpeed = 10f;
    bool facinRight = true;
    Animator anim;
    
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(move));
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (move > 0 && !facinRight)
        {
            flip();
        }
        else if (move < 0 && facinRight)
        {
            flip();
        }
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
