using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMenu : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button backMenu;
    [SerializeField] private Button exit;


    private void Start()
    {
        play.onClick.AddListener(PlayHandler);
        backMenu.onClick.AddListener(BackMenuHandler);
        exit.onClick.AddListener(ExitHandler);
    }

    private void PlayHandler()
    {
        SceneManager.LoadScene("Game");
    }

    private void BackMenuHandler()
    {
        SceneManager.LoadScene("Menu");
    }

    private void ExitHandler()
    {
        Application.Quit();
    }
}
