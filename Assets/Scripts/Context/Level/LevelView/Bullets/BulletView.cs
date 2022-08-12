using System;
using DG.Tweening;
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
            gameObject.SetActive(false);
        }
    }

    public void ShootBullet(TowerView towerView, TowerModel towerModel, Vector3 enemyTransform)
    {
        BulletDamage = towerModel.Damage;
        transform.DOLocalMoveZ(
                Vector3.Distance(transform.position, enemyTransform) * 100 + 10, 
                towerView.BulletTime)
            .OnComplete(() => Destroy(gameObject));
    }
}
