using UnityEngine;
using System.Collections;

public class EnemyConductor : MonoBehaviour {
    public GameObject DeathObj;
    public AudioClip SplatterSound;
    public float health = 100f;

	// Use this for initialization
	void Start () {
        audio.time = Random.Range(0, audio.clip.length);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ApplyDamage(float f)
    {
        health -= f;
        if (health < 0)
        {
            Die();
        }
    }

    void Die()
    {
        AudioManager manager = FindObjectOfType<AudioManager>();
        manager.Play(SplatterSound, transform.position);
        gameObject.SetActive(false);
        GameObject instance = (GameObject)Instantiate(DeathObj);
        instance.transform.position = transform.position;
        Rigidbody[] rigidbodies = instance.GetComponentsInChildren<Rigidbody>();
        LevelState.KontrolaLeft -= 1;
        
        for(int i=0; i<rigidbodies.Length; ++i){
            rigidbodies[i].AddExplosionForce(300f, transform.position, 1f);
        }
    }
}
