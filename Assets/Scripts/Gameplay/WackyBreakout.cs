using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WackyBreakout : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddListenerHUD(GameOverMessage);
        EventManager.AddListenerBlockDestroyed(GameOverMessage);
    }


    void GameOverMessage () {
        HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        MenuManager.GoToMenu(MenuName.GameOver);
        GameObject.FindGameObjectWithTag("TextYouScore").GetComponent<Text>().text = "You score: " + hud.Score.ToString();
        Destroy(hud.gameObject);
    }
}
