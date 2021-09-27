using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : CharacterBase
{
    public Rigidbody2D myRigidbody2D;
    public LayerMask groundLayer;
    public Transform ground;
    public ParticleSystem jumpParticles;

    private float _localSpeed;
    private float _horizontalAxes;

    [Header("Sound")]
    public List<AudioClip> audioClipsList;
    public List<AudioSource> audioSourcesList;

    public AudioClip JumpAudioClip;

    private int _soundIndex = 0;

    private void Awake()
    {
        ground = transform.GetChild(1);
        anim = GetComponent<Animator>();
        VFXManager.Instance.PlayVFXByType(VFXManager.VFXType.RUN, transform.position, ground, true);
    }

    void Update()
    {
        if (isDead) return;

        _horizontalAxes = Input.GetAxis("Horizontal");

        if(_horizontalAxes == 0)
        {
            _localSpeed = 0;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                _localSpeed = charInfo.runSpeed;
            }
            else
            {
                _localSpeed = charInfo.speed;
            }
        }

        myRigidbody2D.velocity = new Vector2(_horizontalAxes * _localSpeed, myRigidbody2D.velocity.y);

        AnimationStateConfig();

        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround())
        {
            if(powerJumps.value > 0)
            {
                myRigidbody2D.velocity = Vector2.up * charInfo.powerJumpForce;
                ItemsManager.Instance.AddItem(ItemsManager.ItemType.POWERJUMP, -1);
            }
            else
            {
                myRigidbody2D.velocity = Vector2.up * charInfo.jumpForce;
            }

            PlayJumpSound();
            VFXManager.Instance.PlayVFXByType(VFXManager.VFXType.JUMP, transform.position, ground);
        }

        anim.SetBool("Grounded", onGround());
        anim.SetFloat("YMov", myRigidbody2D.velocity.y);
    }

    protected override void Kill()
    {
        base.Kill();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void AnimationStateConfig()
    {
        if(_horizontalAxes != 0)
        {
            var direction = Mathf.Sign(_horizontalAxes);
            myRigidbody2D.transform.localScale = new Vector3(direction, 1, 1);
        }

        anim.SetFloat("XMov", _localSpeed);
    }

    private bool onGround()
    {
        return Physics2D.OverlapCircle(ground.position, .75f, groundLayer);
    }

    public void PlayRandomFootstep()
    {
        if (_soundIndex >= audioSourcesList.Count) _soundIndex = 0;

        AudioSource audioSource = audioSourcesList[_soundIndex];

        audioSource.clip = audioClipsList[Random.Range(0, audioClipsList.Count)];
        audioSource.Play();

        _soundIndex++;
    }

    public void PlayJumpSound()
    {
        if (_soundIndex >= audioSourcesList.Count) _soundIndex = 0;

        AudioSource audioSource = audioSourcesList[_soundIndex];

        audioSource.clip = JumpAudioClip;
        audioSource.Play();

        _soundIndex++;
    }
}
