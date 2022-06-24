using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectDisplay : MonoBehaviour
{
    public GameObject collectibles;

    private int collectibleNum;
    public TMP_Text tmp;
    // Start is called before the first frame update
    void Start()
    {
        collectibleNum = collectibles.transform.childCount;
        tmp.SetText(collectibleNum.ToString());
        
    }

    public void reduceCollectibles()
    {
        collectibleNum--;
        tmp.SetText(collectibleNum.ToString());
        //actually deleting a collectible can be found in PlayerMovement
    }


}
