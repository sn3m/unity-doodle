using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform player;
    public GameObject sectionPrefab;
    public int sectionGap = 10;
    public int numSections = 10;
    public float speed = 4.4f;

    private LinkedList<GameObject> sections;
    // Start is called before the first frame update
    void Start()
    {
        sections = new LinkedList<GameObject>();
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

    void AddNewSection()
    {
        GameObject newSection;
        if (sections.Count>0)
        {
            float lastZ = sections.Last.Value.transform.position.z;
            newSection = Instantiate(sectionPrefab, new Vector3(0, 0, lastZ + sectionGap), Quaternion.identity);
        } else
        {
            newSection = Instantiate(sectionPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }

        sections.AddLast(newSection);
    }
}
