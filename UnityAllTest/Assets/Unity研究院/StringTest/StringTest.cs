using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringTest : MonoBehaviour {

	void Start ()
	{
	    Debug.Log(string.Format("{0:##.000}",120000));
        Debug.Log(string.Format("{0:t}",System.DateTime.Now));
        Debug.Log(System.DateTime.Now);
        //比较两个指定的 string 对象，并返回一个表示它们在排列顺序中相对位置的整数。但是，如果布尔参数为真时，该方法不区分大小写。
        Debug.Log(string.Compare("aabbcc","aabbcc",true));
        //返回一个表示指定 string 对象是否出现在字符串中的值。
        Debug.Log("adfadfa".Contains("a"));
        Debug.Log("a,b,c,d".Split(new char[] {','},1));
	}
	
	
}
