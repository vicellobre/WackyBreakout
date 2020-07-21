using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour 
{
    /// <summary>
    /// Awake is called before Start
    /// </summary>
	void Awake()
    {
        // initialize screen utils
        ScreenUtils.Initialize();
        ConfigurationUtils.Initialize();
    }
        /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        SetEgdeCollider2D();
    }

    void SetEgdeCollider2D() {
        int i = 0;
        foreach (EdgeCollider2D collider in gameObject.GetComponentsInChildren<EdgeCollider2D>())
        {
            Vector2[] elements = new Vector2[2];
            i++;
            switch (i)
            {
                case 1: //Left
                    elements[0] = new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenTop);
                    elements[1] = new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenBottom);
                break;

                case 2: //Top
                    elements[0] = new Vector2(ScreenUtils.ScreenLeft, ScreenUtils.ScreenTop);
                    elements[1] = new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenTop);
                break;

                case 3: //Right
                    elements[0] = new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenTop);
                    elements[1] = new Vector2(ScreenUtils.ScreenRight, ScreenUtils.ScreenBottom);
                break;
            }
            collider.points = elements;
        }
    }
}
