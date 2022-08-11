using DG.Tweening;
using UnityEngine;

public class TowerShoot : TowerShootTemplate
{
    [SerializeField] private GameObject _direction;
    [SerializeField] private CellView _cellView;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletParent;
    public int ShootsNumber { get; set; }
    public float BulletTime { get; set; } = 1f;
    public bool IsShooting { get; set; } = false;
    
    private void CreateBullet(TowerView view, TowerModel tower, Vector3 enemyTransform)
    {
        GameObject newBullet = Instantiate(_bulletPrefab);
        newBullet.transform.parent = _bulletParent.transform;
        newBullet.transform.localPosition = _bulletPrefab.transform.position;
        newBullet.transform.localScale = _bulletPrefab.transform.localScale;
        BulletView bulletView = newBullet.GetComponent<BulletView>();
        bulletView.ShootBullet(view, tower, enemyTransform);
    }
    
    protected override void LaunchShooting()
    {
        _cellView.BlockCell();
        ShootsNumber += 1;
    }

    protected override void TurnTower(TowerView view, TowerModel tower, Vector3 enemyTransform)
    {
        _direction.transform.DOLookAt(enemyTransform, tower.ShootDelay - BulletTime)
            .OnComplete(() => CreateBullet(view, tower, enemyTransform));
    }

    public void RenewData()
    {
        ShootsNumber = 0;
        IsShooting = false;
        _cellView.UnblockCell();
    }
}
