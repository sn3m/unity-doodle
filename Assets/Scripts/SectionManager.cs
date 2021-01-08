using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
    public GameObject platformPrefab;

    private LevelManager levelManager;
    public bool isSingle = true;
    public bool isStarting = false;
    private float singleRatio = 0.5f;

    // Start is called before the first frame update
    void Awake()
    {
        levelManager = FindObjectsOfType<LevelManager>()[0];
        // Don't offset position for first couple of sections
        if (levelManager.IsStartSection()) {
            isSingle = true;
            isStarting = true;
            Instantiate(platformPrefab, transform.position, Quaternion.identity, transform);
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
            if(isSingle)
            {
                Instantiate(platformPrefab, GetRandomPosition(transform.position), Quaternion.identity, transform);
            } else
            {
                Vector3 position1 = GetRandomPosition(new Vector3(transform.position.x - levelManager.platformGap / 2, transform.position.y, transform.position.z));
                Vector3 position2 = GetRandomPosition(new Vector3(transform.position.x + levelManager.platformGap / 2, transform.position.y, transform.position.z));
                Instantiate(platformPrefab, position1, Quaternion.identity, transform);
                Instantiate(platformPrefab, position2, Quaternion.identity, transform);
            }

                

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (-LevelManager.Speed * Time.deltaTime));
    }

    Vector3 GetRandomPosition(Vector3 startPos)
    {
        float x = Random.Range(-levelManager.platformGap / 4, levelManager.platformGap / 4);
        float y = Random.Range(-1.5f, 2f);
        float z = Random.Range(-levelManager.sectionGap / 4, levelManager.sectionGap / 4);

        return new Vector3(startPos.x + x, startPos.y + y, startPos.z + z);
    }
}
