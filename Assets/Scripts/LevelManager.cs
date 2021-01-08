using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform player;
    public GameObject sectionPrefab;
    public float sectionGap = 10f;
    public float platformGap = 10f;
    public int numSections = 10;
    public static float Speed { get; set;}

    private readonly LinkedList<GameObject> sections = new LinkedList<GameObject>();

    public GameObject GetLastSection()
    {
        if (sections.Count>0)
        {
            return sections.Last.Value;
        } else
        {
            return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Speed = 4.4f;
        for(int i=0; i< numSections; i++)
        {
            AddNewSection();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject first = sections.First.Value;
        if (first.transform.position.z < player.position.z - sectionGap)
        {
            sections.RemoveFirst();
            Destroy(first);
            AddNewSection();
        }
    }

    public bool IsStartSection()
    {
        return sections.Count < 2;
    }

    void AddNewSection()
    {
        GameObject newSection;
        if (sections.Count>0)
        {
            Vector3 lastPosition = sections.Last.Value.transform.position;
            float x = 0;
            if(sections.Count > 1)
            {
                x = Random.Range(x - platformGap / 3, x + platformGap / 3);
            }
            newSection = Instantiate(sectionPrefab, new Vector3(x, 0, lastPosition.z + sectionGap), Quaternion.identity);
        } else
        {
            newSection = Instantiate(sectionPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }

        sections.AddLast(newSection);
    }
}
