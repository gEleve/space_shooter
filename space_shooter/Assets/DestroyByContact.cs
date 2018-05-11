using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;

    public int score;
    private GameController gameController;

	// Use this for initialization
	void Start () {
        GameObject gameContrllerObject = GameObject.FindWithTag("GameController");
        if (gameContrllerObject != null) {
            gameController = gameContrllerObject.GetComponent<GameController>();

        }
        if (gameContrllerObject == null) {
            Debug.Log("Cannot find ‘gameController’script");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Boundary") {
            return;
        }
        if (other.tag == "Player") {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.addScore(score);
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);

 
    }
}
