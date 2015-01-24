using UnityEngine;
using System.Collections;

public class EventLights : MonoBehaviour {

    Light[] lights;
    public int startRandom;
    public int endRandom;
    public Color flashingColor;
    bool inProgress = false;
	// Use this for initialization
	void Start () {
        lights = GameObject.FindObjectsOfType<Light>();
        TrippyLights();
	}


    void TrippyLights()
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
        int times = Random.Range(startRandom, endRandom);

        for (int i = 0; i < times; i++)
        {
            SwitchLights();
            yield return new WaitForSeconds(Random.Range(0.1f, 0.6f));
        }
        yield return new WaitForSeconds(1f);
        SwitchLights(true);
        ColorLights(Color.white);
        inProgress = false;
    }

    void ColorLights(Color color)
    {
        foreach (Light l in lights)
        {
            l.color = color;
        }
    }

    void SwitchLights(bool status)
    {

        foreach (Light l in lights)
        {
            l.enabled = status;
        }
    }

    void SwitchLights()
    {
        foreach (Light l in lights)
        {
            l.enabled = !l.enabled;
        }
    }

}
