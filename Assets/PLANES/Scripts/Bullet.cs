using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public GameObject shooter;
    public Vector3 direction;
    public Vector3 origin;
    public float speed = 10;
    public Transform planetgame;

	// Use this for initialization
    void Start()
    {
        planetgame = GameObject.FindObjectOfType<PlanesGame>().transform;
        transform.parent = planetgame;
        Destroy(gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * Time.deltaTime * speed);
	}

    void OnCollisionEnter2D(Collision2D c)
    {

        var player = c.collider.gameObject.GetComponent<Player>();
        var enemy = c.collider.gameObject.GetComponent<Enemy>();

        if (player)
        {
            player.Health -= 10;
            Destroy(gameObject);
        }
        if (enemy)
        {
            if (shooter.GetComponent<Enemy>())
            {
                Physics2D.IgnoreCollision(enemy.collider2D, collider2D);
            }
            else
            {
                enemy.Health -= 10;
                Destroy(gameObject);
            }
        }


    }
}
