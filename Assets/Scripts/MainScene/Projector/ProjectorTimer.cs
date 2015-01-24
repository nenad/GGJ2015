using UnityEngine;
using System.Collections;

public class ProjectorTimer : MonoBehaviour
{

    TextMesh mesh;
    MeshRenderer meshRenderer;
    public float timerSeconds;
    public bool isRunning = true;

    int minutes;
    int seconds;


    void Start()
    {
        mesh = GetComponent<TextMesh>();
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(IEBlink());
    }

    public void SetTime(int hour, int minutes)
    {
        string hStr = hour.ToString();
        string mStr = minutes.ToString();
        if (hour < 10)
        {
            hStr = "0" + hour;
        }
        if (minutes < 10)
        {
            mStr = "0" + minutes;
        }
        mesh.text = hStr + ":" + mStr;
    }

    void Update()
    {
        minutes = (int)(timerSeconds / 60);
        seconds = (int)(timerSeconds - minutes * 60);
        if (isRunning)
        {
            timerSeconds -= Time.deltaTime;
        }

    }

    public void StartTimer()
    {
        isRunning = true;
    }
    public void StopTimer()
    {
        isRunning = false;
    }

    IEnumerator IEBlink()
    {
        while (true)
        {

            if (!isRunning)
            {
                yield return null;
                continue;
            }

            //var date = System.DateTime.Now;
            SetTime(minutes, seconds);

            yield return new WaitForSeconds(.5f);
            meshRenderer.enabled = false;


            if (timerSeconds < 1f)
            {
                meshRenderer.enabled = true;
                break;
            }

            yield return new WaitForSeconds(.5f);
            meshRenderer.enabled = true;
        }

    }

}
