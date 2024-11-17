using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    public float minionsMoveSpeed;
    public float superMinionsMoveSpeed;

    public GameObject minionPrefab;
    public GameObject SuperMinion;
    public Transform[] spawnerPoint;
    public float spawnInterval = 20;
    public int minionsPerWave = 6;
    public int waveUntilSuperMinion = 3;
    private int waveCount = 0;

    public float delayBetweenMinions;

    private void Start()
    {
        StartCoroutine(SpawnMinions());
    }
    IEnumerator SpawnMinions()
    {
        while (true)
        {
            waveCount++;
            if (waveCount % waveUntilSuperMinion == 0)
            {
                for (int i = 0; i < minionsPerWave - 1; i++)
                {
                    SpawnReularMinion();
                    yield return new WaitForSeconds(delayBetweenMinions);
                }

                SpawnSuperMinion();
                yield return new WaitForSeconds(spawnInterval - delayBetweenMinions * (minionsPerWave - 1) - delayBetweenMinions);

            }
            else
            {
                for(int i = 0;i < minionsPerWave; i++)
                {
                    SpawnReularMinion();
                    yield return new WaitForSeconds(delayBetweenMinions);
                }
                yield return new WaitForSeconds(spawnInterval - delayBetweenMinions * minionsPerWave);

            }
        }
    }
    private void SpawnReularMinion()
    {
        Transform spawinPoint = spawnerPoint[Random.Range(0, spawnerPoint.Length)];
        GameObject minion = Instantiate(minionPrefab, spawinPoint.position, spawinPoint.rotation);
        minion.gameObject.SetActive(true);

        UnityEngine.AI.NavMeshAgent minionAgent = minion.GetComponent<UnityEngine.AI.NavMeshAgent>();
        minionAgent.speed = minionsMoveSpeed;
    }
    private void SpawnSuperMinion()
    {
        Transform spawinPoint = spawnerPoint[Random.Range(0, spawnerPoint.Length)];
        GameObject superMinion = Instantiate(SuperMinion, spawinPoint.position, spawinPoint.rotation);
        superMinion.gameObject.SetActive(true);

        UnityEngine.AI.NavMeshAgent minionAgent = superMinion.GetComponent<UnityEngine.AI.NavMeshAgent>();
        minionAgent.speed = minionsMoveSpeed;
    }
}
