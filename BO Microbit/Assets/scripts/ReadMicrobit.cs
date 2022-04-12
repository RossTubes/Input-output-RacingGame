using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
public class ReadMicrobit : MonoBehaviour
{
    private SerialPort serial; // Start is called before the first frame update
    public int yAxis
    {
        get { return y; }

    }

    private int y;
    void Awake()
    {
        string[] portNames = SerialPort.GetPortNames();
        for (int i = 0; i < portNames.Length; i++)
        {
            Debug.Log(portNames[i]);
        }
        serial = new SerialPort();
        serial.PortName = portNames[0]; //the port from laptop to microbit
        serial.BaudRate = 115200; //communication speedrate
        serial.DataBits = 8;
        serial.StopBits = StopBits.One;
        serial.Parity = Parity.None;
        serial.Handshake = Handshake.None; //confirmation for sending

        serial.Open();
    }
    private void Update()
    {
        string data = serial.ReadLine();
        Debug.Log(data); //string waardes halen converten naar int
        int x;

        if (data.Contains("X-axis:"))
        {
            string substr;
            int index = data.IndexOf("X-axis:") + 7;
            int end = data.IndexOf('|', index);

            if (end == -1)
            {
                substr = data.Substring(index);
            }
            else
            {
                substr = data.Substring(index, end - index);
            }
            x = Int32.Parse(substr);
            Debug.Log($"X: {substr}");
        }
        //int y;

        if (data.Contains("Y-axis:"))
        {
            string substr;
            int index = data.IndexOf("Y-axis:") + 7; //gets index out of array
            int end = data.IndexOf('|', index); //get first index of character after specified index

            if (end == -1)
            {
                substr = data.Substring(index); //gets a string based on index until end of string
            }
            else
            {
                substr = data.Substring(index, end - index); //gets a string out of data on index begin and length
            }

            y = Int32.Parse(substr); //transformed string to int

            Debug.Log($"Y: {substr}");
        }
    }
}

