using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    Spawn[] spawnPoints;
    static int totalEnemies = 0;
    public static int numberOfWaves=3;
    public static int wavesEmitted=0;
    static bool levelOver=false;
    static bool nextWave=false;

    int timeBetweenWaves=5;


    void Start()
    {

        Time.timeScale = 1;
        GameObject[] spawnP = GameObject.FindGameObjectsWithTag("spawn");
        spawnPoints=new Spawn[spawnP.Length];
        for (int i=0;i<spawnP.Length;i++)
        {
            spawnPoints[i] = spawnP[i].GetComponent<Spawn>();
            totalEnemies += spawnPoints[i].maxCount;
            
        }
    }
    public static void onSpeedchange(int speed)
    {
        Time.timeScale = speed;
    }
    public static void RemoveEnemy() {

        totalEnemies--;
        //Debug.Log(totalEnemies);
        if (totalEnemies <= 0)
        {
            wavesEmitted++;
            nextWave = true;
            if(wavesEmitted>=numberOfWaves)
            {
                Debug.Log("Level Over");
                levelOver = true;
                nextWave= false;
            }
            
        }
    }

    void ResetSpawners()
    {
        foreach (Spawn sp in spawnPoints)
        {

            totalEnemies += sp.maxCount;
            sp.Restart();
        }
    }
    void Update() {
        if (nextWave)
        {
            nextWave=false;
            Invoke("ResetSpawners",timeBetweenWaves);
        }
    }
}
