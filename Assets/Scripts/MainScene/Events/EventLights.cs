using UnityEngine;
using System.Collections;

public class EventLights : MonoBehaviour {

    Light[] lights;
    public float seconds;
    public Color flashingColor;
    bool inProgress = false;
	// Use this for initialization
	void Start () {
        lights = GameObject.FindObjectsOfType<Light>();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TrippyLights();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SwitchLights(true);
        }
    }


    public void TrippyLights()
    {
        if (!inProgress)
        {
            StartCoroutine(IETrippyLights());
            ColorLights(flashingColor);
        }
        inProgress = true;
    }

    IEnumerator IETrippyLights()
    {
        float toChop = seconds;

        while(toChop > 0)
        {
            SwitchLights();
            var random = Random.Range(0.1f, 0.3f);
            yield return new WaitForSeconds(random);
            toChop -= random;
        }
        yield return new WaitForSeconds(1f);
        SwitchLights(true);
        ColorLights(Color.white);
        inProgress = false;
    }

    public void ColorLights(Color color)
    {
        foreach (Light l in lights)
        {
            l.color = color;
        }
    }

    public void SwitchLights(bool status)
    {

        foreach (Light l in lights)
        {
            l.enabled = status;
        }
        inProgress = !status;
    }

    public void SwitchLights()
    {
        foreach (Light l in lights)
        {
            l.enabled = !l.enabled;
        }
    }

}
