using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class MazeLayoutZTest
{
	// TODO
	// 
	// Each cell in a maze layout can be reached by the player
	//		Need to determine which walls to remove off path
	// A maze layout contains at least one valid path through the maze
	// The path through cells has a travel direction
	// Cells in a path are contiguous
	// The path cannot lead (in the wrong direction) out of a border cell

	// Remove the South wall from the first maze cell (so players can enter the maze).
	// Remove the North wall from the last maze cell, making sure it’s a North-most cell.
	// Remove the walls from each corresponding part of the cells on the “correct” path.
	//		Use the previous tests to “build the correct path”.
	// Adjacent cells must have matching wall removals.
	// The outer walls of border cells must not be removed (except at the start and end).
	// Border walls cannot be removed!
	// Be able to remove all non-border walls.


	// Notes
	//	Each cell can be reached by not having too many walls
	//	Walls that enclose a portion of the maze layout need to be avoided
	//	But we may only have to remove one cell wall to clear an entire area
	//	Instead of calculating path at each cell, could we just choose between
	//		all of the possible paths through a maze of a given size? NO!
	//		How large a set is this? It gets bigger than the number of cells!
	//	Probability for rewards and hazards can be set per cell


	//    DONE
	// A Maze Creator generates a valid Maze Layout
	// Each cell in a Maze Layout is valid (+ ...)
	// A valid Maze Cell must have 0, 1, 2, or 3 walls



	// TODO: Come up with a REASONABLE example instead of MazeCreatorZGenerateAValidMazeTest!
	//[Test]
	//public void MazeCreatorZGeneratesAValidMazeTest()
	//{
	//	// Arrange
	//	var mazeCreator = Substitute.For<IMazeCreatorZ>();
	//	MazeLayoutZ testMazeLayout = new MazeLayoutZ();
	//	testMazeLayout.RemoveMazeCell(0, WallIndex.NorthWall);
	//	mazeCreator.CreateMazeLayout().Returns(testMazeLayout);

	//	// Act
	//	MazeLayoutZ mazeLayout = mazeCreator.CreateMazeLayout();
	//	bool result = mazeLayout.IsValid();

	//	// Assert
	//	Assert.IsTrue(result);
	//}

	//[Test]
	//public void RemoveWallTest()
	//{
	// Arrange
	//MazeCreatorZBehaviour mazeCreator = new MazeCreatorZBehaviour();

	// Act
	//mazeCreator.RemoveWall(1, WallIndex.WestWall);
	//bool result = mazeCreator.DoesWallExist(1, WallIndex.WestWall);

	// Assert
	//Assert.IsTrue(result);
	//}

	[Test]
	public void RemoveWallTest()
	{
		// Arrange
		MazeLayoutZ mazeLayout = new MazeLayoutZ();

		// Act
		//mazeLayout.RemoveWall(1, WallIndex.WestWall);
		//bool result = mazeLayout.DoesWallExist(1, WallIndex.WestWall);

		// Assert
		//Assert.IsTrue(result);
	}



}
