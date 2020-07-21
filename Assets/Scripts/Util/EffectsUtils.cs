using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectsUtils
{
    static SpeedupEffectMonitor speedupEffectMonitor = Camera.main.GetComponent<SpeedupEffectMonitor>();

    public static float Duration { get { return speedupEffectMonitor.Duration; } }

    public static bool EffectActive { get {return speedupEffectMonitor.EffectActive; } }

    public static float FactorSpeedup { get {return speedupEffectMonitor.FactorSpeedup; } }
}