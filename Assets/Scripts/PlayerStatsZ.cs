using System;

public class PlayerStatsZ
{
	const int MAX_HEALTH = 100;

	public int CurrentHealth;
	public int CurrentCurrency;

	public PlayerStatsZ()
	{
		CurrentHealth = MAX_HEALTH;
		CurrentCurrency = 0;
	}

	public void UpdateHealth(int deltaHealth)
	{
		CurrentHealth += deltaHealth;
		if (CurrentHealth > MAX_HEALTH)
		{
			CurrentHealth = MAX_HEALTH;
		}
		if (CurrentHealth < 0)
		{
			CurrentHealth = 0;
		}
	}

	public void UpdateCurrency(int deltaCurrency)
	{
		CurrentCurrency += deltaCurrency;
		if (CurrentCurrency < 0)
		{
			CurrentCurrency = 0;
		}
	}

}

