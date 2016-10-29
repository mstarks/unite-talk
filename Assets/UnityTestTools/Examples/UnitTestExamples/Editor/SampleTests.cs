using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

namespace UnityTest
{
	[TestFixture]
	[Category ("Sample Tests")]
	internal class SampleTests
	{
		[Test]
		[Ignore ("Ignored test")]
		[Category ("Failing Tests")]
		public void ExceptionTest ()
		{
			throw new Exception ("Exception throwing test");
		}

		[Test]
		[Ignore ("Ignored test")]
		public void IgnoredTest ()
		{
			throw new Exception ("Ignored this test");
		}

		[Test]
		[MaxTime (100)]
		[Ignore ("Ignored test")]
		[Category ("Failing Tests")]
		public void SlowTest ()
		{
			Thread.Sleep (200);
		}

		[Test]
		[Ignore ("Ignored test")]
		[Category ("Failing Tests")]
		public void FailingTest ()
		{
			Assert.Fail ();
		}

		[Test]
		[Ignore ("Ignored test")]
		[Category ("Failing Tests")]
		public void InconclusiveTest ()
		{
			Assert.Inconclusive ();
		}

		[Test]
		public void PassingTest ()
		{
			Assert.Pass ();
		}

		[Test]
		public void ParameterizedTest ([Values (1, 2, 3)] int a)
		{
			Assert.Pass ();
		}

		[Test]
		public void RangeTest ([NUnit.Framework.Range (1, 10, 3)] int x)
		{
			Assert.Pass ();
		}

		[Test]
		[Culture ("pl-PL")]
		public void CultureSpecificTest ()
		{
		}

		[Test]
		[Ignore ("Ignored test")]
		[ExpectedException (typeof (ArgumentException), ExpectedMessage = "expected message")]
		public void ExpectedExceptionTest ()
		{
			throw new ArgumentException ("expected message");
		}

		[Datapoint]
		public double zero = 0;
		[Datapoint]
		public double positive = 1;
		[Datapoint]
		public double negative = -1;
		[Datapoint]
		public double max = double.MaxValue;
		[Datapoint]
		public double infinity = double.PositiveInfinity;

		[Theory]
		[Ignore ("Ignored test")]
		public void SquareRootDefinition (double num)
		{
			Assume.That (num >= 0.0 && num < double.MaxValue);

			var sqrt = Math.Sqrt (num);

			Assert.That (sqrt >= 0.0);
			Assert.That (sqrt * sqrt, Is.EqualTo (num).Within (0.000001));
		}
	}
}
