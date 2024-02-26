using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

public GameObject groundTile; 
Vector3 nextSpawnPoint;

public void SpawnTile () {

    GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
    nextSpawnPoint = temp.transform.GetChild(1).transform.position;

}

    // Start is called before the first frame update
    private void Start()
    {
        for(int i = 0; i < 30; i++){
            SpawnTile();
        }
    }
    
}
