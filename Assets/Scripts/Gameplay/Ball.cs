using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour {
    //Variables Primitivas
    bool isSpeedup;
    float ballColliderHalfHeight;

    // Objetos de Unity
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    //Componentes de Unity
    new Rigidbody2D rigidbody2D;

    //Componentes Scripts
    Timer lifetimeBall, timerToMove;
    BallSpawner ballSpawner;


    //Objetos Eventos
    CountBallsLeft countBallsLeft;
    //DeadBallEvent deadBallEvent;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = boxCollider.size.x / 2;
        float ballColliderHalfHeight = boxCollider.size.y / 2;
        spawnLocationMin = new Vector2(transform.position.x - ballColliderHalfWidth, transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(transform.position.x + ballColliderHalfWidth, transform.position.y + ballColliderHalfHeight);
        Destroy(boxCollider);
        this.ballColliderHalfHeight = ballColliderHalfHeight;

        rigidbody2D = GetComponent<Rigidbody2D>();
        lifetimeBall = GetComponents<Timer>()[0];
        timerToMove = GetComponents<Timer>()[1];
        ballSpawner = Camera.main.GetComponent<BallSpawner>();

    }
    // Start is called before the first frame update
    void Start() {
        lifetimeBall.Duration = ConfigurationUtils.LifetimeBall;
        lifetimeBall.Run();

        timerToMove.Duration = 1;
        timerToMove.Run();

        isSpeedup = false;

        countBallsLeft = new CountBallsLeft();
        //deadBallEvent = new DeadBallEvent();
        EventManager.AddInvokerBallsLeft(this);
        //EventManager.AddInvokerBallsLeft(this);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {
        if (timerToMove.Finished)
        {
            StartMoving();
            timerToMove.Stop();
        }
        
        if (lifetimeBall.Finished && SpawnBall()) {
            ballSpawner.SpawnBall();///aqui invocar al listener deadBallEvent.Invoke()
            Destroy(gameObject);
        }

        if (!EffectsUtils.EffectActive && isSpeedup) {
            rigidbody2D.velocity /= EffectsUtils.FactorSpeedup;
            isSpeedup = false;
        }

        if (rigidbody2D.velocity.magnitude > 0 && EffectsUtils.EffectActive && !isSpeedup){
            isSpeedup = true;
            rigidbody2D.velocity *= EffectsUtils.FactorSpeedup;
        }
    }

    void StartMoving() {
        float x = Mathf.Cos(20);
        float y = Mathf.Sin(20);
        rigidbody2D.AddForce(new Vector2(x, y) * ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
    }

    public void SetDirection(Vector2 direction) {
        rigidbody2D.velocity = rigidbody2D.velocity.magnitude * direction;
    }

    /// <summary>
    /// OnBecameInvisible is called when the renderer is no longer visible by any camera.
    /// las condiciones son al reves
    /// </summary>
    void OnBecameInvisible() {
        if (!lifetimeBall.Finished && !(ScreenUtils.ScreenBottom > transform.position.y + ballColliderHalfHeight)) {
            countBallsLeft.Invoke();
            if (SpawnBall()) {
                ballSpawner.SpawnBall();///aqui invocar al listener deadBallEvent.Invoke()
            }
            Destroy(gameObject);
        }
    }

    public bool SpawnBall() {
        // make sure we don't spawn into a collision
        return (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null);
    }

    public void AddCountBallsLeftListener(UnityAction handler) {
        countBallsLeft.AddListener(handler);
    }
}