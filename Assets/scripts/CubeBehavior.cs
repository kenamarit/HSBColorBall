using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour 
{
	private Vector3 startPos;

	private float destroyCounter = 0;

	void Start()
	{
		startPos = transform.position;
		//rigidbody.AddForce( Vector3.down * 1000 );
		StartCoroutine( DestroyAfterTime( 1.3f ) );
	}

	
	void FixedUpdate()
	{
		Vector3 moveTowardPos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		moveTowardPos.z = 20;
		Vector3 direction = moveTowardPos - transform.position;
		direction = direction.normalized;
		
		rigidbody.AddForce(direction*800);	
	}


	IEnumerator DestroyAfterTime( float seconds )
	{
		yield return new WaitForSeconds( seconds );
		Destroy( gameObject );
	}
	
}