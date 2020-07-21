using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpMenu : MonoBehaviour
{
    public void Back() {
        MenuManager.GoToMenu(MenuName.Main);
        AudioManager.Play(AudioClipName.Back);
    }
}