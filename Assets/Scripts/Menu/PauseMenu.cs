using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        AudioManager.Play(AudioClipName.Pause);
    }

    public void Resume() {
        Time.timeScale = 1;
        AudioManager.Play(AudioClipName.Click);
        Destroy(gameObject);
    }

    public void QuitMenu() {
        Time.timeScale = 1;
        AudioManager.Play(AudioClipName.Back);
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}
