using System.Collections;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private float spawnDelay = 1f;
    private int minionCount = 6;

    public GameObject[] minions;

    void Start()
    {
        StartCoroutine(SpawnMinion());
    }
    
    IEnumerator SpawnMinion()
    {
        yield return new WaitForSeconds(6f);
        for (int i = 0; i < minionCount; i++)
        {
            GameObject minionSpawned = Instantiate(minions[0].gameObject, transform.position, Quaternion.identity);
            minionSpawned.GetComponent<MinionController>().SetMinionIndex(transform.parent.GetComponent<CoreController>().playerIndex);
            yield return new WaitForSeconds(spawnDelay);
        }
        StartCoroutine(SpawnMinion());
    }
}