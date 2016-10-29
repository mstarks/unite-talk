using System;
using NUnit.Framework;


[TestFixture]
public class MazeCellZTest
{
	[Test]
	public void DefaultMazeCellZIsNotValid()
	{
		// Arrange and Act
		MazeCellZ mazeCell = new MazeCellZ();

		// Assert
		Assert.IsFalse(mazeCell.IsValid()); // A MazeCellZ is constructed with four walls
	}

	[Test]
	public void MazeCellZHasValidNumberOfWallsTest()
	{
		// Arrange
		MazeCellZ mazeCell = new MazeCellZ();

		// Act and Assert
		mazeCell.RemoveWall(WallIndex.NorthWall);
		Assert.IsTrue(mazeCell.IsValid());

		mazeCell.RemoveWall(WallIndex.EastWall);
		Assert.IsTrue(mazeCell.IsValid());

		mazeCell.RemoveWall(WallIndex.SouthWall);
		Assert.IsTrue(mazeCell.IsValid());

		mazeCell.RemoveWall(WallIndex.WestWall);
		Assert.IsTrue(mazeCell.IsValid());

	}

}


