using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Core : MonoBehaviour
{
    [SerializeField]
    private int maxHP = 10;
    private int currentHP;

    [SerializeField]
    private UnityEvent<string> onHPChanged;
    [SerializeField]
    private UnityEvent onHit;
    [SerializeField]
    private UnityEvent onDestroy;

    private static Core instance;
    public static Core Instance
    {
        get
        {
            if(instance == null)
                instance = GameObject.FindAnyObjectByType<Core>();
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        currentHP = maxHP;
        UpdateUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            onHit?.Invoke();
            DecreaseHP(1);
            enemy.Destroy();
        }
    }

    private void    DecreaseHP(int amout)
    {
        if (currentHP <= 0) return;

        currentHP -= amout;

        if (currentHP <= 0)
        {
            currentHP = 0;
            onDestroy?.Invoke();

        }
        UpdateUI();
    }
    private void UpdateUI()
    {
        onHPChanged?.Invoke($"HP : {currentHP}");   
    }
}
