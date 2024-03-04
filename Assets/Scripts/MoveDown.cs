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

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.instance.AddLife(-1);
        Rigidbody barRb = gameObject.GetComponent<Rigidbody>();
        if (barRb != null)
        {
            barRb.AddForce(Vector3.up * 40, ForceMode.Impulse);
            Time.timeScale = 0.2f;
            Destroy(gameObject, 1f);
            if (GameManager.instance.GetLives() == 0)
            {
                Time.timeScale = 1f;
            }
        }
    }
}
