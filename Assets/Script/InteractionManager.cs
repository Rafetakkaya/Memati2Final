using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionManager : MonoBehaviour
{
    public static InteractionManager Instance { get; set; }

    public Weapon hoveredWeapon =null;  
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;

        }
    }
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            GameObject objectHitByRaycast=hit.transform.gameObject;

            if (objectHitByRaycast.GetComponent<Weapon>() && objectHitByRaycast.GetComponent<Weapon>().isActiveWeapon == false)
                //&& objectHitByRaycast.GetComponent<Weapon>().isActiveWeapon == false
            {
                //print(objectHitByRaycast.GetComponent<Weapon>().isActiveWeapon);

                hoveredWeapon = objectHitByRaycast.gameObject.GetComponent<Weapon>(); 
                hoveredWeapon.GetComponent<Outline>().enabled = true;
            
                if (Input.GetKeyDown(KeyCode.F))
                {
                    WeaponManager.Instance.PickupWeapon(objectHitByRaycast.gameObject);
                    hoveredWeapon.GetComponent<Outline>().enabled = false;
                }
 

            }
            else
            {
                if (hoveredWeapon)
                {
                    hoveredWeapon.GetComponent<Outline>().enabled=false;
                }
            }
        }
    }



}
