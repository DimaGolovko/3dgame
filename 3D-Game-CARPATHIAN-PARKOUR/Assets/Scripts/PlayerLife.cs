using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private TextMeshProUGUI _text;

    private int HealthPoints { get; set; } = 100;

    private void Start()
    {
        _text.text = HealthPoints.ToString();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy body")) Die();
    }

    void Die()
    {
        _text.text = 0.ToString();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        _audioSource.Play();
        Invoke(nameof(ReloadLevel), 1.3f);
    }

    void ReloadLevel()
    {
        _text.text = HealthPoints.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
