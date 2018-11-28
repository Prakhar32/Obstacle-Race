using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float duration;
    private bool isKeyDown;
    public float maxVerticalVelocity;
    public float maxHorizontalVelocity;
    public float forceMultiplier;
    private bool Forward;
    private bool Backward;
    public bool canJump;
    public GameObject groundCheck;
    public LayerMask gr;

    // Use this for initialization
    void Start () {
        duration = 0;isKeyDown = false;
	}
	
	// Update is called once per frame
	void Update () { 
        if (isKeyDown)
            duration += Time.deltaTime;

        if (Forward)
            MoveForward();
        if (Backward)
            MoveBackward();
	}

    bool isGrounded()
    {
        return Physics2D.Linecast(transform.position, groundCheck.transform.position, gr); 
    }

    public void HoldStart()
    {
        Debug.Log(isGrounded());
        if (!isGrounded()) return;
        isKeyDown = true;
    }

    public void HoldEnd()
    {
        Debug.Log("End" + duration);
        Jump();
    }

    void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * duration * forceMultiplier);
        if (gameObject.GetComponent<Rigidbody2D>().velocity.y > maxVerticalVelocity)
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, maxVerticalVelocity);
        duration = 0;isKeyDown = false;
    }

    public void MoveForward()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(maxHorizontalVelocity, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        Forward = true;
    }

    public void MoveBackward() {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxHorizontalVelocity, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        Backward = true;
    }
    
    public void Stop()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        Forward = false;Backward = false;
    }
}
