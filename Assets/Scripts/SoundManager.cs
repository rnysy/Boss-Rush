using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;

    AudioSource gameSound;

    public AudioClip hitEnemy;
    public AudioClip hitPlayer;
    public AudioClip selectButton;
    public AudioClip playerJump;
    public AudioClip playerAttack;
    public AudioClip enemyAttack;
    public AudioClip playerRun;

    void Awake()
    {
        if(soundManager == null)
        {
            soundManager = this;
        }
    }

    public void playHitSound()
    {
        gameSound.PlayOneShot(hitPlayer);
    }

    public void playEnemyHitSound()
    {
        gameSound.PlayOneShot(hitEnemy);
    }

    public void jumpSound()
    {
        gameSound.PlayOneShot(playerJump);
    }

    public void buttonSelectSound()
    {
        gameSound.PlayOneShot(selectButton);
    }

    public void playerAttackSound()
    {
        gameSound.PlayOneShot(playerAttack);
    }

    public void enemyAttackSound()
    {
        gameSound.PlayOneShot(enemyAttack);
    }

    public void playerRundSound()
    {
        gameSound.PlayOneShot(playerRun);
    }
}
