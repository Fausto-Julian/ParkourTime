using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private HealthController _healthControllerPlayer;
    private WinScript _winScript;

    [SerializeField] private Image lifeBar;

    private void Awake()
    {
        _healthControllerPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
        _winScript = GameObject.FindGameObjectWithTag("WinScript").GetComponent<WinScript>();
    }

    private void Start()
    {
        _healthControllerPlayer.OnDeath += DeathHandler;
        _winScript.OnWin += WinHandler;
    }

    private void Update()
    {
        var maxHealth = _healthControllerPlayer.GetDefaultHealth();
        var currentHealth = _healthControllerPlayer.GetCurrentHealth();
        float health = currentHealth / maxHealth;

        lifeBar.fillAmount = health;
    }

    private void DeathHandler()
    {
        SceneManager.LoadScene("DefeatScene");
    }

    private void WinHandler()
    {
        SceneManager.LoadScene("WinScene");
    }
}
