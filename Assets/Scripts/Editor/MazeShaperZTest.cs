using NUnit.Framework;


[TestFixture]
public class MazeShaperZTest
{
	// TODO
	//
	// A Default Maze Cell is not valid, because it has 4 walls.
	// A valid Maze Cell must have 0, 1, 2, or 3 walls.
	// A Maze Shaper can identify Border Cells.
	// A Maze Shaper can find adjacent Maze Cells (if they exist).


	[TestCase(4, 5, 3, WallIndex.NorthWall, true)]
	[TestCase(4, 5, 3, WallIndex.EastWall, false)]
	[TestCase(4, 5, 3, WallIndex.SouthWall, false)]
	[TestCase(4, 5, 3, WallIndex.WestWall, true)]
	[TestCase(4, 5, 8, WallIndex.SouthWall, true)]
	[TestCase(4, 5, 8, WallIndex.NorthWall, false)]
	[TestCase(4, 5, 10, WallIndex.EastWall, false)]
	[TestCase(4, 5, 10, WallIndex.WestWall, false)]
	[TestCase(4, 5, 16, WallIndex.NorthWall, false)]
	[TestCase(4, 5, 16, WallIndex.EastWall, true)]
	[TestCase(4, 5, 16, WallIndex.SouthWall, true)]
	[TestCase(4, 5, 16, WallIndex.WestWall, false)]
	public void IsBorderCellTest(int maxY, int maxX,
				  int cellIndex, WallIndex wallIndex, bool expectedResult)
	{
		// Arrange
		MazeShaperZ shaper = new MazeShaperZ(maxY, maxX);

		// Act
		bool result = false;
		if (wallIndex == WallIndex.NorthWall)
		{
			result = shaper.IsNorthBorderCell(cellIndex);
		}

		if (wallIndex == WallIndex.EastWall)
		{
			result = shaper.IsEastBorderCell(cellIndex);
		}

		if (wallIndex == WallIndex.SouthWall)
		{
			result = shaper.IsSouthBorderCell(cellIndex);
		}

		if (wallIndex == WallIndex.WestWall)
		{
			result = shaper.IsWestBorderCell(cellIndex);
		}

		// Assert
		Assert.That(expectedResult, Is.EqualTo(result));
	}

	[TestCase(4, 5, 3, WallIndex.NorthWall, -1)]
	[TestCase(4, 5, 3, WallIndex.EastWall, 7)]
	[TestCase(4, 5, 3, WallIndex.SouthWall, 2)]
	[TestCase(4, 5, 3, WallIndex.WestWall, -1)]
	[TestCase(4, 5, 9, WallIndex.NorthWall, 10)]
	[TestCase(4, 5, 9, WallIndex.EastWall, 13)]
	[TestCase(4, 5, 9, WallIndex.SouthWall, 8)]
	[TestCase(4, 5, 9, WallIndex.WestWall, 5)]
	[TestCase(4, 5, 16, WallIndex.NorthWall, 17)]
	[TestCase(4, 5, 16, WallIndex.EastWall, -1)]
	[TestCase(4, 5, 16, WallIndex.SouthWall, -1)]
	[TestCase(4, 5, 16, WallIndex.WestWall, 12)]
	public void FindAdjacentCellTest(int maxY, int maxX,
									 int cellIndex, WallIndex wallIndex, int expected)
	{
		// Arrange
		MazeShaperZ shaper = new MazeShaperZ(maxY, maxX);

		// Act
		int adjacentResult = shaper.FindAdjacentCellIndex(cellIndex, wallIndex);

		// Assert
		Assert.That(adjacentResult, Is.EqualTo(expected));
	}
}


