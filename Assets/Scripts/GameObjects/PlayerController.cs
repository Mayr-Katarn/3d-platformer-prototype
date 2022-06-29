using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private GameObject _model;
    private Rigidbody _body;
    private Animator _animator;

    void Start()
    {
        //_body = _model.GetComponent<Rigidbody>();
        _animator = _model.GetComponent<Animator>();
    }

    void Update()
    {
        InputCatcher();
    }

    private void InputCatcher()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        float aimHeight = Input.GetAxis("Vertical");
        float atack = Input.GetAxis("Fire1");

        transform.Translate(_moveSpeed * moveDirection * Time.deltaTime * Vector3.right);

        //Debug.Log(aimHeight);
        //UpdateMovementAnimation(1);
        UpdateMovementAnimation(moveDirection);
        UpdateAimAnimation(aimHeight);
        Fire(atack);
        SetLookSide(moveDirection);
    }

    private void SetLookSide(float direction)
    {
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        float z = transform.localScale.z;

        if (direction > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(x), y, z);
        }
        else if (direction < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(x * -1, y, z);
        }
    }

    private void UpdateMovementAnimation(float moveDirection)
    {
        _animator.SetFloat("moveSpeed", Mathf.Abs(moveDirection));
    }

    private void UpdateAimAnimation(float aimHeight)
    {
        _animator.SetFloat("aimHeight", 1 + aimHeight);
    }

    private void Fire(float atack)
    {
        bool isAtacking = atack == 1;
        _animator.SetBool("isAtacking", isAtacking);
        _animator.SetLayerWeight(_animator.GetLayerIndex("Aiming"), atack);
    }
}
