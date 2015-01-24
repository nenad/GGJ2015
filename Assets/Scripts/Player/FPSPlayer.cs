using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSPlayer : MonoBehaviour
{

    // Use this for initialization
    static FPSPlayer player;
    static Image handImage1;
    static Image handImage2;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<FPSPlayer>();
        handImage1 = GameObject.Find("UI/Hand1").GetComponent<Image>();
        handImage2 = GameObject.Find("UI/Hand2").GetComponent<Image>();

        //Some meth
        var w = Screen.width / 2;
        var h = Screen.height / 2;

        handImage1.transform.position = new Vector3(w / 2, h);
        handImage2.transform.position = new Vector3(w / 2 * 3, h);

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.DrawLine(transform.position, transform.forward * 4f, Color.red, 0.2f);
        
        var hits = Physics.RaycastAll(transform.position, transform.forward, 2f);
        Interactables interactable = null;
        bool hasInteractable = false;

        foreach (var hit in hits)
        {
            interactable = hit.collider.GetComponent<Interactables>();
            if (interactable)
            {
                hasInteractable = true;
                break;
            }
        }

        if (hasInteractable)
        {
            handImage1.enabled = true;
            handImage2.enabled = true;
            if (Input.GetButtonDown("Fire2"))
            {
                interactable.Use();
            }
        }
        else
        {
            handImage1.enabled = false;
            handImage2.enabled = false;
        }

    }
}
