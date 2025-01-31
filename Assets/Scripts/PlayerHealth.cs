﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public int health = 500;
	public int currentHealth;

	public void TakeDamage(int damage)
	{
		
		currentHealth -= damage;

		StartCoroutine(DamageAnimation());

		if (currentHealth <= 0)
		{
			Debug.Log("죽었습니다.");
			Die();
		}
	}

	private void Start()
	{
		currentHealth = health;
	}

	void Die()
	{
		Debug.Log("실행됨");
		SoundManager.soundManager.gameOverSnd();
		SceneManager.LoadScene("GameOver");
	}

	IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}
}