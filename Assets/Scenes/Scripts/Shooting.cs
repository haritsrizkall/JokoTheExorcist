using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootingPoint;
    public bool canShoot = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (!canShoot)
            return;

        GameObject si = Instantiate(bullet, shootingPoint);
        si.transform.parent = null;
    }
}
