using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{

    GameDirector lifed;
    GameObject player;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject);
            if(this.lifed.lifecount <3)
            {
                this.lifed.lifecount++;
            }

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        this.lifed = GameObject.Find("GameDirector").GetComponent<GameDirector>();
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.z < this.player.transform.position.z - 10)
        {
            Destroy(gameObject);
        }
    }
}
