using UnityEngine;
using System.Collections;

public class Baseball : MonoBehaviour {
    private Animator animator;
    private Collider enemyCollider;
    private bool hasBonked = false;

    public AudioClip thudClip;
    public AudioClip whooshClip;
    public LayerMask layerMask;
    public ParticleSystem particles;
    AudioManager audioManager;

	// Use this for initialization
	void Start () {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("PrepareAttack");
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            animator.SetTrigger("Attack");
            audioManager.Play(whooshClip, transform.position);
        }

        if (hasBonked)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("BaseballSwing"))
            {
                hasBonked = false;
            }
        }
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.collider.gameObject.layer != LayerMask.NameToLayer("Peasants"))
        {
            return;
        }
        enemyCollider = c.collider;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("BaseballSwing") && !hasBonked)
        {
            audioManager.Play(thudClip, transform.position, 0.3f);
            Bonk();
        }
    }

    void OnTriggerExit(Collider c)
    {
        enemyCollider = null;
    }

    void Bonk()
    {
        if (enemyCollider != null)
        {
            particles.Play();
            Vector3 dir = Camera.main.transform.forward;
            dir += new Vector3(0, 1f, 0);
            enemyCollider.rigidbody.AddForce(dir * 200f);
            enemyCollider.SendMessage("ApplyDamage", 50f, SendMessageOptions.DontRequireReceiver);
        }
    }
}
