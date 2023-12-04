using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacoEnnemi : MonoBehaviour
{
    [SerializeField] private float _vitesseTaco = 6.5f;

    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _vitesseTaco);

    }
}
