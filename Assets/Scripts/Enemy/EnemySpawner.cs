using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private bool    isPlayOnStart = true; //게임 시작 하자마자 적 생성할 것인지?
    [SerializeField]
    private float startFactor = 1;  //적 새성 숫자 기본 값
    [SerializeField]
    private float additiveFactor = 0.1f;  //적 생성 숫자에 매 턴 더해지는 값 
    [SerializeField]
    private float delayPerSpawnGroup = 3; //적 생성 주기

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
