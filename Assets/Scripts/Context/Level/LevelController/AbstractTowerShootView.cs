using DG.Tweening;
using UnityEngine;

public abstract class AbstractTowerShootView : BaseView, ITowerShoot
{
    [SerializeField] private GameObject _direction;
    [SerializeField] private CellView _cellView;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletParent;
    public float BulletTime { get; set; } = 1f;
    public bool IsShooting { get; set; }
    
    private void CreateBullet(TowerView view, TowerModel tower, Vector3 enemyTransform)
    {
        GameObject newBullet = Instantiate(_bulletPrefab);
        
        if (newBullet.transform != null)
        {
            newBullet.transform.parent = _bulletParent.transform;
            newBullet.transform.localPosition = _bulletPrefab.transform.position;
            newBullet.transform.localScale = _bulletPrefab.transform.localScale;
        }
        BulletView bulletView = newBullet.GetComponent<BulletView>();
        bulletView.ShootBullet(view, tower, enemyTransform);
    }

    public void LaunchShooting()
    {
        _cellView.BlockCell();
    }

    public void TurnTower(TowerView view, TowerModel tower, Vector3 enemyTransform)
    {
        _direction.transform.DOLookAt(enemyTransform, tower.ShootDelay - BulletTime)
            .OnComplete(() => CreateBullet(view, tower, enemyTransform));
    }

    public void RenewData()
    {
        _direction.transform.DOKill();
        IsShooting = false;
        _cellView.UnblockCell();
        _direction.transform.DORotate(Vector3.zero, 1f);
    }
}
