using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private bool    isPlayOnStart = true; //���� ���� ���ڸ��� �� ������ ������?
    [SerializeField]
    private float startFactor = 1;  //�� ���� ���� �⺻ ��
    [SerializeField]
    private float additiveFactor = 0.1f;  //�� ���� ���ڿ� �� �� �������� �� 
    [SerializeField]
    private float delayPerSpawnGroup = 3; //�� ���� �ֱ�

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        if (isPlayOnStart)
        {
            Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        StartCoroutine(nameof(SpawnProcess));
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnProcess()
    {
        float factor = startFactor;
        while (true)
        {
            yield return new WaitForSeconds(delayPerSpawnGroup);
            yield return StartCoroutine(SpawnEnemy(factor));
            factor += additiveFactor;
        }
    }

    private IEnumerator SpawnEnemy(float factor)
    {
        float spawnCount = Random.Range(factor, factor * 2);

        for (int i = 0; i < spawnCount; ++i)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation, transform);

            if (Random.value < 0.2f)
            {
                yield return new WaitForSeconds(Random.Range(0.01f, 0.02f));
            }
        }
    }
}
