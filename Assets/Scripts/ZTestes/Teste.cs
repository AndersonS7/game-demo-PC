using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{

    private Vector3 _direction;
    private float _speed = 5;

    private string global = "Global";

    public Rigidbody2D r;
    // Start is called before the first frame update
    void Start()
    {
        //Teste01();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        _direction = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += _direction * Time.deltaTime * _speed;
    }

    private void Teste01(string b)
    {
        string novo = b;

        print(novo);
    }

    private void Teste02()
    {
        print("Função 2");
    }
}
