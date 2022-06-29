using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _dumping = 1.5f;
    [SerializeField] private Vector2 _offset = new(2f, 1f);
    [SerializeField] private Transform _player;

    private Camera _camera;
    private bool _isFollow;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        CameraMove();
    }

    private void CameraMove()
    {
        transform.position = new Vector3(_player.position.x + _offset.x, _player.position.y + _offset.y, transform.position.z);
    }
}
