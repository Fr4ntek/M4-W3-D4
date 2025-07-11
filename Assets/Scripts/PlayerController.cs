using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 10f;
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

  
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //movimento tramite velocity
        //Vector3 move = new Vector3(h, 0f, v) * _speed;
        //_rb.velocity = new Vector3(move.x, _rb.velocity.y, move.z);

        // movimento tramite MovePosition
        Vector3 direction = new Vector3(h, 0, v).normalized;
        if(direction.sqrMagnitude > 0.001f)
        {
            // rotazione fluida
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime);
        }
        Vector3 move = direction * _speed * Time.fixedDeltaTime;
        if(move != Vector3.zero) ;
        _rb.MovePosition(_rb.position + move);
    }
}
