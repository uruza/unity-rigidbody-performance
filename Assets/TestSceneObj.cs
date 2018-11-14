
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneObj : MonoBehaviour
{
    public GameObject actorTemp;
    public bool actorRigidBody;
    public int actorCount = 1;
    public Vector2 actorGenArea = Vector2.one;

    public GameObject bulletTemp;
    public bool bulletRigidBody;
    public float bulletSpeed = 1.0f;
    public float bulletInterval = 1;
    public float bulletLifeTime = 5.0f;
    public Vector2 bulletGenArea = Vector2.one;
    public Vector3 bulletGenPos = Vector3.one;

    private void Awake()
    {
        for ( int i = 0; i < actorCount; i++ ) {
            float posX = Random.Range( -actorGenArea.x, actorGenArea.x );
            float posZ = Random.Range( -actorGenArea.y, actorGenArea.y );
            GameObject go = Instantiate( actorTemp );

            if ( actorRigidBody ) {
                Rigidbody rigidbodyCom = go.AddComponent<Rigidbody>();
                rigidbodyCom.constraints = RigidbodyConstraints.FreezeAll;
                rigidbodyCom.useGravity = false;
            }

            go.transform.SetParent( actorTemp.transform.parent, false );
            go.transform.position = new Vector3( posX, 0.0f, posZ );
        }
        actorTemp.SetActive( false );
    }


    void Start()
    {
        StartCoroutine( GenBullet() );
    }

    IEnumerator GenBullet() {

        while ( true ){

            float posX = Random.Range( -bulletGenArea.x, bulletGenArea.x ) + bulletGenPos.x;
            float posZ = Random.Range( -bulletGenArea.y, bulletGenArea.y ) + bulletGenPos.z;
            GameObject go = Instantiate( bulletTemp );

            if ( bulletRigidBody ) {
                Rigidbody rigidbodyCom = go.AddComponent<Rigidbody>();
                rigidbodyCom.constraints = RigidbodyConstraints.FreezeAll;
                rigidbodyCom.useGravity = false;
            }

            go.transform.SetParent( bulletTemp.transform.parent, false );
            go.transform.position = new Vector3( posX, 0.0f, posZ );
            Bullet bullet = go.AddComponent<Bullet>();
            bullet.speed = bulletSpeed;
            bullet.lifeTime = bulletLifeTime;

            yield return new WaitForSeconds( bulletInterval );
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
