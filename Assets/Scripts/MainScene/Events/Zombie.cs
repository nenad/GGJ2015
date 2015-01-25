using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    static DiveFPSController dive;
    public float speed;
    public AudioClip[] sounds;

    void Start()
    {
        dive = GameObject.FindObjectOfType<DiveFPSController>();
        StartCoroutine(IERandomSounds());
    }

    private IEnumerator IERandomSounds()
    {
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        while (true)
        {
            AudioSource.PlayClipAtPoint(sounds[Random.Range(0, sounds.Length)], transform.position);
            yield return new WaitForSeconds(Random.Range(4f, 9f));
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, dive.transform.position, Time.deltaTime * speed);
        Vector3 targetPostition = new Vector3(dive.transform.position.x,
                                       this.transform.position.y,
                                       dive.transform.position.z);
        this.transform.LookAt(targetPostition);
        this.transform.rotation = Quaternion.Euler(270, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

    }
}
