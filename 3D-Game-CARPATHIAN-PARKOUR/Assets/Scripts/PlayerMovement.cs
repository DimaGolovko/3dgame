using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float _movementSpeed = 6f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private AudioSource[] _audioSources;
    [SerializeField] private TextMeshProUGUI _text;

    private int HealthPoints { get; set; } = 100;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _text.text = HealthPoints.ToString();
    }

    void Update()
    {
        if (rb.position.y < -2f) Die();
        
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(
            horizontalInput * _movementSpeed, rb.velocity.y, verticalInput * _movementSpeed);
        
        if (Input.GetButtonDown("Jump") && IsGrounded()) Jump();
    }

    private void Jump()
    {
        rb.velocity = new Vector3(
            rb.velocity.x, _jumpForce, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy head"))
        {
            Destroy(other.transform.parent.gameObject);
            _audioSources[0].Play();
        }
    }

    void Die()
    {
        _text.text = 0.ToString();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;
        _audioSources[1].Play();
        Invoke(nameof(ReloadLevel), 1.3f);
    }

    void ReloadLevel()
    {
        _text.text = HealthPoints.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    bool IsGrounded() => Physics.CheckSphere(_groundCheck.position, .1f, _ground);
}
