using UnityEngine;
using System.Collections;

public class EventGone : MonoBehaviour
{
    public static bool isDone = false;
    Person[] people;

    void Start()
    {
        people = GameObject.FindObjectsOfType<Person>();
    }

    public void TogglePeople(bool status)
    {
        foreach (Person p in people)
        {
            Destroy(p.gameObject);
        }
        isDone = true;
    }


}
