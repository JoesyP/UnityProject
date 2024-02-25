using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{   
    [SerializeField]
    public GameObject player;
    private Rigidbody playerrb;

    float spawnDistance = 10;
    float throwSpeed = 5;
    int spawnInterval = 100;
    int tick = 0;

    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerrb = player.GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        ++tick;
        if (tick % spawnInterval == 0) {
            
            Vector3 offsetDirection = new Vector3(Random.Range(-1f,1f),2.5f,Random.Range(0f,1f)).normalized;
            GameObject meteor = Instantiate(prefab, new Vector3(player.transform.position.x, 0, player.transform.position.z) + offsetDirection * spawnDistance, Quaternion.identity);
            Rigidbody rb = meteor.GetComponent<Rigidbody>();

            Vector3 throwDirection = (player.transform.position - meteor.transform.position).normalized;
            rb.velocity = new Vector3(playerrb.velocity.x/3f,0f,playerrb.velocity.z) + throwDirection * throwSpeed;
            Debug.Log(playerrb.velocity);
        }
    }
}

