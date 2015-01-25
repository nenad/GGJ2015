using UnityEngine;
using System.Collections;

public class EventWC : MonoBehaviour {

    DiveFPSController dive;
    Transform diveCamera;
    CharacterController character;
    Transform wcpoint;
    public AudioClip pee;
    bool hasEntered = false;
    EventGone gone;
    public ParticleSystem pissParticle;
    public GameObject timer;
    public Transform pissPosition;

    void Start()
    {
        dive = GameObject.FindObjectOfType<DiveFPSController>();
        character = dive.gameObject.GetComponent<CharacterController>();
        diveCamera = dive.transform.FindChild("Dive_Camera");
        wcpoint = GameObject.Find("WC/WCPoint").transform;
        gone = GameObject.FindObjectOfType<EventGone>();
        pissParticle.enableEmission = false;
    }

    void OnTriggerEnter()
    {
        if (!hasEntered)
        {
            
            pissParticle.enableEmission = true;
            hasEntered = true;
            diveCamera.LookAt(wcpoint.position);
            dive.enabled = false;
            character.transform.position = pissPosition.position;
            StartCoroutine(IEPee());
            gone.TogglePeople(false);
            timer.SetActive(true);
        }
    }

    IEnumerator IEPee() {

        AudioSource.PlayClipAtPoint(pee, transform.position);
        yield return new WaitForSeconds(10);
        Destroy(pissParticle.gameObject);
        dive.enabled = true;
    }
}
