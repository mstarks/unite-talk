using UnityEngine;
using System.Collections;
using NUnit.Framework;

[TestFixture]
public class PlayerStatsZTest
{

	//      DONE
	// Player Stats are initialized with maximum Health and zero Currency.
	// Currency in Player Stats can be increased or decreased.
	// Health in Player Stats can be increased or decreased.
	// Health cannot exceed Maximum Health (100).
	// Health and Currency cannot go negative.


	[Test]
	public void PlayerBeginsWithMaxHealthTest()
	{
		// Arrange and Act
		const int maxHealth = 100;
		PlayerStatsZ playerStats = new PlayerStatsZ();

		// Assert
		Assert.That(playerStats.CurrentHealth, Is.EqualTo(maxHealth));
	}

	[Test]
	public void PlayerBeginsWithNoCurrencyTest()
	{
		// Arrange and Act
		const int initialCurrency = 0;
		PlayerStatsZ playerStats = new PlayerStatsZ();

		// Assert
		Assert.That(playerStats.CurrentCurrency, Is.EqualTo(initialCurrency));
	}

	[TestCase(20, 100)]
	[TestCase(-20, 80)]
	[TestCase(-120, 0)]
	public void PlayerHealthCanBeUpdatedTest(int deltaHealth, int expectedHealth)
	{
		// Arrange
		PlayerStatsZ playerStats = new PlayerStatsZ();

		// Act
		playerStats.UpdateHealth(deltaHealth);

		// Assert
		Assert.That(playerStats.CurrentHealth, Is.EqualTo(expectedHealth));
	}

	[TestCase(20, 20)]
	[TestCase(-40, 0)]
	public void PlayerCurrencyCanBeUpdatedTest(int deltaCurrency, int expectedCurrency)
	{
		// Arrange
		PlayerStatsZ playerStats = new PlayerStatsZ();

		// Act
		playerStats.UpdateCurrency(deltaCurrency);

		// Assert
		Assert.That(playerStats.CurrentCurrency, Is.EqualTo(expectedCurrency));
	}

}
