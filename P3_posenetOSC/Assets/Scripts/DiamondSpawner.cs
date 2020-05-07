using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSpawner : MonoBehaviour
{

    public GameObject diamPrefab;
    public bool canSpawn = true;
    public List<Transform> diamSpawnPositions = new List<Transform>();
    public float timeBetweenSpawns;
    private List<GameObject> diamList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnProjectile()
    {
        Vector3 randomPosition = diamSpawnPositions[Random.Range(0, diamSpawnPositions.Count)].position;
        GameObject diam = Instantiate(diamPrefab, randomPosition, diamPrefab.transform.rotation);
        diamList.Add(diam);
        print(randomPosition);
        print(diamSpawnPositions.Count);
        
        diam.GetComponent<MoveDiamond>().SetSpawner(this);
        
    }
    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnProjectile();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void RemoveProjFromList(GameObject diam)
    {
        diamList.Remove(diam);
    }
    public void DestroyAllDiamonds()
    {
        foreach (GameObject diam in diamList)
        {
            Destroy(diam);
        }

        diamList.Clear();
    }
}
