using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int waveCount= 0;
    private float TimeForNextWave;
    private int enemyNumber;
    private int kingdomLevel;
    private int playerMoney;

    [SerializeField] EnemyManager enemyManager;
    [SerializeField] MapManager mapManager;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] UiManager uiManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            SpawnWave();
        }
    }

    private void SpawnWave()
    {
        int minEnemy = 5;
        int maxEnemy = 10;
        waveCount++;
        enemyManager.SpawnEnemies(UnityEngine.Random.Range(minEnemy, maxEnemy));
    }
}
