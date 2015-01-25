using UnityEngine;
using System.Collections;

public class TimerTrigger : MonoBehaviour {

    EventCoordinator coord;
    bool wasStarted = false;

    void OnTriggerEnter()
    {
        if (EventGone.isDone && !wasStarted)
        {
            wasStarted = true;
            coord = GameObject.FindObjectOfType<EventCoordinator>();
            coord.StartJurassicPark();
            var door = GameObject.Find("Doors/MainDoor").GetComponent<Door>();
            if (door.isOpen)
            {
                door.Use();
            }
            door.isLocked = true;
        }
    }
}
