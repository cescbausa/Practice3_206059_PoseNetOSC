using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{

    public GameObject projPrefab;
    public bool canSpawn = true;
    public List<Transform> projSpawnPositions = new List<Transform>();
    public float timeBetweenSpawns;
    private List<GameObject> projList = new List<GameObject>();

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
        Vector3 randomPosition = projSpawnPositions[Random.Range(0, projSpawnPositions.Count)].position;
        GameObject proj = Instantiate(projPrefab, randomPosition, projPrefab.transform.rotation);
        projList.Add(proj);
        print(randomPosition);
        print(projSpawnPositions.Count);
        
        proj.GetComponent<MoveProjectile>().SetSpawner(this);
        
    }
    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnProjectile();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public void RemoveProjFromList(GameObject proj)
    {
        projList.Remove(proj);
    }

    public void DestroyAllProjectiles()
    {
        foreach (GameObject proj in projList)
        {
            Destroy(proj);
        }

        projList.Clear();
    }
}
