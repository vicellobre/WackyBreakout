using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block {
    [SerializeField]
    Sprite[] sprites = new Sprite[2];
    [SerializeField]
    PickupEffect pickupEffect;
    float durationEffect, effectSpeedup;
    FreezerEffectActivated freezerEffectActivated;
    SpeedupEffectActivated speedupEffectActivated;

    public PickupEffect Effect {
        set {
            switch (value) {
                case PickupEffect.Freezer:
                    pickupEffect = PickupEffect.Freezer;
                    
                    break;
                case PickupEffect.Speedup:
                    pickupEffect = PickupEffect.Speedup;
                    
                    break;
            }
        }
    }

    // Start is called before the first frame update
    override protected void Start() {
        effectSpeedup = ConfigurationUtils.EffectSpeedup;
        points = ConfigurationUtils.PointsPickupBlock;

        switch (pickupEffect) {
                case PickupEffect.Freezer:
                    durationEffect = ConfigurationUtils.DurationEffectFreezer;
                    GetComponent<SpriteRenderer>().sprite = sprites[(int)pickupEffect];
                    freezerEffectActivated = new FreezerEffectActivated();
                    EventManager.AddInvokerFreezer(this);
                    break;
                case PickupEffect.Speedup:
                    durationEffect = ConfigurationUtils.DurationEffectSpeedup;
                    GetComponent<SpriteRenderer>().sprite = sprites[(int)pickupEffect];
                    speedupEffectActivated = new SpeedupEffectActivated();
                    EventManager.AddInvokerSpeedup(this);
                    break;
            }

        base.Start();
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    override protected void OnCollisionEnter2D(Collision2D other) {
        if (pickupEffect == PickupEffect.Freezer) {
            AudioManager.Play(AudioClipName.Freezer);
            freezerEffectActivated.Invoke(durationEffect);
        } else {
            AudioManager.Play(AudioClipName.Speedup);
            speedupEffectActivated.Invoke(durationEffect, effectSpeedup);
        }
        base.OnCollisionEnter2D(other);
    }

    public void AddFreezerEffectListener(UnityAction<float> handler) {
        freezerEffectActivated.AddListener(handler);
    }

    public void AddSpeedupEffectListener(UnityAction<float, float> handler) { //EVENT HANDLER Y TAMBIEN SOY UN DELEGATES
        speedupEffectActivated.AddListener(handler);
    }
}