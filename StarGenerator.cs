using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public GameObject HardStar;
    float leftx = -1.92f;
    float centerx = 0.0f;
    float rightx = 1.92f;
    GameObject player;
    GameObject go;
    ItemGenerator item;

    float span = 43.0f;
    float time;

    public int rw2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.item = GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>();
        rw2 = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;
        if (this.time > this.span)
        {
            this.time = 0;

            rw2 = Random.Range(0, 3);
            changew(rw2);
            create(rw2);
        }


    }
    void create(int a)
    {
        if (a == 0 )
        {
            go = Instantiate(HardStar) as GameObject;
            go.transform.position = new Vector3(leftx, 1.8f, this.player.transform.position.z + 18);
        }
        if (a == 1)
        {
            go = Instantiate(HardStar) as GameObject;
            go.transform.position = new Vector3(centerx, 1.8f, this.player.transform.position.z + 18);
        }
        if (a == 2)
        {
            go = Instantiate(HardStar) as GameObject;
            go.transform.position = new Vector3(rightx, 1.8f, this.player.transform.position.z + 18);
        }
    }

    void changew(int b)
    {
        if(b ==0 && item.rw==0)
        {
            this.rw2 = Random.Range(1, 3);
        }
        else if(b==1 && item.rw==1)
        {
            int x = Random.Range(0, 2);
            this.rw2 = x * 2;
        }
        else if(b==2 && item.rw==2)
        {
            this.rw2 = Random.Range(0, 2);
        }
    }
}
