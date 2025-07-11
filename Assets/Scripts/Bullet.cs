using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private int _damage = 20;
    [SerializeField] private int _lifeTime = 3;

    private Rigidbody _rb;
    private PlayerShootController _shootController;

    public void Setup(PlayerShootController shootController)
    {
        _shootController = shootController;
    }
    
    public void ReturnToPool()
    {
        if (!gameObject.activeInHierarchy) return; //non serve, ma era per capire se invoke veniva chiamata anche su oggetti disabilitati

        _shootController.ReleaseBullet(this);
    }
   
    public void Shoot(Vector3 direction)
    {
       _rb = GetComponent<Rigidbody>();
       _rb.velocity = direction * _speed;
        CancelInvoke(); // per sicurezza, perchè potrebbe chiamare l'invoke del bullet precedente
        Invoke("ReturnToPool", _lifeTime);
       //Destroy(gameObject, _lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            collision.collider.gameObject.GetComponent<LifeController>().TakeDamage(_damage);
        }
        ReturnToPool();
    }
}
