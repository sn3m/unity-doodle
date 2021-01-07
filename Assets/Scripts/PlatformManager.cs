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
                Vector3 coinPosition = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
                GameObject newCoin = Instantiate(coinPrefab, coinPosition, coinPrefab.transform.rotation);
                newCoin.transform.parent = transform;
            }
            
        }
        

    }
}
