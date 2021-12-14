using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speedMove, radi;
    public bool boom = false;
    public int turn = 1;
    public Sprite died;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.mGameState == GameState.Playing)
            if (Input.GetMouseButton(0))
            {

                Vector3 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                posMouse.z = 0;
                //posMouse.y = -4;

                //    transform.position = vector3.lerp(transform.position, posmouse, speedmove * time.deltatime);


                transform.position = posMouse;
                //Debug.Log(Input.mousePosition);
            }


    }
    private void OnCollisionEnter2D(Collision2D Obj)
    {

        if (Obj.transform.tag == "Obstacle")
        {
            int mamau = Obj.gameObject.GetComponent<IndexObstacle>().mamau;
            Debug.Log(mamau);
            if (mamau == 1)
            {
                //if (turn < 4)
                //    turn++;
                ScoreManager.Instance.AddScore(1);
                Destroy(Obj.gameObject);


            }else
            if (mamau == 0)
            {
                //turn--;
                //if (turn == 0)
                //{
                    GetComponent<SpriteRenderer>().sprite = died;
                    GameManager.Instance.mGameState = GameState.GameOver;
                    UIManager.Instance.ShowGameOver();
                //}
                //else
                    Destroy(Obj.gameObject);
            }else
            if (mamau == 2)
            {
                

                Destroy(Obj.gameObject); Debug.Log(10);

                GameObject []ListObstacle = GameObject.FindGameObjectsWithTag("Obstacle");
                foreach(GameObject x in ListObstacle)
                {

                        float dis = Vector3.Distance(x.transform.position, transform.position);
                        if( dis < radi)
                        {
                            
                            //ScoreManager.Instance.AddScore(1);
                            Destroy(x.gameObject);
                        }
                    
                }
              

            }
        }

    }


}
