using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private Bullet _bulletPrefab;
    private float _lastShotTime = 0.0f;

    private Queue<Bullet> _bulletPool = new Queue<Bullet>();

    public Bullet GetBullet()
    {
        Bullet bullet = null;
        if (_bulletPool.Count > 0)
        {
            bullet = _bulletPool.Dequeue();
            bullet.gameObject.SetActive(true);
        }
        else
        {
            bullet = Instantiate(_bulletPrefab);
            bullet.Setup(this);
        }
        return bullet;
    }

    public void ReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        _bulletPool.Enqueue(bullet);
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if (CanShoot())
            {
                Bullet b = GetBullet();
                b.transform.position = _spawnPoint.position;
                b.Shoot(_spawnPoint.forward);
            }
        }
    }

    private bool CanShoot()
    { 
        if(Time.time - _lastShotTime > _fireRate)
        {
            _lastShotTime = Time.time;
            return true;
        }
        return false;
    }
}
