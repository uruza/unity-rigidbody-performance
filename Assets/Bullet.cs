
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime = float.MaxValue;

    private void Awake()
    {

    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine( CheckLifeTime() );
    }

    IEnumerator CheckLifeTime()
    {
        yield return new WaitForSeconds( lifeTime );
        Destroy( gameObject );
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
}
