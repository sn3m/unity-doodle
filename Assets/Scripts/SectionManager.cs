using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
    public GameObject platformPrefab;

    private LevelManager levelManager;
    public bool isSingle = true;
    private float singleRatio = 0.5f;

    // Start is called before the first frame update
    void Awake()
    {
        levelManager = FindObjectsOfType<LevelManager>()[0];
        // Don't offset position for first couple of sections
        if (levelManager.IsStartSection()) {
            isSingle = true;
            GameObject newPlatform = Instantiate(platformPrefab, transform.position, Quaternion.identity);
            newPlatform.transform.parent = transform;
        } else
        {
            GameObject prevSection = levelManager.GetLastSection();
            bool isPrevSingle = prevSection.GetComponent<SectionManager>().isSingle;

            // Set platform count ratio based on previous section
            if (isPrevSingle)
            {
                singleRatio = 0.55f;
            } else
            {
                singleRatio = 0.35f;
            }

            isSingle = Random.Range(0f, 1f) < singleRatio;
            Debug.Log(isSingle);
            if(isSingle)
            {
                GameObject newPlatform = Instantiate(platformPrefab, GetRandomPosition(transform.position), Quaternion.identity);
                newPlatform.transform.parent = transform;
            } else
            {
                Vector3 position1 = GetRandomPosition(new Vector3(transform.position.x - levelManager.platformGap / 2, transform.position.y, transform.position.z));
                Vector3 position2 = GetRandomPosition(new Vector3(transform.position.x + levelManager.platformGap / 2, transform.position.y, transform.position.z));
                GameObject newPlatform1 = Instantiate(platformPrefab, position1, Quaternion.identity);
                GameObject newPlatform2 = Instantiate(platformPrefab, position2, Quaternion.identity);
                newPlatform1.transform.parent = transform;
                newPlatform2.transform.parent = transform;
            }

                

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (-levelManager.speed * Time.deltaTime));
    }

    Vector3 GetRandomPosition(Vector3 startPos)
    {
        float x = Random.Range(-levelManager.platformGap / 4, levelManager.platformGap / 4);
        float y = Random.Range(-1f, 1.5f);
        float z = Random.Range(-levelManager.sectionGap / 4, levelManager.sectionGap / 4);

        return new Vector3(startPos.x + x, startPos.y + y, startPos.z + z);
    }
}
