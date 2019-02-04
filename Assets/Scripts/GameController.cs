using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float xRangeMin;
    public float xRangeMax;
    public float yRangeMin;
    public float yRangeMax;
    public float startWaitTime;
    public float timeInterval;
    
    public float gameTime;
    public GameObject Target;

    public Text totalNumberText;
    public Text hitNumberText;
    public Text hitRateText;

    private float startTime;
    private float nextTarget;
    private int targetNumber;
    private int hitNumber;

    // The method to generate target at random location on the map
    void SpawnTargets()
    {

        float xPosition = 10;
        float yPosition = 10;
        Vector3 newSpawnPosition = new Vector3(xPosition, yPosition, 0);
        Instantiate(Target, newSpawnPosition, Quaternion.identity);

    }


    // Start is called before the first frame update
    void Start()
    {
        // first target spawn is delayed
        new WaitForSeconds(startWaitTime);
        startTime = Time.time;
        nextTarget = 0;
        targetNumber = 0;

        // setup display text
        totalNumberText.text = "Total number: 0";
        hitNumberText.text = "You hit: 0";
        hitRateText.text = "Hit rate is: 0%";
    }

    // Update is called once per frame
    void Update()
    {

       // Randomly generate targets 
       if ((Time.time - startTime) < gameTime && Time.time > nextTarget)
       {
            //SpawnTargets();

            float xPosition = Random.Range(xRangeMin, xRangeMax);
            float yPosition = Random.Range(yRangeMin, yRangeMax);
            //float xPosition = 10;
            //float yPosition = 10;
            Vector3 newSpawnPosition = new Vector3(xPosition, yPosition, 0);
            Instantiate(Target, newSpawnPosition, Quaternion.identity);
            nextTarget = Time.time + timeInterval;
        
    }
       // Display results
      
            totalNumberText.text = "Total number: " + targetNumber;
            hitNumberText.text = "You hit: " + hitNumber;
            
            if (targetNumber > 0)
            {
            int hitPercent = (int)((float)hitNumber / targetNumber * 100);
            hitRateText.text = "Hit rate is: " + hitPercent + "%";
            } else
            {
                hitRateText.text = "Hit rate is: 0%";
            }
        
   }

    public int getTargetNumber()
    {
        return targetNumber;
    }

    public void HitNumberPlusOne()
    {
        hitNumber++;
    }

    public void TargetNumberAddOne()
    {
        targetNumber++;
    }
}
