using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffectMonitor : MonoBehaviour
{
    Timer timerSpeedup;
    static float factorSpeedup = 1;

    public float Duration { get { return timerSpeedup.Duration; } }

    public bool EffectActive { get {return timerSpeedup.Running; } }

    public float FactorSpeedup { get {return factorSpeedup; } }

    void Awake() {
        timerSpeedup = GetComponents<Timer>()[1];
    }

    // Start is called before the first frame update
    void Start()
    {
        factorSpeedup = ConfigurationUtils.BallImpulseForce;
        EventManager.AddListenerSpeedup(SpeedBalls);
        factorSpeedup = ConfigurationUtils.EffectSpeedup;
    }

    void SpeedBalls (float duration, float speedup) {
        timerSpeedup.Duration = duration;
        timerSpeedup.Run();

        factorSpeedup = speedup;
    }
}