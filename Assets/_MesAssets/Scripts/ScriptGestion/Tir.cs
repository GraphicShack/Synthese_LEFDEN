using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    [SerializeField] private float _vitesseLaser = 20f;

    private void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * _vitesseLaser);

        if (transform.position.x > 10f)
        {
            if (transform.parent == null)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(transform.parent.gameObject);
            }

        }
    }
}
