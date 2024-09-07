using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnScript : MonoBehaviour
{
    public GameObject target;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    public float distanceOffset = 10;

    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        spawnTarget();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.finished)
        {
            return;
        }
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        } else
        {
            spawnTarget();
            timer = 0;
        }
    }

    void spawnTarget()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        float leftestPoint = transform.position.x - distanceOffset;
        float rightestPoint = transform.position.x + distanceOffset;

        Instantiate(target, new Vector3(Random.Range(leftestPoint, rightestPoint), Random.Range(lowestPoint, highestPoint), transform.position.z), Quaternion.Euler(90, 0, 0));
    }
}
