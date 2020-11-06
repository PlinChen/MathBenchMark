using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour
{
    void Start()
    {
        StartCoroutine( MathTest(
            //()=>gameObject.AddComponent<ConverterTest>()
        ));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator AccuTest(UnityEngine.Events.UnityAction action = null)
    {
        float delta = 0;
        for (float i = 0; i < 10; i += 0.001f)
        {
            delta += Mathf.Abs(MyCos(i) - Mathf.Cos(i));
        }
        Debug.Log("Single Cos Average mistake is : " +  (delta / 10000));
        yield return null;

        delta = 0;
        for (float i = 0; i < 10; i += 0.01f)
        {
            delta += Mathf.Abs(MySin(i) - Mathf.Sin(i));
        }
        Debug.Log("Single Sin Average mistake is : " + (delta / 10000));
        yield return null;

        delta = 0;
        for (float i = 0; i < 10; i += 0.001f)
        {
            delta += Mathf.Abs((float)CosDouble(i) - Mathf.Cos(i));
        }
        Debug.Log("Double Cos Average mistake is : " + (delta / 10000));
        yield return null;

        delta = 0;
        for (float i = 0; i < 10; i += 0.01f)
        {
            delta += Mathf.Abs((float)SinDouble(i) - Mathf.Sin(i));
        }
        Debug.Log("Double Sin Average mistake is : " + (delta / 10000));
        yield return null;

        action?.Invoke();
    }

    IEnumerator MathTest(UnityEngine.Events.UnityAction action = null)
    {
        System.DateTime time = System.DateTime.Now;
        System.DateTime newtime = System.DateTime.Now;
        // Mathf 三角函数
        float x = 0, y = 0, z = 0;
        for (int i = 0; i < 2048; i++)
        {
            for (int j = 0; j < 2048; j++)
            {
                x = 128 + Mathf.Sin(x * 0.11f) * 127;
                y = 128 + Mathf.Cos(y * 0.11f) * 127;
                z = 128 + Mathf.Sin(z * 0.11f) * 127;
            }
        }
        //计时
        newtime = System.DateTime.Now;
        //Debug.Log("Result: " + x + ", " + y + ", " + z);
        TestLogger.OutputResult("UnityEngine.Mathf Trigonometric Time Cost :  " , (newtime - time).TotalMilliseconds, true);
        yield return x + y + z;

        // System.Math 三角函数
        time = newtime;
        x = 0; y = 0; z = 0;
        for (int i = 0; i < 2048; i++)
        {
            for (int j = 0; j < 2048; j++)
            {
                x = 128 + (float)System.Math.Sin(x * 0.11f) * 127;
                y = 128 + (float)System.Math.Cos(y * 0.11f) * 127;
                z = 128 + (float)System.Math.Sin(z * 0.11f) * 127;
            }
        }
        //计时
        newtime = System.DateTime.Now;
        Debug.Log("Result: " + x + ", " + y + ", " + z);
        TestLogger.OutputResult("System.Math Trigonometric Time Cost :  " , (newtime - time).TotalMilliseconds);
        yield return x + y + z;

        // Talor 三角函数
        time = System.DateTime.Now;
        x = 0; y = 0; z = 0;
        for (int i = 0; i < 2048; i++)
        {
            for (int j = 0; j < 2048; j++)
            {
                x = 128 + MySin(x * 0.11f) * 127;
                y = 128 + MyCos(y * 0.11f) * 127;
                z = 128 + MySin(z * 0.11f) * 127;
            }
        }
        //计时
        newtime = System.DateTime.Now;
        Debug.Log("Result: " + x + ", " + y + ", " + z);
        TestLogger.OutputResult("Talor  Math Trigonometric Time Cost :  " , (newtime - time).TotalMilliseconds);
        yield return x + y + z;

        action?.Invoke();
    }

    float MyCos(float rad)
    {
        return MySin(rad + 1.5707963f);
        //float rad = angle * 0.01745329252f;
        /*
        if (rad < 0)
        {
            rad = -rad;
        }
        float tp = 6.283185f;
        while (rad > tp)
        {
            rad -= tp;
        }
        float square = rad * rad;

        int step = 2;
        float level = square;
        float result = 1;
        result -= level / step;

        step *= 12;
        level *= square;
        result += level / step;

        step *= 30;
        level *= square;
        result -= level / step;

        step *= 56;
        level *= square;
        result += level / step;

        step *= 90;
        level *= square;
        result -= level / step;

        return result;
        */
    }

    float MySin(float rad)
    {
        float pi = 3.14159265f;
        float hp = 1.5707963f;
        //return MyCos(rad + 4.71238898f);
        if (rad < 0)
        {
            return -MySin(-rad);
        }

        float tp = 6.2831853f;
        while (rad > tp)
        {
            rad -= tp;
        }

        if (rad > pi)
        {
            return -MySin(tp - rad);
        }

        if (rad > hp)
        {
            return MySin(pi - rad);
        }

        float square = rad * rad;
        float level = rad;
        float result = rad;

        int step = 6;
        level *= square;
        result -= level / step;

        step *= 20;
        level *= square;
        result += level / step;

        step *= 42;
        level *= square;
        result -= level / step;

        step *= 72;
        level *= square;
        result += level / step;

        step *= 110;
        level *= square;
        result -= level / step;

        //step *= 156;
        //level *= square;
        //result += level / step;

        return result;
    }

    double CosDouble(double rad)
    {
        return SinDouble(rad + 1.5707963267949);
    }

    double SinDouble(double rad)
    {
        double pi = 3.14159265358979;
        double hp = 1.5707963267949;
        if (rad < 0)
        {
            return -SinDouble(-rad);
        }

        float tp = 6.2831853f;
        while (rad > tp)
        {
            rad -= tp;
        }

        if (rad > pi)
        {
            return -SinDouble(tp - rad);
        }

        if (rad > hp)
        {
            return SinDouble(pi - rad);
        }

        double square = rad * rad;
        double level = rad;
        double result = rad;

        int step = 6;
        level *= square;
        result -= level / step;

        step *= 20;
        level *= square;
        result += level / step;

        step *= 42;
        level *= square;
        result -= level / step;

        step *= 72;
        level *= square;
        result += level / step;

        step *= 110;
        level *= square;
        result -= level / step;

        //step *= 156;
        //level *= square;
        //result += level / step;

        return result;
    }

}
