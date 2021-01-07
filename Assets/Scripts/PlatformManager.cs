using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public float coinRate;
    // Start is called before the first frame update
    void Start()
    {
        if(!GetComponentInParent<SectionManager>().isStarting)
        {
            if(Random.Range(0f, 1f) < coinRate)
            {
                GameObject newCoin = Instantiate(coinPrefab, transform.position, coinPrefab.transform.rotation);
                newCoin.transform.parent = transform;
            }
            
        }
        

    }
}
