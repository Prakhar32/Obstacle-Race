using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {
    private bool PlayerFinish;
    private bool BotFinish;
    public GameObject Manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
            Manager.GetComponent<GameManager>().Win();
        else if (collision.gameObject.tag == "Bot")
            Manager.GetComponent<GameManager>().Lose();
        //GetComponent<Collider>().enabled = false;    
    }
}
