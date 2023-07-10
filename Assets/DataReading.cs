using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AwesomeCharts;
using System.IO;

public class DataReading : MonoBehaviour
{
    public LineChart chart;
    
    string[] data;
    void Start()
    {
        ReadFile();
    }

    void ReadFile()
    {
        data = File.ReadAllLines("D:/Blender/Projects_NonModding/CGL_StudentLife/UnityProjects/DrinkTracker/Assets/Resources/sellTimestamp.csv");
        LineDataSet dataSet = new LineDataSet();

        int lastTime = 0;
        float drinkCounter = 0;
        int positionCounter = 0;

        for(int i = 0;i < data.Length;i++)
        {
            int minute = int.Parse(data[i].Split(',')[1].Split(' ')[1].Split(':')[1]);
            int Hour = int.Parse(data[i].Split(',')[1].Split(' ')[1].Split(':')[0]);
            int time = Hour*60 + minute;

            if(time - lastTime > 30)
            {
                lastTime = time;
                dataSet.AddEntry(new LineEntry(positionCounter, drinkCounter));

                drinkCounter = 0;
                positionCounter++;
            }
            else
            {
                drinkCounter++;
            }
        }

        chart.GetChartData().DataSets.Add(dataSet);
        chart.SetDirty();
    }
}
