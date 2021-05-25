using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
	public float lifetime = 2f;

	void Start()
	{
		Invoke("Release", lifetime);
	}

	void Release()
	{
		Destroy(gameObject);
	}
}
