using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle2Collision : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Obstacle1Collision();
        }
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 10);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 30);
        //collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
}
