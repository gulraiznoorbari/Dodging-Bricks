using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float bottomBound = -14f;

    private void Update()
    {
        if (transform.position.y <= bottomBound)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
