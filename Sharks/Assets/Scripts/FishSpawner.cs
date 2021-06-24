using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject Fish;
    public float TimeSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCD());
    }

    void Repeat()
    {
        StartCoroutine(SpawnCD());
    }
    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(TimeSpawn);
        Instantiate(Fish, SpawnPos.position, Quaternion.identity);
        Repeat();
    }
}
