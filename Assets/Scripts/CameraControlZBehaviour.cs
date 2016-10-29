using UnityEngine;

public class CameraControlZBehaviour : MonoBehaviour
{
	[SerializeField]
	GameObject _player;

	[SerializeField]
	float _playerOffset = 30.0f;

	Vector3 _offset;

	void Start()
	{
		_offset = transform.position - _player.transform.position;
		_offset += new Vector3(0.0f, _playerOffset, 0.0f);
	}

	void LateUpdate()
	{
		transform.position = _player.transform.position + _offset;
		transform.LookAt(_player.transform);
	}

}
