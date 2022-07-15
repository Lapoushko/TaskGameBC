using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalMover : MonoBehaviour
{
    [SerializeField] private float speed;

    GameController game = null;

    bool isCanMoving = true;

    private void Update()
    {
        if (isCanMoving)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
