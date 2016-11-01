using UnityEngine;

public class PlayerControlZBehaviour : MonoBehaviour
{
	[SerializeField]
	PlayerStatsZBehaviour _playerStats;

	Rigidbody _rb;


	void Start()
	{
		_rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		// for game logic
	}

	void FixedUpdate()
	{
		// for physics logic
		const float speed = 1.5f;

		float thrustX = Input.GetAxis("Horizontal");
		float thrustZ = Input.GetAxis("Vertical");

		Vector3 thrust = new Vector3(thrustX, 0.0f, thrustZ);
		_rb.AddForce(thrust * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		DetermineCollisionResults(other);
	}

	public void DetermineCollisionResults(Collider aCollider)
	{
		const int wealthIncrement = 10;
		const int healthIncrement = -5;

		if (aCollider.gameObject.CompareTag("Reward"))
		{
			aCollider.gameObject.SetActive(false);

			_playerStats.UpdateCurrency(wealthIncrement);

		}

		if (aCollider.gameObject.CompareTag("Hazard"))
		{
			_playerStats.UpdateHealth(healthIncrement);
		}
	}

}