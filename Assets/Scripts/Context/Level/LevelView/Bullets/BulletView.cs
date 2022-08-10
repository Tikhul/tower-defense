using System;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

public class BulletView : BaseView
{
    public int BulletDamage { get; set; }
    public event Action<int, EnemyView> OnBulletHit = delegate { };
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log("OnBulletHit");
            OnBulletHit?.Invoke(BulletDamage, other.gameObject.GetComponent<EnemyView>());
        //    DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        transform.DOKill();
        Destroy(gameObject);
    }
}
