using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullController : MonoBehaviour
{
    GameObject player;
    PlayerMotor pm;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject);
            this.pm.SkullStatus = 0;
            GameObject.Find("Player").GetComponent<PlayerMotor>().SkullOn();
            Debug.Log("방향전환시작");
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
