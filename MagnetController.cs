using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{

    GameObject player;
    PlayerMotor pm;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject);

            if(this.pm.mcState == 1)
            {
                this.pm.mcState = 0;
                Debug.Log("자석시작");
                Debug.Log(this.pm.mcState);
                GameObject.Find("Player").GetComponent<PlayerMotor>().MagnetOn();

            }


        }
    }


    // Start is called before the first frame update
    void Start()
    {
        this.pm = GameObject.Find("Player").GetComponent<PlayerMotor>();
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
