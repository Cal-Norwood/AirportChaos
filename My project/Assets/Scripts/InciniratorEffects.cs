using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InciniratorEffects : MonoBehaviour
{
    public ParticleSystem PS;
    ParticleSystem.MainModule ma;
    private Color defColor;
    // Start is called before the first frame update
    void Start()
    {
        ma = PS.main;
        defColor = ma.startColor.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.gameObject.layer == 11)
        {
            StartCoroutine(Roar());
        }

        if (other.gameObject.transform.parent.gameObject.layer == 10)
        {
            StartCoroutine(RoarBadEnding());
        }
    }

    private IEnumerator Roar()
    {
        var emmision = PS.emission;
        emmision.rateOverTime = 100000;
        yield return new WaitForSeconds(1.5f);
        emmision.rateOverTime = 10000;
    }

    private IEnumerator RoarBadEnding()
    {
        var emmision = PS.emission;
        emmision.rateOverTime = 100000;
        ma.startColor = Color.black;
        yield return new WaitForSeconds(1.5f);
        emmision.rateOverTime = 10000;
        yield return new WaitForSeconds(1);
        ma.startColor = defColor;
    }
}
