using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Weapon;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; set; }



    public AudioSource ShootingChannel;

    public AudioClip M16Shot;
    public AudioClip DesertShot;
    public AudioClip psitol4Shoot;
    public AudioClip AKShoot;






    public AudioSource reloadingSoundM16;
    public AudioSource reloadingSoundDesert;


    public AudioSource emptyMagazineSoundDesert;

  







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





    public void PlayShootingSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Desert:
                ShootingChannel.PlayOneShot(DesertShot);
                break;
            case WeaponModel.M16:
                ShootingChannel.PlayOneShot(M16Shot);
                break;

            case WeaponModel.AK:
                ShootingChannel.PlayOneShot(AKShoot);
                break;
            case WeaponModel.pistol4:
                ShootingChannel.PlayOneShot(psitol4Shoot);
                break;





       



        }

    }
    public void PlayReloadSound(WeaponModel weapon)
    {
        switch (weapon)
        {
            case WeaponModel.Desert:
              reloadingSoundDesert.Play();
                break;
            case WeaponModel.pistol4:
                reloadingSoundDesert.Play();
                break;
            case WeaponModel.M16:
                reloadingSoundM16.Play();
                break;
            case WeaponModel.AK:
                reloadingSoundM16.Play();
                break;


        }

    }

    
}
