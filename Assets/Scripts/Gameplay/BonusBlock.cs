using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block
{
    // Start is called before the first frame update
    override protected void Start()
    {
        points = ConfigurationUtils.PointsBonusBlock;
        base.Start();
    }

    override protected void OnCollisionEnter2D(Collision2D other) {
        AudioManager.Play(AudioClipName.Bonus);
        base.OnCollisionEnter2D(other);
    }
}
