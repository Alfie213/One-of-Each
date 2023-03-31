using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _direction;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        //_rb.MovePosition(this.transform.position + new Vector3(_direction * _speed * Time.fixedDeltaTime, 0, 0));
        _rb.velocity = new Vector2(_direction * _speed, _rb.velocity.y);
    }
}
