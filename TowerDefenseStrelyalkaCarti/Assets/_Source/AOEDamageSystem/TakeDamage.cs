using UnityEngine;
using EnemySystem;
using Interfaces;
using System;

public class TakeDamage : MonoBehaviour
{
	[field: SerializeField] private float damage;

	[field: SerializeField] public LayerMask EnemyLayer { get; private set; }


	private void OnTriggerEnter2D(Collider2D other)
	{
		if ((EnemyLayer & (1 << other.gameObject.layer)) != 0)
			other.gameObject.GetComponent<IDamageble>().TakeDamage(damage);
	}
}