using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    static Text textScore, textBallsLeft;
    static int score;
    static int numberOfBall;
    LastBallLostEvent lastBallLostEvent;

    public int Score {
        get { return score; }
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
        textScore = GameObject.FindGameObjectWithTag("TextScore").GetComponent<Text>();
        textBallsLeft = GameObject.FindGameObjectWithTag("TextBallsLeft").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start() {
        numberOfBall = ConfigurationUtils.NumberOfBallsPerGame;
        score = 0;
        textScore.text = "Score: " + score.ToString();
        textBallsLeft.text = "Balls Left: " + numberOfBall.ToString();
        EventManager.AddListenerPoints(AddPoints);
        EventManager.AddListenerBallsLeft(CountBallsLeft);
        
        lastBallLostEvent = new LastBallLostEvent();
        EventManager.AddInvokerHUD(this);
    }

    void AddPoints(int points) {
        score += points;
        textScore.text = "Score: " + score.ToString();
    }

    void CountBallsLeft() {
        numberOfBall--;
        textBallsLeft.text = "Balls Left: " + numberOfBall.ToString();

        if (numberOfBall <= 0)
        {
            AudioManager.Play(AudioClipName.TryAgain);
            lastBallLostEvent.Invoke();
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1) {
            MenuManager.GoToMenu(MenuName.Pause);
        }
    }

    public void AddGameOverMessageListener(UnityAction handler) {
        lastBallLostEvent.AddListener(handler);
    }
}