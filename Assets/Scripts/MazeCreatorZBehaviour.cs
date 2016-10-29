using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MazeCreatorZBehaviour : MonoBehaviour, IMazeCreatorZ
{
	[SerializeField]
	MazeCellZBehaviour _mazeCell;

	[SerializeField]
	int _numberOfCellsNorth;

	[SerializeField]
	int _numberOfCellsEast;

	List<MazeCellZBehaviour> _mazeCells;

	void Awake()
	{
		_mazeCells = new List<MazeCellZBehaviour>();
	}

	void Start()
	{
		BuildMaze();
	}

	public void BuildMaze()
	{
		const float mazeCellSize = 4.0f;
		for (int i = 0; i < _numberOfCellsEast; ++i)
		{
			for (int j = 0; j < _numberOfCellsNorth; ++j)
			{
				Vector3 position = new Vector3(mazeCellSize * i, 0, mazeCellSize * j);
				Quaternion rotation = new Quaternion();
				MazeCellZBehaviour mazeCell = Instantiate(_mazeCell, position, rotation) as MazeCellZBehaviour;

				_mazeCells.Add(mazeCell);
			}
		}

		SetOuterWalls();

		RemoveWall(0, WallIndex.SouthWall);
		RemoveWall(_mazeCells.Count - 1, WallIndex.NorthWall);
		RemoveAllInsideWalls(); // TODO: Explore other options
	}

	void SetOuterWalls()
	{
		for (int i = 0; i < _mazeCells.Count; ++i)
		{
			// West
			if (i < _numberOfCellsNorth)
			{
				_mazeCells[i].SetOuterWallAsBorder(WallIndex.WestWall);
			}

			// South
			if ((i % _numberOfCellsNorth) == 0 && i != 0)
			{
				_mazeCells[i].SetOuterWallAsBorder(WallIndex.SouthWall);
			}

			// East
			int eastTarget = _numberOfCellsNorth * (_numberOfCellsEast - 1);
			if (i >= eastTarget)
			{
				_mazeCells[i].SetOuterWallAsBorder(WallIndex.EastWall);
			}

			// West
			if ((i % _numberOfCellsNorth) == (_numberOfCellsNorth - 1) && i != (_mazeCells.Count - 1))
			{
				_mazeCells[i].SetOuterWallAsBorder(WallIndex.NorthWall);
			}

		}

	}

	public void RemoveAllInsideWalls()
	{
		// TODO: Prevent outer walls from being removed
		for (int i = 0; i < _mazeCells.Count; ++i)
		{
			RemoveWall(i, WallIndex.NorthWall);
			RemoveWall(i, WallIndex.EastWall);
			RemoveWall(i, WallIndex.SouthWall);
			RemoveWall(i, WallIndex.WestWall);
		}
	}

	public void RemoveWall(int cellIndex, WallIndex wallIndex)
	{
		if ((int)wallIndex >= 0 && (int)wallIndex < _mazeCells.Count)
		{
			_mazeCells[cellIndex].RemoveWall(wallIndex);
		}
	}

	public bool DoesWallExist(int cellIndex, WallIndex wallIndex)
	{
		if ((int)wallIndex >= 0 && (int)wallIndex < _mazeCells.Count)
		{
			return _mazeCells[cellIndex].DoesWallExist(wallIndex);
		}
		return false;
	}

	public MazeLayoutZ CreateMazeLayout()
	{
		//throw new NotImplementedException();
		return new MazeLayoutZ();
	}
}

public interface IMazeCreatorZ
{
	MazeLayoutZ CreateMazeLayout();
}

public enum WallIndex
{
	NorthWall = 0,
	EastWall,
	SouthWall,
	WestWall
}
