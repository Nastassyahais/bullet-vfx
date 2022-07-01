using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectiveMove : MonoBehaviour
{
    public float Speed;
    public float FireRate;
    public GameObject muzzlePrefab;
    public GameObject hitPrefab;

    void Start()
    {
        if(muzzlePrefab != null)
        {
            var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
        }
    }

    private void Update()
    {
        transform.position += transform.forward * (Speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision co)
    {
        Speed = 0;
        ContactPoint contact = co.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if (hitPrefab != null)
        {
            var hitVFX = Instantiate(hitPrefab, pos, rot);
        }

        Destroy(gameObject);
    }
}
