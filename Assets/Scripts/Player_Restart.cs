using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Restart : MonoBehaviour
{

    [SerializeField] private Transform _initialPosition;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerRenderer;
    [SerializeField] private ParticleSystem _playerDeathParticles;

    // Start is called before the first frame update
    void Start()
    {
        _player.transform.position = _initialPosition.position;
    }

    //! SET YOUR POSITION TO THE INITIAL POSITION IF YOU TOUCH SOMETHING WITH THE DANGER TAG
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Danger"))
        {
            StartCoroutine("TimeDelay");
            _player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            _playerRenderer.SetActive(false);
            _playerDeathParticles.Play();
            /*TODO
             *      DEATH SOUND
             */
        }
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(0.5f);
        
        _player.transform.position = _initialPosition.position;
        _player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        _playerRenderer.SetActive(true);
    }
}
