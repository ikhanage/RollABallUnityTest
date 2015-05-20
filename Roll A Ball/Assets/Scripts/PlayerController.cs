using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float _speed;
	public GUIText _countText;
	public GUIText _winText;

	private Rigidbody _rigidBody;
	private int _count;

	void Start () {
		_rigidBody = GetComponent<Rigidbody> ();
		_count = 0;
		SetCountText ();
		_winText.text = "";
	}

	void Update () {
	
	}
	
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		var movement = new Vector3{ x = moveHorizontal, y = 0.0f, z = moveVertical };

		_rigidBody.AddForce (movement * _speed);
	}

	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive(false);
			_count++;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		_countText.text = "Count: " + _count.ToString ();
		if (_count >= 4)
			_winText.text = "Well I'll be";
	}
}
