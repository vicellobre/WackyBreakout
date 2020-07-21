using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabsBall;
    Timer timerRandomSpawn;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        timerRandomSpawn = GetComponents<Timer>()[0];
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        Instantiate(prefabsBall);
        timerRandomSpawn.Duration = Random.Range(ConfigurationUtils.TimeMinimunSpawn, ConfigurationUtils.TimeMaximunSpawn);
        timerRandomSpawn.Run();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(timerRandomSpawn.Finished) {
            SpawningBalls();
        }
    }

    public void SpawningBalls() {
        SpawnBall();
        timerRandomSpawn.Duration = Random.Range(ConfigurationUtils.TimeMinimunSpawn, ConfigurationUtils.TimeMaximunSpawn);
        timerRandomSpawn.Run();
    }

    public void SpawnBall() {
        Instantiate(prefabsBall);
    } 

}
