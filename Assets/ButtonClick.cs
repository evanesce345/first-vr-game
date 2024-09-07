using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonClick : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    public LogicScript logic;
    
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        readyToThrow = true;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Touchscreen.current.press.isPressed && readyToThrow && totalThrows > 0 && !logic.finished)
        {
            Throw();
        }
    }

    private void Throw()
    {
        audioManager.PlaySFX(audioManager.shoot);
        readyToThrow = false;

        // create arrow
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, objectToThrow.transform.rotation);

        // get the rigidbody of the arrow
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // add force
        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        // throw cooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
