using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyProjectile : MonoBehaviour
{
    private Rigidbody rb;

    private bool targetHit;

    public float delay = 3.0f;

    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // stick
        if (targetHit)
        {
            return;
        } else
        {
            targetHit = true;
        }

        // stop physics when stick
        rb.isKinematic = true;

        // arrow moves with target
        transform.SetParent(collision.transform);

        audioManager.PlaySFX(audioManager.targetBreak);

        Destroy(gameObject, delay);
    }
}
