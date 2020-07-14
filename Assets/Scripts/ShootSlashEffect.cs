using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSlashEffect : MonoBehaviour
{
    public static ShootSlashEffect shootSlash;
    public Transform firepoint;
    public GameObject slashPrefab;

    private void Awake()
    {
        if(null == shootSlash)
        {
            shootSlash = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void Shoot()
    {
        Instantiate(slashPrefab, firepoint.position, slashPrefab.transform.rotation);
    }
}
