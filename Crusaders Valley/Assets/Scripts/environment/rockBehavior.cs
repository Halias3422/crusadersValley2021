using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockBehavior : MonoBehaviour
{
    private int rockHealth;
    private int miningDirection;
    private float miningTimeElapsed;
    private bool firstRockSwing;
    private bool rockMined;
    private float miningLerpDuration;
    private Vector3 rockPos;
    // Start is called before the first frame update
    void Start()
    {
        rockHealth = 60;
        miningLerpDuration = 0.05f;
        rockPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rockMined == true)
            rockBeingMinedReaction();        
    }

    void    rockBeingMinedReaction()
    {
        if (firstRockSwing == false && miningTimeElapsed < miningLerpDuration)
        {
            transform.localPosition = Vector3.Lerp(rockPos, new Vector3(rockPos.x + 0.05f * miningDirection, rockPos.y, 0), miningTimeElapsed / miningLerpDuration);
            miningTimeElapsed += Time.deltaTime;
        }
        else if (firstRockSwing == false && miningTimeElapsed >= miningLerpDuration)
        {
            firstRockSwing = true;
            miningTimeElapsed = 0;
            if (rockHealth <= 0)
                Destroy(this.gameObject, 0);
        }
        else if (firstRockSwing == true && ((miningDirection > 0 && transform.localPosition.x > 0f) ||
        (miningDirection < 0 && transform.localPosition.x < 0f)))
        {
            transform.localPosition = Vector3.Lerp(new Vector3(rockPos.x + 0.05f * miningDirection, rockPos.y, 0), rockPos, miningTimeElapsed / miningLerpDuration);
            miningTimeElapsed += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<toolAttributes>() && other.gameObject.GetComponent<toolAttributes>().toolType == ("pickaxe") &&
        other.gameObject.transform.parent.transform.parent.GetComponent<playerUsingTool>().toolHitObject == false)
        {
            if (other.gameObject.transform.position.x >= transform.position.x)
                miningDirection = -1;
            else
                miningDirection = 1;
            other.gameObject.transform.parent.transform.parent.GetComponent<playerUsingTool>().toolHitObject = true;
            rockHealth -= other.gameObject.GetComponent<toolAttributes>().toolDamage;
            miningTimeElapsed = 0;
            firstRockSwing = false;
            rockMined = true;

        }
    }
}
