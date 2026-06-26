using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVtoData : MonoBehaviour
{
    public static CSVtoData instance;

    public TextAsset csvFile;
    //public static string csvPath = "/CSV/Updated Features MFW - Sheet1.csv";

    private void Start()
    {
        instance = this;
    }

    public string GetString(string titleName)
    {
        string[] allData = csvFile.ToString().Split('\n');
        foreach (string s in allData)
        {
            string[] spliteData = s.Split(',');
            if (titleName.ToLower() == spliteData[0].ToLower())
            {
                //Debug.Log(spliteData[0] + " = " + spliteData[1] + " = " + spliteData[2]);
                return s;
            }

        }
        return null;
    }

    public List<string> LoadAllTitle()
    {
        List<string> titles = new List<string>();
        string[] allData = csvFile.ToString().Split('\n');
        foreach (string s in allData)
            titles.Add(s.Split(',')[0]);

        return titles;
    }
}
