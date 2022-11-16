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
    public Player player;

    public Text UpgradePointsTxt;
    public int UpgradePoints;

    public Text BaseHealthTxt;
    public int BaseHealth;

    public Text DmgLvlTxt;
    public Text SpeedLvlTxt;
    public Text ReloadLvlTxt;
    public Text BaseHealTxt;
    public Text MaxAmmoUpgradeTxt;


    public int DifficultyIncrement;
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

        DmgLvlTxt.text = "damage lvl: " + player.damage;
        SpeedLvlTxt.text = "movement speed: " + player.speed;
        ReloadLvlTxt.text = "reload speed: " + player.ReloadTime +"s";
        MaxAmmoUpgradeTxt.text = "ammo capacity: " + player.MaxAmmo;
        BaseHealTxt.text = "base hp: " + BaseHealth;
    }

    // Update is called once per frame
    void Update()
    {
        EnemiesLeftTxt.text = "Enemies: " + EnemiesLeft;

        BaseHealthTxt.text = "Health: " + BaseHealth;

        if(WaveCount >= 10)
        {
            SceneManager.LoadScene("WinScene");
        }

        if(BaseHealth <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }

    public void EnemyCountUpdate()
    {
        EnemiesLeft--;

        if (EnemiesLeft <= 0)
        {
            StartCoroutine(WaveEnd(2));
        }
    }

    public void NextWave()
    {
        Time.timeScale = 1;

        WaveCount++;
        WaveTxt.text = "Wave " + WaveCount;

        DifficultyIncrement++;

        UpgradePoints += 3;

        EnemiesInWave += 5;
        spawner.SpawnAmount = GameManager.Instance.EnemiesInWave;
        EnemiesLeft = EnemiesInWave;

        StartCoroutine(spawner.NormalSpawn());
        StartCoroutine(spawner.HeavySpawn());

        UpgradeMenu.SetActive(false);
    }

    public void UpgradeDmg()
    {
        if (UpgradePoints > 0)
        {
            if (player.damage < 5)
            {
                UpgradePoints -= 2;
                player.damage += 1f;
                DmgLvlTxt.text = "damage lvl: " + player.damage;
                UpgradePointsTxt.text = "upgrade points: " + UpgradePoints;
            }
            else
            {
                DmgLvlTxt.text = "damage lvl: max";
            }
        }
    }

    public void UpgradeSpeed()
    {
        if (UpgradePoints > 0)
        {
            UpgradePoints -= 1;
            player.speed += 0.5f;
            SpeedLvlTxt.text = "movement speed: " + player.speed;
            UpgradePointsTxt.text = "upgrade points: " + UpgradePoints;
        }
    }

    public void UpgradeReload()
    {
        if (UpgradePoints > 0)
        {
            UpgradePoints -= 1;
            player.ReloadTime -= 0.2f;
            ReloadLvlTxt.text = "reload speed: " + player.ReloadTime + " s";
            UpgradePointsTxt.text = "upgrade points: " + UpgradePoints;
        }
    }

    public void BaseHeal()
    {
        if (UpgradePoints > 0)
        {
            UpgradePoints -= 1;
            BaseHealth += BaseHealth / 100 * 10;
            BaseHealTxt.text = "base hp: " + BaseHealth;
            UpgradePointsTxt.text = "upgrade points: " + UpgradePoints;
        }
    }

    public void UpgradeMaxAmmo()
    {
        if (UpgradePoints > 0)  
        {
            UpgradePoints -= 1;
            player.MaxAmmo += 2;
            MaxAmmoUpgradeTxt.text = "ammo capacity: " + player.MaxAmmo;
            UpgradePointsTxt.text = "upgrade points: " + UpgradePoints;
        }
    }

    public IEnumerator WaveEnd(float interval)
    {
        yield return new WaitForSeconds(interval);

        Time.timeScale = 0;

        UpgradeMenu.SetActive(true);

        UpgradePointsTxt.text = "upgrade points: " + UpgradePoints;
    }
}
