using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {

    [SerializeField]
    GameObject paddle;
    [SerializeField]
    GameObject standarBlock, bonusBlock, pickupBlock;

    // Start is called before the first frame update
    void Start() {
        Instantiate(paddle);
        BuildRowsBlocks();
    }

    void BuildRowsBlocks() {
        float separation = 0.5f;
        float alturaPivote = ScreenUtils.ScreenTop - separation;
        float anchuraBloque = standarBlock.GetComponent<BoxCollider2D>().size.x;
        float alturaBloque = standarBlock.GetComponent<BoxCollider2D>().size.y;

        for (int i = 0; i < 3; i++, alturaPivote -= (alturaBloque + separation)) {
            for (float x = 0; x < ScreenUtils.ScreenRight && -x > ScreenUtils.ScreenLeft; x += anchuraBloque + separation) {
                if (x == 0)
                {
                    Instantiate(Block(), new Vector3(x, alturaPivote, 0), Quaternion.identity);
                } else
                {
                    Instantiate(Block(), new Vector3(x, alturaPivote, 0), Quaternion.identity);
                    Instantiate(Block(), new Vector3(-x, alturaPivote, 0), Quaternion.identity);
                }
            }
        }
    }

    GameObject Block() {
        int r = Random.Range(0, 100);

        if (r < ConfigurationUtils.ProbabilitiesStandarBlock)
            return standarBlock;
        else if ( r < ConfigurationUtils.ProbabilitiesBonusBlock)
            return bonusBlock;
        else {
            if (r < ConfigurationUtils.ProbabilitiesFreezerBlock)
                pickupBlock.GetComponent<PickupBlock>().Effect = PickupEffect.Freezer;
            else
                pickupBlock.GetComponent<PickupBlock>().Effect = PickupEffect.Speedup;
            return pickupBlock;
        }
    }

}