using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {
    public GameObject []listObstacle; // object se dc tao ra :>
    private float timeLast; // thoi gian taoj truoc do
    public float timeCreate ;// tg se  taoo.
                                // Use this for initialization
    public int dem = 0, num = 3;

    private float Width;
    private GameObject player;

    // Use this for initialization
    void Start () {
        Vector3 posScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        Width = posScreen.x;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.mGameState == GameState.Playing)
        { 
            if (Time.time - timeLast > timeCreate)
        {

            dem++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(-Width, Width);
            transform.position = temp;

                // tao doi tuong moi;
                //Instantiate(obstacle);
                // cach thu 2
                int index = 1;
                index = Random.Range(1, 5);// 1 2,
                if (index > 2)
                    index = 1;

                timeLast = Time.time;
            if(dem == num )
            {
                GameObject obj = Instantiate(listObstacle[index].gameObject, transform.position, Quaternion.identity);
                dem = 0;
                num += 0;
                obj.GetComponent<IndexObstacle>().mamau = index;
            }
            else
            {
                GameObject obj = Instantiate(listObstacle[0].gameObject, transform.position, Quaternion.identity);
                obj.GetComponent<IndexObstacle>().mamau = 0;
               
            }
        }
          AutoDestroy();
        
    }
    }
    void AutoDestroy()
    {


        // If player is null then we will find player object in screen
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");


        // -2 is distance betweet this object and player, may change it
        if (transform.position.z - player.transform.position.z < -2)
        {
          
            Destroy(gameObject);
        }

    }
}
