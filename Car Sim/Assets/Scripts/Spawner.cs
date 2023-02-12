using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] spawnPoints;

    [SerializeField] private CarsNavmesh[] cars;
    
    

    private int count;
    private bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count < 20 && spawn)
        {
            count++;
            spawn = false;
            
            int nextSpawnLocation = Random.Range(0, spawnPoints.Length);
            int nextCar = Random.Range(0, cars.Length);
            int targetPoint = Random.Range(0, spawnPoints.Length);

            if (targetPoint != nextSpawnLocation)
            {
                var i = Instantiate(cars[nextCar], spawnPoints[nextSpawnLocation].transform.position,
                    Quaternion.identity);
                i.Setup(spawnPoints[targetPoint].transform);
                if (i.GetComponent<NissanNavmesh>())
                {
                    i.GetComponent<NissanNavmesh>().Setup(spawnPoints[targetPoint].transform);
                }
            }
            
            StartCoroutine(PauseSpawn());
        }
    }

    IEnumerator PauseSpawn()
    {
        yield return new WaitForSeconds(2);
        spawn = true;
    }


}
