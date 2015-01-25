using UnityEngine;
using System.Collections;

public class RaggedMate : MonoBehaviour
{

    void GetRekt(Transform t)
    {
        t.gameObject.AddComponent<BoxCollider>();
        t.gameObject.AddComponent<Rigidbody>().mass = 0.1f;

        if (t.childCount > 0)
        {
            for (int i = 0; i < t.childCount; i++)
            {
                GetRekt(t.GetChild(i));
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        animation.Stop();
        GetRekt(transform);
        Destroy(gameObject, 10f);
    }
}
