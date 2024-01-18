using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{



    public bool isActiveWeapon;
    public int weaponDamage;


    //public Camera playerCamera;
    public bool isShooting, readyToShoot;

    bool allowReset = true;

    public float shootingdelay = 2f;
    public int bulletPerBurst = 2;
    public int burstBulletsLeft;
    public float spreadIntensity;
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletVelocity = 30;
    public float bulletPrefabLifeTime = 3f;
    public GameObject muzzleEffect;
    internal Animator animator;

    public float reloadTime;
    public int magazineSize, bulletLeft;
    public bool isReloading;

    public Vector3 spawnPosition;
    public Vector3 spawnRotation;



    public enum WeaponModel
    {
        Desert,
        M16,
        AK,
        pistol4

    }
    public WeaponModel thisWeaponmodel;
    public enum shootingMode{
        
        Single,
        Burst,
        Auto

    }
    public shootingMode currentShootingMode;
    private void Awake()
    {
        readyToShoot = true;
        burstBulletsLeft = bulletPerBurst;
        animator = GetComponent<Animator>();

        bulletLeft = magazineSize;

        
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActiveWeapon)
        {


            //foreach(Transform child in transform)
            //{
            //    child.gameObject.layer = LayerMask.NameToLayer("WeaponRender");
            //}
            GetComponent<Outline>().enabled = false;
            //if (Input.GetKeyDown(KeyCode.Mouse0))
            //{
            //    FireWeapon();
            //}
            if (bulletLeft == 0 && isShooting)
            {
                SoundManager.Instance.emptyMagazineSoundDesert.Play();

                //SoundManager.Instance.PlayEmptySound(thisWeaponmodel);


            }
            if (bulletLeft == 0)
            {
                currentShootingMode = shootingMode.Single;
            }
            else if (bulletLeft >= 0 && thisWeaponmodel == WeaponModel.M16)
            {
                currentShootingMode = shootingMode.Auto;


            }





            if (currentShootingMode == shootingMode.Auto)
            {
                isShooting = Input.GetKey(KeyCode.Mouse0);
            }
            else if (currentShootingMode == shootingMode.Burst ||
                currentShootingMode == shootingMode.Single)
            {
                isShooting = Input.GetKeyDown(KeyCode.Mouse0);
            }


            if (Input.GetKeyDown(KeyCode.R) && bulletLeft < magazineSize && isReloading == false)
            {
                Reload();
            }
            //if(readyToShoot && isShooting==false && isReloading==false && bulletLeft<=0) {
            //    //Reload();
            //}
            if (readyToShoot && isShooting && bulletLeft > 0 && !isReloading)
            {
                burstBulletsLeft = bulletPerBurst;

                FireWeapon();

            }
            if (AmmoManager.Instance.ammoDisplay != null)
            {
                AmmoManager.Instance.ammoDisplay.text = $"{bulletLeft / bulletPerBurst}/{magazineSize / bulletPerBurst}";

            } 
        }
        //else
        //{
        //    foreach (Transform child in transform)
        //    {
        //        child.gameObject.layer = LayerMask.NameToLayer("Default");
        //    }
        //}
    }
    private void FireWeapon()
    {
        bulletLeft--;
        muzzleEffect.GetComponent<ParticleSystem>().Play();
        animator.SetTrigger("RECOIL");
        animator.SetTrigger("M16_Rotate");



        //SoundManager.Instance.shootingSound.Play();
        SoundManager.Instance.PlayShootingSound(thisWeaponmodel);
        readyToShoot =false;
        Vector3 shootingDirection=CalculateDirectionAndSpread().normalized;
        GameObject bullet=Instantiate(bulletPrefab,bulletSpawn.position,Quaternion.identity);

       

        Bullet bul = bullet.GetComponent<Bullet>();
        bul.bulletDamage = weaponDamage;



        bullet.transform.forward= shootingDirection;
        bullet.GetComponent<Rigidbody>().AddForce(shootingDirection * bulletVelocity,ForceMode.Impulse);
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));
        if (allowReset)
        {
            Invoke("ResetShoot", shootingdelay);
            allowReset = false;

        }
        if (currentShootingMode == shootingMode.Burst && burstBulletsLeft > 1)
        {
            burstBulletsLeft--;
            Invoke("FireWeapon", shootingdelay);

        }

        
    }
    private void Reload()
    {
      

        //SoundManager.Instance.soundReload.Play();
        SoundManager.Instance.PlayReloadSound(thisWeaponmodel);
        isReloading = true;
        Invoke("ReloadCompleted", reloadTime);


  

    }
    private void ReloadCompleted()
    {
     

        bulletLeft = magazineSize;
        isReloading = false;
        // Reload işlemi tamamlandığında, tekrar ateş etmeye izin verilir
        readyToShoot = true;
        allowReset = true;
    }
    private void ResetShoot()
    {
        readyToShoot = true;
        allowReset = true;
    }
    public Vector3 CalculateDirectionAndSpread()
    {
        Ray ray=Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;
        Vector3 targetPoint;

        if(Physics.Raycast(ray,out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(110);
        }
        Vector3 direction = targetPoint - bulletSpawn.position;
        float x=UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);
        float y = UnityEngine.Random.Range(-spreadIntensity, spreadIntensity);
        return direction + new Vector3(x,y,0);


    }
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
