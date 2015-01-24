using UnityEngine;
using System.Collections;

public class EventGone : MonoBehaviour
{


    Person[] people;

    void Start()
    {
        people = GameObject.FindObjectsOfType<Person>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            TogglePeople(true);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            TogglePeople(false);
        }
    }

    public void TogglePeople(bool status)
    {
        foreach (Person p in people)
        {
            p.gameObject.SetActive(status);
        }
    }


}
