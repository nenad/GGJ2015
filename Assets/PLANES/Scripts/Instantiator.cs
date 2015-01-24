using UnityEngine;
using System.Collections;

public class Instantiator : MonoBehaviour
{

    public Enemy enemyClone;
    private PlanesGame parent;
    public Transform spawnPosition;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, Random.Range(1.5f, 2.5f));
        parent = GameObject.FindObjectOfType<PlanesGame>();
    }

    void SpawnEnemy()
    {
        var x = Random.Range(-Player.X_BOUNDARY, Player.X_BOUNDARY) + spawnPosition.position.x;
        var y = spawnPosition.position.y;
        var z = spawnPosition.position.z;

        var enemy = Instantiate(enemyClone, new Vector3(x, y, z), Quaternion.Euler(180, 0, 0)) as Enemy;
        enemy.transform.parent = parent.transform;


    }

    // Update is called once per frame
    void Update()
    {

    }
}
