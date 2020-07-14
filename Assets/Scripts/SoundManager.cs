using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager;

    public AudioSource gameSound;

    public AudioClip hitEnemy;
    public AudioClip hitPlayer;
    public AudioClip selectButton;
    public AudioClip playerJump;
    public AudioClip playerAttack;
    public AudioClip enemyAttack;
    public AudioClip playerRun;
    public AudioClip gameOver;

    private void Awake()
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

    public void playerJumpSound()
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

    public void playerRunSound()
    {
        gameSound.PlayOneShot(playerRun);
    }

    public void gameOverSnd()
    {
        gameSound.PlayOneShot(gameOver);
    }
    private void Update()
    {
        
    }
}
