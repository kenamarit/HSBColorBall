using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	public Texture2D play;
	public Texture2D playRollOver;

	public void OnMouseEnter()
	{
		guiTexture.texture = playRollOver;
	}

	public void OnMouseExit()
	{
		guiTexture.texture = play;
	}

	public void OnMouseDown()
	{
		Application.LoadLevel("comp");
	}
}