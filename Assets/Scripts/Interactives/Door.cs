using UnityEngine;
using System.Collections;

public class Door : Interactables {

    bool isOpen = false;
    public float speed = .1f;

	// Use this for initialization
	void Start () {
	    
	}

    public override void Use()
    {
        //StartCoroutine(UseDoor());
        if (isOpen)
        {
            StartCoroutine(OpenDoor());
        }
        else
        {
            StartCoroutine(CloseDoor());
        }
        isOpen = !isOpen;
    }

    IEnumerator OpenDoor()
    {
        float degrees = 0;
        while (degrees < 90)
        {
            transform.Rotate(0, speed, 0);
            degrees += speed;
            yield return null;
        }
    }


    IEnumerator CloseDoor()
    {
        float degrees = 0;
        while (degrees < 90)
        {
            transform.Rotate(0, -speed, 0);
            degrees += speed;
            yield return null;
        }
    }

    IEnumerator RotateGameObject(float duration)
    {
        Debug.Log("Tapped to rotate");
        Vector3 angles = transform.eulerAngles;
        float startTime = Time.time;
        float startAngle = angles.y;
        float endAngle = startAngle + 90; // -45 for left turn
        if (!isOpen)
        {
            endAngle = startAngle - 90;
        }

        while (duration >= Time.time - startTime)
        {
            angles.y = Mathf.LerpAngle(startAngle, endAngle, (Time.time - startTime) / duration);
            transform.eulerAngles = angles;
            yield return null;
        }
        isOpen = !isOpen;
    }
}
