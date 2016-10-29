using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsZBehaviour : MonoBehaviour
{
	[SerializeField]
	Text _healthIndicator;

	[SerializeField]
	Text _currencyIndicator;

	PlayerStatsZ _playerStats;

	void Awake()
	{
		_playerStats = new PlayerStatsZ();
	}

	public void UpdateHealth(int deltaHealth)
	{
		_playerStats.UpdateHealth(deltaHealth);
		_healthIndicator.text = _playerStats.CurrentHealth.ToString();
	}

	public void UpdateCurrency(int deltaCurrency)
	{
		_playerStats.UpdateCurrency(deltaCurrency);
		_currencyIndicator.text = _playerStats.CurrentCurrency.ToString();
	}
}

