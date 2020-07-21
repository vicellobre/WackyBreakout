using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour 
{
    protected int points;
    protected PointsAddedEvent pointsAddedEvent;
    protected BlockDestroyedEvent blockDestroyedEvent;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    virtual protected void Start()
    {
        pointsAddedEvent = new PointsAddedEvent();
        EventManager.AddInvokerPoints(this);

        blockDestroyedEvent = new BlockDestroyedEvent();
        EventManager.AddInvokerBlocDestroyed(this);
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    virtual protected void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            pointsAddedEvent.Invoke(points);
            if (GameObject.FindGameObjectsWithTag("Block").Length == 1)
            {
                blockDestroyedEvent.Invoke();
                AudioManager.Play(AudioClipName.YouWin);
            }
            Destroy(gameObject);
        }
    }

    public void AddPointsAddedListener (UnityAction<int> handler) {
        pointsAddedEvent.AddListener(handler);
    }

    public void AddBlockDestroyedListener(UnityAction handler) {
        blockDestroyedEvent.AddListener(handler);
    }
}
