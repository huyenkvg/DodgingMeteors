using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
    public float speedMove;
    private GameObject player;
    private float disY;

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
        if(GameManager.Instance.mGameState == GameState.Playing)
        { 
        disY = transform.position.y;

        if(disY > player.transform.position.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedMove);
        }
        else
        {
            Vector3 direction =  Vector3.down;
            transform.Translate(direction * speedMove *100* Time.deltaTime);
        }
	}
        
    }

}
