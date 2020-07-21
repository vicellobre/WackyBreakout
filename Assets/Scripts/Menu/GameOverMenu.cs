using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }


    public void Retry() {
        Time.timeScale = 1;
        DestroyBall();
        Destroy(gameObject);
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitMenu() {
        Time.timeScale = 1;
        DestroyBall();
        AudioManager.Play(AudioClipName.Back);
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }

    
    void DestroyBall() {
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Ball"))
        {
            Destroy(ball);
        }
    }
}
