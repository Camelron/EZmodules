using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshake : MonoBehaviour
{
    public int shakeCount;
    public float shakeInterval;
    public float shakeMagnitude;


    private static Object theLock = new Object();
    private static Coroutine shakeInstance; // ensures only one screenshake routine is wobbling the camera
    // Start is called before the first frame update
    
    void Update()
    {
        // placeholder code; you can change the cause to be whatever you want!
        // you should respect the shakeInstance; only start the routine if the shakeInstance is null!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            lock (theLock)
            {
                if (shakeInstance == null && Input.GetKeyDown(KeyCode.Space))
                {
                    shakeInstance = StartCoroutine("Shake");
                }
            }
        }
    }

    private IEnumerator Shake()
    {
        Vector3 origPos = Camera.main.transform.localPosition;
        for (int i = 0; i < shakeCount; i++)
        {
            Vector2 offset = Random.insideUnitCircle * shakeMagnitude;
            Camera.main.transform.localPosition = origPos + (new Vector3(offset.x, offset.y));
            yield return new WaitForSeconds(shakeInterval);
        }
        Camera.main.transform.localPosition = origPos;
        shakeInstance = null;
    }
}
