using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {


    public GameObject[] cars;
    float Timer;
    public float DelayTimer=1f;
    int carNo;
	// Use this for initialization
	void Start () {

        Timer = DelayTimer;
	}

    // Update is called once per frame
    void Update()
    {

        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Vector3 carPos = new Vector3(Random.Range(-4.89f, 5.07f), transform.position.y, transform.position.z);
            carNo = Random.Range(0, 7);
            
            Instantiate(cars[carNo], carPos, transform.rotation);
            Timer = DelayTimer; 
        }

    }

  
}
