using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public GameObject[] greenChecks;
    public GameObject[] redChecks;
    public Image[] progressBar;

    private int currentGreenProgress = 0;
    private int currentRedProgress = 0;
    [SerializeField] private int totalGreenProgress = 0;
    [SerializeField] private int totalRedProgress = 0;

    public GameObject incinirator;
    public GameObject safeCollector;

    public Image passMarker;

    public Transform[] bagSpawn;

    public GameObject safeBag;
    public GameObject contrabandBag;

    public Image Timer;

    private bool quotaReached = false;

    public int bagMax;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RoundTimer());
        StartCoroutine(BagSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator RoundTimer()
    {
        for (float i = 0; i < 120; i++)
        {
            var alphaVal = Timer.color;
            if(i < 105)
            {
                alphaVal.a = i / 765;
            }
            else
            {
                alphaVal.a += 0.058f;
            }
            Timer.color = alphaVal;
            yield return new WaitForSeconds(1f);
            Debug.Log(alphaVal.a);
        }
        Debug.Log("RoundsOver");
    }

    private IEnumerator BagSpawner()
    {
        for(int i = 0; i < bagMax; i++)
        {
            BagAndPositionSelection();
            yield return new WaitForSeconds(15);
        }
    }

    public void GreenProgress()
    {
        greenChecks[currentGreenProgress].SetActive(true);
        currentGreenProgress++;
        currentRedProgress++;
        totalGreenProgress++;

        if(totalGreenProgress == 4)
        {
            quotaReached = true;
            foreach(Image i in progressBar)
            {
                i.color = Color.green;
            }
        }
    }

    public void RedProgress()
    {
        redChecks[currentRedProgress].SetActive(true);
        currentRedProgress++;
        currentGreenProgress++;
        totalRedProgress++;

        if (totalRedProgress == 4)
        {
            foreach (Image i in progressBar)
            {
                i.color = Color.red;
            }
        }

        if(quotaReached == false)
        {
            if (totalRedProgress < 4)
            {
                passMarker.rectTransform.position = passMarker.rectTransform.position + new Vector3(100, 0, 0);
            }
        }
    }

    private void BagAndPositionSelection()
    {
        int randomBagPick = Random.Range(0, 2);
        int randomBagSpawn = Random.Range(0, 5);
        switch (randomBagPick)
        {
            case 0:
                Instantiate(safeBag, bagSpawn[randomBagSpawn].position, Quaternion.identity);
                break;

            case 1:
                Instantiate(contrabandBag, bagSpawn[randomBagSpawn].position, Quaternion.identity);
                break;
        }
    }
}
