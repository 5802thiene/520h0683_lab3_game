using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gameController;

    public int score;

    // lay class GameController
    void Start()
    {
        GameObject controller = GameObject.FindWithTag("GameController");
        if (controller!=null)
        {
            gameController = controller.GetComponent<GameController>();
        }
        if(gameController==null)
        {
            Debug.Log("Game Controller not found!");
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Boundary")
            return;

        // hieu ung stone boom
        Instantiate(explosion, transform.position, transform.rotation);
        // hieu ung player boom
        if (other.tag=="Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.gameRaDi();
        }
        // neu khong phai -> them diem cho player
        gameController.addScore(score);

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
