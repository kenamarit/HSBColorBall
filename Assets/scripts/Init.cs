using UnityEngine;
//using System.Collections;

public class Init : MonoBehaviour 
{
	public GameObject cube;

	private Vector3 prevMousePos = Vector3.zero;

	private int cubeGeneratorDelayMax = 3;
	private int cubeGeneratorDelay = 0;

	private float currentHue = 0;
	private float currentSaturation;
	private float currentBrightness;

	void Start()
	{
		
	}

	void GenerateCubes()
	{
		Vector3 cubePos = Camera.main.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, 110 ));
		cubePos.z = 10;

		GameObject newCube = (GameObject)Instantiate( cube, cubePos, Quaternion.identity );
		GameObject newCube2 = (GameObject)Instantiate( cube, cubePos, Quaternion.identity );
		GameObject newCube3 = (GameObject)Instantiate( cube, cubePos, Quaternion.identity );
		GameObject newCube4 = (GameObject)Instantiate( cube, cubePos, Quaternion.identity );
		//GameObject newCube5 = (GameObject)Instantiate( cube, cubePos, Quaternion.identity );
		//GameObject newCube6 = (GameObject)Instantiate( cube, cubePos, Quaternion.identity );

		// Change based on HSB
		HSBColor newColor = new HSBColor( currentHue, currentSaturation, currentBrightness );

		newCube.renderer.material.color = HSBColor.ToColor( newColor );
		newCube2.renderer.material.color = HSBColor.ToColor( newColor );
		newCube3.renderer.material.color = HSBColor.ToColor( newColor );
		newCube4.renderer.material.color = HSBColor.ToColor( newColor );
		//newCube5.renderer.material.color = HSBColor.ToColor( newColor );
		//newCube6.renderer.material.color = HSBColor.ToColor( newColor );

		Debug.Log( newColor );
	}

	void Update()
	{
		ChangeHue();
		ChangeSB();

		if( cubeGeneratorDelay == cubeGeneratorDelayMax )
		{
			GenerateCubes();
			cubeGeneratorDelay = 0;
		}
		else
		{
			cubeGeneratorDelay++;
		}
		
		// IF you want the cubes to react if you hover over them with the mouse,
		// uncomment the code below:

		//CheckForCubeAtCurrentMousePos();
		//prevMousePos = Input.mousePosition;
	}

	void CheckForCubeAtCurrentMousePos()
	{
		Rigidbody currentCube = PickRigidbody( Input.mousePosition );

		if( currentCube != null )
		{
			Vector3 direction = prevMousePos - Input.mousePosition;
			direction = direction.normalized;

			currentCube.AddForce( direction*800 );
		}
	}

	Rigidbody PickRigidbody( Vector3 pos )
	{
	    Ray ray = Camera.main.ScreenPointToRay( pos );
	    RaycastHit hit;
	 
	    if( !Physics.Raycast( ray, out hit ) )
	        return null;
	 
	    return hit.rigidbody;
	}

	void ChangeHue()
	{
		if( Input.GetMouseButton(0) )
		{
			currentHue += 0.003f;
		}

		if( currentHue >= 1.0f )
		{
			currentHue = 0;
		}
	}

	void ChangeSB()
	{
		Vector3 currentPos = Camera.main.ScreenToViewportPoint( Input.mousePosition );

		currentSaturation = currentPos.x;
		currentBrightness = currentPos.y;
	}

}