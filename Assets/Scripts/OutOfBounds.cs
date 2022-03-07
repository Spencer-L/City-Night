using System.Collections;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] private Animator canvasAnimator;
    private static readonly int FadeOutBool = Animator.StringToHash("Fade Out");

    // player
    private GameObject _player;
    private Vector3 _respawnPoint;
    private FirstPersonMovement _playerMove;
    private Jump _playerJump;
    private Crouch _playerCrouch;
    [SerializeField] private AudioSource faint;

    private void Start()
    {
        _player = GameObject.Find("Player");
        _respawnPoint = _player.transform.position;
        _playerMove = _player.GetComponent<FirstPersonMovement>();
        _playerJump = _player.GetComponent<Jump>();
        _playerCrouch = _player.GetComponent<Crouch>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            StartCoroutine(FadeOut());
        }
    }

    private void TogglePlayerMovement(bool state)
    {
        _playerMove.enabled = state;
        _playerJump.enabled = state;
        _playerCrouch.enabled = state;
    }

    private IEnumerator FadeOut()
    {
        faint.Play();
        TogglePlayerMovement(false);
        canvasAnimator.SetBool(FadeOutBool, true);
        yield return new WaitForSeconds(0.5f);
        canvasAnimator.SetBool(FadeOutBool, false);
        _player.transform.position = _respawnPoint;
        TogglePlayerMovement(true);
    }
}
