using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnerMods
{
    Fixed,
    Random
}
public class Spawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform _player;
    [SerializeField] public SpawnerMods spawnMod = SpawnerMods.Fixed;

    public Minigamedatas minigamedatas;

    [SerializeField] private int enemyCount = 10;
    [SerializeField] private float delayBtwWaves = 1f;

    [Header("Fixed Delay")]
    [SerializeField] private float delayBtwSpawns;

    [Header("Random Delay")]
    [SerializeField] private float minRandomDelay;
    [SerializeField] private float maxRandomDelay;
    [SerializeField] private GameObject Zombie; 

    private float _spawntimer;
    private int _enemiesSpawned;
    private int _enemiesRamaning;

    private void Awake()
    {
        _enemiesRamaning = enemyCount;
    }

    private void Update()
    {
        _spawntimer -= Time.deltaTime;
        if(_spawntimer < 0)
        {
            _spawntimer= GetSpawnDelay(); 

            if(_enemiesSpawned < enemyCount & minigamedatas.canSpawn) 
            {
                _enemiesSpawned++;
                SpawnEnemy();
            }
        }
    }
    private void SpawnEnemy()
    {
       GameObject newZombie= Instantiate(Zombie, transform.position, transform.rotation);
       newZombie.GetComponent<Zombie>().player = _player;
    }

    private float GetSpawnDelay()
    {
        float delay = 0f;

        if(spawnMod == SpawnerMods.Fixed) 
        {
            delay = delayBtwSpawns;
        }
        else
        {
            delay = GetRandomDelay();
        }
        return delay;
    }

    private float GetRandomDelay()
    {
        float randomTimer = Random.Range(minRandomDelay, maxRandomDelay);

        return randomTimer;
    }

    private IEnumerator NextWave()
    {
        yield return new WaitForSeconds(delayBtwWaves);
        _enemiesRamaning = enemyCount;
        _spawntimer = 0;
        _enemiesSpawned = 0;
    }
  
}



