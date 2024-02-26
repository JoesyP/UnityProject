using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GroundSpawner groundSpawner; 
    //public GameObject player;
    //Collider playerCollider;

    private void Start(){
        //playerCollider = player.GetComponent<Collider>();
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit (Collider other){
        if (other.gameObject.tag != "Player") return;
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    private void Update(){
        
    }
}
