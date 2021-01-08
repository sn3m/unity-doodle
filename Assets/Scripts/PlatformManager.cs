using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject bouncyPrefab;
    public float coinRate;
    public float bouncyRate;
    public float smallRate;
    // Start is called before the first frame update
    void Start()
    {
        // Randomly rotate the platform
        float angle = Random.Range(-1, 1)*90;
        transform.Rotate(0, angle, 0);

        // Randomly make platform smaller
        if(Random.Range(0f, 1f) < smallRate)
        {
            transform.localScale = new Vector3(4, 5, 4);
        }

        // Try to add coin and powerup
        if(!GetComponentInParent<SectionManager>().isStarting)
        {
            var random = Random.Range(0f, 1f);
            if (random < coinRate)
            {
                GameObject newCoin = Instantiate(coinPrefab, transform.position, coinPrefab.transform.rotation);
                newCoin.transform.parent = transform;
            }
            if(random < bouncyRate)
            {
                GameObject newBouncy = Instantiate(bouncyPrefab, transform.position, Quaternion.identity);
                newBouncy.transform.parent = transform;
            }
            
        }
        

    }
}
