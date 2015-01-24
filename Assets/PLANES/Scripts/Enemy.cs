using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Bullet bullet;
    public float speed;
    public int Health;
    private Score score;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Shoot", 0, Random.RandomRange(1f, 2f));
        score = GameObject.FindObjectOfType<Score>();
        Destroy(gameObject, 10f);
	}

    void Shoot()
    {
            var b = Instantiate(bullet, transform.position + new Vector3(0, -1.3f), Quaternion.identity) as Bullet;
            b.shooter = gameObject;
            b.direction = Vector3.down;
            b.origin = transform.position;
    }

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (Health <= 0)
        {
            Die();
        }
	}

    private void Die()
    {
        score.Add(10);
        Destroy(gameObject);
    }
}
