using UnityEngine;
using System.Collections.Generic;

public class MazeCellZBehaviour : MonoBehaviour
{
	[SerializeField]
	List<MazeWallZBehaviour> _mazeWalls;

	MazeCellZ _mazeCell;

	void Start()
	{
		_mazeCell = new MazeCellZ();
	}

	public void SetOuterWallAsBorder(WallIndex wallIndex)
	{
		if ((int)wallIndex >= 0 && (int)wallIndex < _mazeWalls.Count)
		{
			_mazeWalls[(int)wallIndex].IsOuterBorderWall = true;
		}
	}

	public void RemoveWall(WallIndex wallIndex)
	{
		if ((int)wallIndex >= 0 && (int)wallIndex < _mazeWalls.Count)
		{
			if (!_mazeWalls[(int)wallIndex].IsOuterBorderWall)
			{
				_mazeWalls[(int)wallIndex].gameObject.SetActive(false);
			}
		}
	}

	public bool DoesWallExist(WallIndex wallIndex)
	{
		if ((int)wallIndex >= 0 && (int)wallIndex < _mazeWalls.Count)
		{
			return _mazeWalls[(int)wallIndex].gameObject.activeSelf;
		}

		return false;
	}
}

