using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
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
        Vector3 move = new Vector3(h, 0, v).normalized * _speed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + move);
    }
}
