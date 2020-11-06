using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tested， Nothing Important
/// </summary>
[System.Obsolete("Obselete")]
public class ConverterTest : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(WrapTest());
    }

    IEnumerator WrapTest(UnityEngine.Events.UnityAction action = null)
    {
        System.DateTime time = System.DateTime.Now;
        System.DateTime newtime = System.DateTime.Now;

        //Test double2double
        double dv = 0;
        for (double i = 0; i < 100; i++)
        {
            dv = DoubleReturnDouble(i);
        }
        newtime = System.DateTime.Now;
        TestLogger.OutputResult("In Double Out Double_  ", (newtime - time).Milliseconds);//
        yield return dv;

        //Test float2float
        time = System.DateTime.Now;
        float fv = 0;
        for (float i = 0; i < 100; i++)
        {
            fv = FloatReturnFloat(i);
        }
        newtime = System.DateTime.Now;
        TestLogger.OutputResult("In Float Out Float_  ", (newtime - time).Milliseconds);
        yield return fv;

        //Test warpped
        time = System.DateTime.Now;
        fv = 0;
        for (float i = 0; i < 100; i++)
        {
            fv = WrapD2D_F2F(i);
        }
        newtime = System.DateTime.Now;
        TestLogger.OutputResult("Wrapped Double To Float_  ", (newtime - time).Milliseconds);
        yield return fv;

        //Test convert
        time = System.DateTime.Now;
        fv = 0;
        for (float i = 0f; i < 100; i++)
        {
            fv = (float)DoubleReturnDouble(i);
        }
        newtime = System.DateTime.Now;
        TestLogger.OutputResult("Convert Double To Float_  ", (newtime - time).Milliseconds);
        yield return fv;

        action?.Invoke();
    }

    float WrapD2D_F2F(float a)
    {
        return (float)DoubleReturnDouble(a);
    }

    float FloatReturnFloat(float a)
    {
        for (int i = 0; i < 1000000; i++)
        {
            a += i * 0.5f;
        }
        return a / 2;
    }

    //float DoubleReturnFloat(double a)
    //{
    //    for (int i = 0; i < 1000000; i++)
    //    {
    //        a += i * 0.5;
    //    }
    //    return (float)a / 2;
    //}

    double DoubleReturnDouble(double a)
    {
        for (int i = 0; i < 1000000; i++)
        {
            a += i * 0.5;
        }
        return a / 2;
    }
}
