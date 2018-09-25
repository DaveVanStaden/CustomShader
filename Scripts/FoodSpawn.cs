using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour {
    [SerializeField] private GameObject food;
    private float waitTime;
	// Use this for initialization
	void Start () {
        waitTime = 3f;
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Spawn()
    {
        Instantiate(food, new Vector3(Random.Range(-5f,5.5f),1.65f,Random.Range(-5f,4.5f)), Quaternion.identity);
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        Spawn();
    }
}
