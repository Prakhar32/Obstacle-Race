using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUMovement : MonoBehaviour {
    public float maxHorizontalVelocity;
    public float maxVerticalVeclocity;
    private Rigidbody2D rigidbody2D;
    public GameObject groundCheck;
    public LayerMask gr;
    public GameObject eyes;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(maxHorizontalVelocity, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if(Physics2D.Linecast(transform.position, eyes.transform.position + Vector3.right, 9))
        {
            if (Physics2D.Linecast(transform.position, groundCheck.transform.position, gr))
            {
                rigidbody2D.AddForce(Vector2.up * Random.Range(270, 290));Debug.Log("Jump");
            }
            rigidbody2D.velocity = new Vector2(Random.Range(maxHorizontalVelocity * 0.7f, maxHorizontalVelocity * 0.8f), rigidbody2D.velocity.y);
        }

        if (rigidbody2D.velocity.y > maxVerticalVeclocity)
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, maxVerticalVeclocity);

        if (rigidbody2D.velocity.x < maxHorizontalVelocity * 0.5f)
            rigidbody2D.velocity = new Vector2(0.5f * maxHorizontalVelocity, rigidbody2D.velocity.y);
	}
}
