using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{
    public GameObject FirePoint;
    public List<GameObject> Vfx = new List<GameObject>();
    public RotateToMouse RotateToMouse;

    private GameObject _effectToSpawn;
    private float timeToFire = 0;

    private void Start()
    {
        _effectToSpawn = Vfx[0];
    }

    private void Update()
    {
        if(Input.GetMouseButton(0)&& Time.time >=timeToFire)
        {
            timeToFire = Time.time + 1 / _effectToSpawn.GetComponent<ProjectiveMove>().FireRate;
            Debug.Log("Fire");
            SpawnVfx();
        }
    }

    private void SpawnVfx()
    {
        GameObject vfx;

        if(FirePoint != null)
        {
            vfx = Instantiate(_effectToSpawn, FirePoint.transform.position, Quaternion.identity);
            var particles = vfx.GetComponentsInChildren<ParticleSystem>();

            vfx.transform.localRotation = RotateToMouse.GetQuar();

        

            foreach(var part in particles)
            {
                part.Play();
                Debug.Log($"{part.name} - {part.isPlaying}"); ;
            }
        }
        else
        {
            Debug.Log("No fire point");
        }
    }
}
