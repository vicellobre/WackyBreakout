using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    //Components
    BoxCollider2D boxCollider2D;

    float horizontal, sizeCollider, limitRight, limitLeft;

    const float BounceAngleHalfRange = 60f * Mathf.Deg2Rad;

    bool isFrozen;
    Timer timerFrozen;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake() {
        boxCollider2D = GetComponent<BoxCollider2D>();
        timerFrozen = GetComponent<Timer>();
    }
    
    // Start is called before the first frame update
    void Start() {
        sizeCollider = boxCollider2D.size.x;
        limitRight = ScreenUtils.ScreenRight - sizeCollider;
        limitLeft = ScreenUtils.ScreenLeft + sizeCollider;

        isFrozen = false;
        EventManager.AddListenerFreezer(FreezerPaddle);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (timerFrozen.Finished)
        {
            isFrozen = false;
        }        
    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate() {
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0 && !isFrozen) {
            float positionX = transform.position.x + horizontal * ConfigurationUtils.PaddleMoveUnitsPerSecond * Time.fixedDeltaTime;
            transform.position = new Vector3(Mathf.Clamp(positionX, limitLeft, limitRight),
                transform.position.y,
                transform.position.z);
        }
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.CompareTag("Ball") && OnTopPaddle(coll)) {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x - coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter / (sizeCollider / 2);
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    bool OnTopPaddle (Collision2D coll) {
        Vector2 hitPoint = coll.GetContact(0).point;
        float tolerance = 0.05f;

        return (hitPoint.x <= transform.position.x + sizeCollider - tolerance &&
                hitPoint.x >= transform.position.x - (sizeCollider + tolerance));
    }

    void FreezerPaddle(float duration) {
        isFrozen = true;
        if (!timerFrozen.Running) {
            timerFrozen.Duration = duration;
            timerFrozen.Run();
        } else {
            timerFrozen.Duration += duration;
            timerFrozen.Run();
        }
    }
}