using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCounterUI : MonoBehaviour
{
    private int killCount;
    private int spawnCount;
    private TextMeshProUGUI textUI;

    private void Awake()
    {
        textUI = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        killCount = spawnCount = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (!enabled) return;
        textUI.text = $"Kill/Alive/Spawn\n{killCount}/{spawnCount - killCount}/{spawnCount}";
    }

    public void OnSpawn()
    {
        spawnCount++;
        UpdateUI();
    }

    public void OnKill()
    {
        killCount++;
        UpdateUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
