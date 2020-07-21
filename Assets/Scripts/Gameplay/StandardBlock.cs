using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block
{
    [SerializeField]
    Sprite[] sprites = new Sprite[3];
    
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    override protected void Start() {
        points = ConfigurationUtils.PointsStandarBlock;
        SpriteRandom();

        base.Start();
    }

    override protected void OnCollisionEnter2D(Collision2D other) {
        AudioManager.Play(AudioClipName.Standar);
        base.OnCollisionEnter2D(other);
    }
    
    void SpriteRandom() {
        int r = Random.Range(0, 3);
        GetComponent<SpriteRenderer>().sprite = sprites[r];
    }
}
