using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Text EnemiesLeftTxt;
    public int EnemiesInWave;
    private int EnemiesLeft;

    public Text WaveTxt;
    public int WaveCount;

    public GameObject UpgradeMenu;

    public Spawner spawner;

    public Text UpgradePointsTxt;
    public int UpgradePoints;

    public Text BaseHealthTxt;
    public int BaseHealth;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        UpgradeMenu.SetActive(false);

        EnemiesLeft = EnemiesInWave;

        WaveTxt.text = "Wave " + WaveCount;
    }

    // Update is called once per frame
    void Update()
    {
        EnemiesLeftTxt.text = "Enemies Left: " + EnemiesLeft;
    }

    public void EnemyCountUpdate()
    {
        EnemiesLeft--;

        if (EnemiesLeft <= 0)
        {
            Time.timeScale = 0;

            UpgradeMenu.SetActive(true);
        }
    }

    public void NextWave()
    {
        Time.timeScale = 1;

        WaveCount += 1;
        WaveTxt.text = "Wave " + WaveCount;


        EnemiesInWave += 5;
        spawner.SpawnAmount = GameManager.Instance.EnemiesInWave;
        EnemiesLeft = EnemiesInWave;

        StartCoroutine(spawner.NormalSpawn());
        StartCoroutine(spawner.HeavySpawn());

        UpgradeMenu.SetActive(false);
    }
}
