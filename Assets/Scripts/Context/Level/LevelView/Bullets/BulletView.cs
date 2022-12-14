using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : BaseView
{
    public int BulletDamage { get; set; }
    public event Action<int, EnemyView> OnBulletHit = delegate { };
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            OnBulletHit?.Invoke(BulletDamage, other.gameObject.GetComponent<EnemyView>());
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("ShootRadius"))
        {
            Destroy(gameObject);
        }
    }
}
