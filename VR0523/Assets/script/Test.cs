using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
public class Test : MonoBehaviour

{
    [Range(-180, 180)]
    public int servoValue1;
    public int servoValue2;

    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(5, PinMode.Servo);//서보1
        UduinoManager.Instance.pinMode(3, PinMode.Servo);//서보2
    }

    // Update is called once per frame
    void Update()
    {
        UduinoManager.Instance.analogWrite(3, servoValue1);//나무향
        UduinoManager.Instance.analogWrite(5, servoValue2);//꽃향        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tree"))//나무향
        {
            StartCoroutine(ResetAngle());
        }
        if (other.gameObject.CompareTag("flower"))//꽃향
        {
            StartCoroutine(ReStart());
        }
    }

    public IEnumerator ResetAngle()//한번만 분사 
    {
        servoValue2 = 0;
        yield return new WaitForSeconds(1.0f);
        servoValue2 = 90;
        yield return new WaitForSeconds(1.0f);
    }
    public IEnumerator ReStart()
    {
        servoValue1 = 0;
        yield return new WaitForSeconds(1.0f);
        servoValue1 = 90;
        yield return new WaitForSeconds(1.0f);
    }
}