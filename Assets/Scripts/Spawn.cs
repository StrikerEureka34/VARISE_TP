using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject enemyPrefab;
    public Transform homeLocation;
    public float startDelay = 1.0f;
    public float spawnRate = 0.3f;
    public int maxCount = 10;
    int count = 0;

    void Start() {

        InvokeRepeating("Spawner", startDelay, spawnRate);
    }

    void Spawner() {

        GameObject enemy = Instantiate(Resources.Load("Prefabs/Tank") as GameObject, transform.position, Quaternion.identity);
        //GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet02") as GameObject, currentEnemyTarget.transform.position, Quaternion.identity);
        enemy.GetComponent<FindHome>().destination = homeLocation;
        count++;
        if (count >= maxCount) CancelInvoke("Spawner");
    }
}
