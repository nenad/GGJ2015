using UnityEngine;
using System.Collections;

public class EventCoordinator : MonoBehaviour
{

    public EventZombies zombies;
    public EventConductors conductors;
    public EventPossesed possesed;
    public EventRekt rekt;
    public EventLights trippy;
    public GameObject plane;
    public AudioClip scaryMusic;

    public bool IsInPanicMode;

    ProjectorTimer timer;
    Renderer renderer;

    private float current = 0;
    private float max = 1;

    // Use this for initialization
    void Start()
    {
        //renderer = plane.renderer;
    }

    public void StartJurassicPark()
    {
        StartCoroutine(IEStartEvents());
    }

    private IEnumerator IEStartEvents()
    {
        timer = GameObject.FindObjectOfType<ProjectorTimer>();
        timer.StartTimer();

        yield return new WaitForSeconds(10);
        PlayIntenseMusic();
        yield return new WaitForSeconds(10);
        yield return null;
        StartCoroutine(FadeOutIn());
        yield return new WaitForSeconds(1f);
        PossesedPeople();
        yield return new WaitForSeconds(10);
        yield return null;
        ClearPossesedPeople();

        SetNormalAtmosphere();

        yield return new WaitForSeconds(6);
        yield return null;
        StartCoroutine(FadeOutIn());
        yield return new WaitForSeconds(1f);
        RagdolPeople();
        yield return new WaitForSeconds(10);
        yield return null;
        ClearRagdolPeople();

        SetNormalAtmosphere();

        yield return new WaitForSeconds(6);
        yield return null;
        StartCoroutine(FadeOutIn());
        yield return new WaitForSeconds(1f);
        SetUpConductors();
        yield return new WaitForSeconds(15);
        yield return null;
        ClearConductors();

        SetNormalAtmosphere();

        yield return new WaitForSeconds(6);
        yield return null;
        StartCoroutine(FadeOutIn());
        yield return new WaitForSeconds(1f);
        SetUpZombies();
        trippy.seconds = 15;
        trippy.TrippyLights();
        yield return new WaitForSeconds(21);
        yield return null;
        ClearZombies();
        SetNormalAtmosphere();

        yield return new WaitForSeconds(6);
        yield return null;
        InFrontOfTimer();
        yield return new WaitForSeconds(10);
        yield return null;
        ShowBluescreen();
    }

    private IEnumerator FadeOutIn()
    {
        while (plane.renderer.material.color.a < 1)
        {
            plane.renderer.material.color = new Color(0, 0, 0, plane.renderer.material.color.a + Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        while (plane.renderer.material.color.a > 0)
        {
            plane.renderer.material.color = new Color(0, 0, 0, plane.renderer.material.color.a - Time.deltaTime);
            yield return null;
        }
    }

    #region 1
    private void ClearPossesedPeople()
    {
        possesed.gameObject.SetActive(false);
    }

    void PossesedPeople()
    {
        possesed.gameObject.SetActive(true);
        IsInPanicMode = true;
    }
    #endregion

    #region 2

    private void ClearRagdolPeople()
    {
        rekt.gameObject.SetActive(false);
    }

    private void RagdolPeople()
    {
        rekt.gameObject.SetActive(true);
    }

    #endregion

    #region 3

    private void ClearConductors()
    {
        conductors.gameObject.SetActive(false);
    }

    private void SetUpConductors()
    {
        conductors.gameObject.SetActive(true);
    }

    #endregion

    #region 4

    private void ClearZombies()
    {
        zombies.gameObject.SetActive(false);
    }

    private void SetUpZombies()
    {
        zombies.gameObject.SetActive(true);
    }

    #endregion

    void Update()
    {
        /*
        if (IsInPanicMode)
        {
            renderer.material.color = new Color(1, 1, 1, Mathf.Max(renderer.material.color.a - Time.deltaTime, 0.3f));
            trippy.TrippyLights();
        }
        else
        {
            renderer.material.color = new Color(1, 1, 1, Mathf.Min(renderer.material.color.a + Time.deltaTime, 1f));
            trippy.SwitchLights(true);
        }
         */


    }

    void PlayIntenseMusic()
    {
        AudioSource.PlayClipAtPoint(scaryMusic, Camera.main.transform.position);
    }


    private void InFrontOfTimer()
    {
        var dive = GameObject.FindObjectOfType<DiveFPSController>();
        var opendive = GameObject.FindObjectOfType<OpenDiveSensor>();

        var inFrontOf = GameObject.Find("Events/FrontOfCamera").transform;
        var player = GameObject.FindObjectOfType<DiveFPSController>().transform;
        player.position = inFrontOf.position;
        player.rotation = inFrontOf.rotation;

        dive.enabled = false;
        //opendive.enabled = false;
    }

    private void ShowBluescreen()
    {
        AutoLevelState.switchTime = 3f;
        AutoLevelState.LevelName = "Massacre";
        Application.LoadLevel("BSOD");
    }

    private void SetNormalAtmosphere()
    {
        IsInPanicMode = false;
    }



}
