using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public float destroyTime = 1f;
    public Vector3 offset = new Vector3(0, 0.5f, 0);
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition += offset;
        Destroy(gameObject, destroyTime);
    }
}
