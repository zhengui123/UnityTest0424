using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWebTime : MonoBehaviour {

    public int year, mouth, day, hour, min, sec;

    public string timeURL = "http://cgi.im.qq.com/cgi-bin/cgi_svrtime";

    void Start()
    {
        StartCoroutine(GetTime());
    }

    IEnumerator GetTime()
    {
        WWW www = new WWW(timeURL);
        while (!www.isDone)
        {
            yield return www;
        }
        SplitTime(www.text);
    }

    void SplitTime(string dateTime)
    {
        dateTime = dateTime.Replace("-", "|");
        dateTime = dateTime.Replace(" ", "|");
        dateTime = dateTime.Replace(":", "|");
        string[] Times = dateTime.Split('|');
        year = int.Parse(Times[0]);
        mouth = int.Parse(Times[1]);
        day = int.Parse(Times[2]);
        hour = int.Parse(Times[3]);
        min = int.Parse(Times[4]);
        sec = int.Parse(Times[5]);
    }
  

}
