using UnityEngine;
using System.Collections;

public class Chainsaw : MonoBehaviour {
    int soundState = 0;
    float timeout;

    public AudioClip startSound;
    public AudioClip runningSound;
    public AudioClip endSound;

    public ParticleSystem particles;

    public Animator animator;
    public delegate void AudioCallback();

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        animator.speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            if (soundState == 0)
            {
                particles.enableEmission = false;
                animator.speed = 0.6f;
                soundState = 1;
                audio.PlayOneShot(startSound);
                timeout = startSound.length;
            }
            else if (soundState == 1 && timeout <= 0 || soundState == 3)
            {
                animator.speed = 1f;
                audio.clip = runningSound;
                audio.loop = true;
                audio.Play();
                soundState = 2;
            }
        }
        else
        {
            if (soundState == 2)
            {
                particles.enableEmission = false;
                animator.speed = 0.6f;
                audio.Stop();
                audio.PlayOneShot(endSound);
                timeout = endSound.length;
                soundState = 3;
            }
            if (soundState == 3 && timeout <= 0)
            {
                animator.speed = 0;
                audio.Stop();
                soundState = 0;
            }
        }
        timeout -= Time.deltaTime;
	}

    void OnTriggerStay(Collider c)
    {
        if (soundState == 2)
        {
            c.rigidbody.AddForce(Camera.main.transform.forward * 30f);
            particles.enableEmission = true;
            c.SendMessage("ApplyDamage", 4f, SendMessageOptions.DontRequireReceiver);
        }
    }
    void OnTriggerExit(Collider c)
    {
        particles.enableEmission = false;
    }

    void Reset()
    {
        animator.speed = 0;
        soundState = 0;
        audio.Stop();
    }
}
