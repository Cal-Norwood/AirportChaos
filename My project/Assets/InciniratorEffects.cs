using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InciniratorEffects : MonoBehaviour
{
    public ParticleSystem PS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Roar());
    }

    private IEnumerator Roar()
    {
        var emmision = PS.emission;
        emmision.rateOverTime = 100000;
        yield return new WaitForSeconds(1.5f);
        emmision.rateOverTime = 10000;
    }
}
