using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {

    public bool isWalking;
    public float speedRotation;
    public float speed;

    void Start()
    {
        if (animation)
        {
            animation["MoveAnimation"].wrapMode = WrapMode.Loop;
            animation.Play();
        }
    }

}
