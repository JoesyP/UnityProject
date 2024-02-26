using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{   
    [SerializeField]
    public GameObject player;
    private Rigidbody playerrb;

    float spawnDistance = 50f;
    float throwSpeed = 50f;
    int spawnInterval = 250;
    int tick = 0;
    private float size = 1f;

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
        if (Random.Range(0f,1f) < 0.0001) {
            spawnInterval = 1;
            throwSpeed *= 10;
            size *= 5;
        }
        if (tick % spawnInterval == 0) {
            
            Vector3 offsetDirection = new Vector3(Random.Range(-1f,1f),2.5f,Random.Range(0f,10f)).normalized;
            GameObject meteor = Instantiate(prefab, new Vector3(player.transform.position.x, 0, player.transform.position.z) + offsetDirection * spawnDistance, Quaternion.identity);
            meteor.transform.localScale = size * new Vector3(Random.Range(.01f,.5f),Random.Range(.01f,.5f),Random.Range(.01f,.5f));
            Rigidbody rb = meteor.GetComponent<Rigidbody>();

            Vector3 throwDirection = (player.transform.position - meteor.transform.position).normalized;
            rb.velocity = new Vector3(playerrb.velocity.x/3f,0f,playerrb.velocity.z) + throwDirection * throwSpeed;
            Debug.Log(playerrb.velocity);
        }
        spawnInterval = (int)(spawnInterval * .99f + 1);
        throwSpeed *= 1.001f;
    }
}

