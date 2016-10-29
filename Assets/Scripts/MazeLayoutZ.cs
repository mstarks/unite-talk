using System.Collections.Generic;
using UnityEngine;

public class MazeLayoutZ
{
	List<MazeCellZ> _mazeCells;

	public MazeLayoutZ()
	{
		_mazeCells = new List<MazeCellZ>() { new MazeCellZ() };
	}

	public void RemoveMazeCell(int cellIndex, WallIndex wallIndex)
	{
		if (cellIndex >= 0 && cellIndex < _mazeCells.Count)
		{
			_mazeCells[cellIndex].RemoveWall(wallIndex);
		}

	}

	// TODO: Refine the meaning of IsValid to include more than just individual cells...
	public bool IsValid()
	{
		for (int i = 0; i < _mazeCells.Count; ++i)
		{
			if (!_mazeCells[i].IsValid())
			{
				return false;
			}
		}

		return true;
	}
}
