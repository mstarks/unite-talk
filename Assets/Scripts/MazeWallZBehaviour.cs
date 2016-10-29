using UnityEngine;
using System.Collections;

public class MazeWallZBehaviour : MonoBehaviour
{
	public bool IsOuterBorderWall { get; set; }


	public void RemoveWall()
	{
		if (!IsOuterBorderWall)
		{
			this.gameObject.SetActive(false);
		}
	}

	public void AddWall()
	{
		this.gameObject.SetActive(true);
	}

}
