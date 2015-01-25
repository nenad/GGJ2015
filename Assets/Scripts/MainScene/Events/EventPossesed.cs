using UnityEngine;
using System.Collections;

public class EventPossesed : MonoBehaviour {
    public AudioClip neckcrack;
    void Start()
    {
        Peasant[] peasants = GameObject.FindObjectsOfType<Peasant>();
        foreach (Peasant p in peasants)
        {
            AudioSource.PlayClipAtPoint(neckcrack, p.transform.position);
        }
    }


}
