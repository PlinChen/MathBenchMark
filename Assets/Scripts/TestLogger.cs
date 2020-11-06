using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For log on standalone
public class TestLogger : MonoBehaviour
{
    public UnityEngine.UI.Text text;

    // Start is called before the first frame update
    public static TestLogger instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        if(instance != this)
        {
            Destroy(this);
        }
    }

    public static void OutputResult(string item, long milliseconds, bool clear = false)
    {
        if (instance != null && instance.text != null)
        {
            if (clear) instance.text.text = "";
            instance.text.text += "\n" + item + " Time Cost ：" + milliseconds;
        }

        Debug.Log(item + " Time Cost ：" + milliseconds);
    }

    public static void OutputResult(string item, double milliseconds, bool clear = false)
    {
        if (instance != null && instance.text != null)
        {
            if (clear) instance.text.text = "";
            instance.text.text += "\n" + item + " Time Cost ：" + milliseconds;
        }

        Debug.Log(item + " Time Cost ：" + milliseconds);
    }
}

