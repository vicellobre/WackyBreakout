using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static List<PickupBlock> invokersFreezer = new List<PickupBlock>();
    static List<PickupBlock> invokersSpeedup = new List<PickupBlock>();
    static List<Block> invokersPoints = new List<Block>();
    static List<Ball> invokersBallsLeft = new List<Ball>();
    static HUD invokerHUD;
    static List<Block> invokersBlockDestroyed = new List<Block>();

    static List<UnityAction<float>> listenersFreezer = new List<UnityAction<float>>();
    static List<UnityAction<float, float>> listenersSpeedup = new List<UnityAction<float, float>>();
    static List<UnityAction<int>> listenersPoints = new List<UnityAction<int>>();
    static List<UnityAction> listenerBallsLeft = new List<UnityAction>();
    static UnityAction listenerHUD;
    static List<UnityAction> listenerBlockDestroyed = new List<UnityAction>();

    public static void AddInvokerFreezer(PickupBlock invoker) {
        invokersFreezer.Add(invoker);
        foreach (UnityAction<float> listener in listenersFreezer)
        {
            invoker.AddFreezerEffectListener(listener);
        }
    }
    public static void AddListenerFreezer (UnityAction<float> handler) {
        listenersFreezer.Add(handler);
        foreach (PickupBlock invoker in invokersFreezer)
        {
            invoker.AddFreezerEffectListener(handler);
        }
    }


    public static void AddInvokerSpeedup(PickupBlock invoker) {
        invokersSpeedup.Add(invoker);
        foreach (UnityAction<float, float> listener in listenersSpeedup)
        {
            invoker.AddSpeedupEffectListener(listener);
        }
    }
    public static void AddListenerSpeedup (UnityAction<float, float> handler) {
        listenersSpeedup.Add(handler);
        foreach (PickupBlock invoker in invokersSpeedup)
        {
            invoker.AddSpeedupEffectListener(handler);
        }
    }


    public static void AddInvokerPoints(Block invoker) {
        invokersPoints.Add(invoker);
        foreach (UnityAction<int> listener in listenersPoints)
        {
            invoker.AddPointsAddedListener(listener);
        }
    }
    public static void AddListenerPoints (UnityAction<int> handler) {
        listenersPoints.Add(handler);
        foreach (Block invoker in invokersPoints)
        {
            invoker.AddPointsAddedListener(handler);
        }
    }


    public static void AddInvokerBallsLeft(Ball invoker) {
        invokersBallsLeft.Add(invoker);
        foreach (UnityAction listener in listenerBallsLeft)
        {
            invoker.AddCountBallsLeftListener(listener);
        }
    }
    public static void AddListenerBallsLeft (UnityAction handler) {
        listenerBallsLeft.Add(handler);
        foreach (Ball invoker in invokersBallsLeft)
        {
            invoker.AddCountBallsLeftListener(handler);
        }
    }


    public static void AddInvokerHUD (HUD invoker) {
        invokerHUD = invoker;
        if (listenerHUD != null)
        {
            invokerHUD.AddGameOverMessageListener(listenerHUD);
        }
    }

    public static void AddListenerHUD (UnityAction handler) {
        listenerHUD = handler;
        if (invokerHUD != null)
        {
            invokerHUD.AddGameOverMessageListener(handler);
        }
    }


    public static void AddInvokerBlocDestroyed(Block invoker) {
        invokersBlockDestroyed.Add(invoker);
        foreach (UnityAction listener in listenerBlockDestroyed)
        {
            invoker.AddBlockDestroyedListener(listener);
        }
    }
    public static void AddListenerBlockDestroyed (UnityAction handler) {
        listenerBlockDestroyed.Add(handler);
        foreach (Block invoker in invokersBlockDestroyed)
        {
            invoker.AddBlockDestroyedListener(handler);
        }
    }
}
