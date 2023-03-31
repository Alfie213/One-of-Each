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
        //if (Input.GetKey(KeyCode.A))
        //{
        //    Debug.Log("Moving left");
        //    this.transform.position = new Vector3(this.transform.position.x - _speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    Debug.Log("Moving right");
        //    this.transform.position = new Vector3(this.transform.position.x + _speed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
        //}
    }

    private void FixedUpdate()
    {
        Debug.Log("Moving");
        _rb.MovePosition(this.transform.position + new Vector3(_direction * _speed, 0, 0));
    }
}
