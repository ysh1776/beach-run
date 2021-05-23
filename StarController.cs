using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    GameObject player;
    PlayerMotor pm;
    fenceController fencle;
    fenceController fencle2;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject);

            this.pm.ChState = 0;
            Debug.Log("무적시작");
            GameObject.Find("Player").GetComponent<PlayerMotor>().StartStarBuff();

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
      //  this.fencle = GameObject.Find("Hurdle01").GetComponent<fenceController>();
        this.fencle2 = GameObject.Find("Hurdle02").GetComponent<fenceController>();

        if (gameObject.transform.position.z < this.player.transform.position.z - 10)
        {
            Destroy(gameObject);
        }
    }
}
