using UnityEngine;
using System.Collections;

public class WeaponSwitcher : MonoBehaviour {

    public Transform[] weapons;
    public int currentWeapon = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("SwitchWeaponUp"))
        {
            ++currentWeapon;
            currentWeapon %= weapons.Length;
            SwitchWeapon(currentWeapon);
        }
        else if(Input.GetButtonDown("SwitchWeaponDown"))
        {
            --currentWeapon;
            if (currentWeapon < 0)
            {
                currentWeapon += weapons.Length;
            }
            SwitchWeapon(currentWeapon);
        }
	}

    void SwitchWeapon(int idx)
    {
        for (int i = 0; i < weapons.Length; ++i)
        {
            if (i == idx)
            {
                weapons[i].gameObject.SetActive(true);
                weapons[i].SendMessage("Reset", SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }
}
