using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame () {
        AudioManager.Play(AudioClipName.Click);
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame() {
        AudioManager.Play(AudioClipName.Back);
        Application.Quit();
    }

    public void Help() {
        AudioManager.Play(AudioClipName.Click);
        MenuManager.GoToMenu(MenuName.Help);
    }
}
