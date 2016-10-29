using System;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ExperimentalTest
{
	[Test]
	public void Behaviour1Test()
	{
		// Arrange
		SimpleBehaviour1 simple1 = new SimpleBehaviour1();

		// Act
		simple1.HandleCollision();
		simple1.HandleCollision();

		// Assert
		Assert.That(simple1.CollisionCount, Is.EqualTo(2));
	}

	[Test]
	public void Behaviour2Test()
	{
		// Arrange
		SimpleBehaviour2 simple2 = new SimpleBehaviour2();

		// Act
		simple2.HandleCollision();
		simple2.HandleCollision();

		// Assert
		Assert.That(simple2.GetCollisionCount(), Is.EqualTo(2));
	}


	public class SimpleBehaviour1 : MonoBehaviour
	{
		public int CollisionCount { get; set; }

		void Awake()
		{
			CollisionCount = 0;
		}

		public void HandleCollision()
		{
			CollisionCount++;
		}

	}

	public class SimpleBehaviour2 : MonoBehaviour
	{
		[SerializeField]
		int _collisionCount = 5;


		public void HandleCollision()
		{
			_collisionCount++;
		}

		public int GetCollisionCount()
		{
			return _collisionCount;
		}

	}


}


