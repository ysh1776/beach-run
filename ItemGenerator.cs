using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject Diamondo;
    float leftx = -1.92f;
    float centerx = 0.0f;
    float rightx = 1.92f;
    GameObject player;
    GameObject go;
    float span = 2.5f;
    float span2 = 0.4f;
    float time;
    float time2;
    public int rw = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        rw = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;
        this.time2 += Time.deltaTime;
        if (this.time > this.span)
        {
            this.time = 0;

            rw = Random.Range(0, 3);

        }
        if (this.time2 > this.span2)
        {
            this.time2 = 0;
            if (rw == 0)
            {
                go = Instantiate(Diamondo) as GameObject;
                go.transform.position = new Vector3(leftx, 1.8f, this.player.transform.position.z + 18);
            }
            if (rw == 1)
            {
                go = Instantiate(Diamondo) as GameObject;
                go.transform.position = new Vector3(centerx, 1.8f, this.player.transform.position.z + 18);
            }
            if (rw == 2)
            {
                go = Instantiate(Diamondo) as GameObject;
                go.transform.position = new Vector3(rightx, 1.8f, this.player.transform.position.z + 18);
            }
        }
    }
}