using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
using System.Threading.Tasks;
public class ReadMicrobit : MonoBehaviour
{
    private SerialPort serial; // Start is called before the first frame update
    public int yAxis
    {
        get { return y; }

    }
    public bool ButtonPressed
    {
        get { return button; }

    }
    public bool ButtonPressedB
    {
        get { return buttonB; }

    }
    public int xAxis
    {
        get { return x; }

    }
    private int x;
    private bool button;
    private bool buttonB;
    private int y;

    public bool continueReading = true;
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
        //serial.ReadTimeout = 100;
        serial.Open();

       // ReadSerial();
    }

    private void Update()
    {
        ParseSerial();
    }

    public async void ReadSerial()
    {
        while (continueReading)
        {
        ParseSerial();
        await Task.Delay(20);

        }
    }
    public async void ParseSerial()
    {
        string data = serial.ReadLine();
        //Debug.Log(data); //string waardes halen converten naar int

        if (data.Contains("X:"))
        {
            string substr;
            int index = data.IndexOf("X:") + 2;
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
            //Debug.Log($"X: {substr}");
        }
        //int y;

        if (data.Contains("Y:"))
        {
            string substr;
            int index = data.IndexOf("Y:") + 2; //gets index out of array
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

            //Debug.Log($"Y: {substr}");
        }
        if (data.Contains("G:"))
        {
            string substr;
            int index = data.IndexOf("G:") + 2;
            int end = data.IndexOf('|', index);

            if (end == -1)
            {
                substr = data.Substring(index);
            }
            else
            {
                substr = data.Substring(index, end - index);
            }
            button = bool.Parse(substr);
            //  Debug.Log($"Button: {substr}");
        }
        if (data.Contains("B:"))
        {
            string substr;
            int index = data.IndexOf("B:") + 2;
            int end = data.IndexOf('|', index);

            if (end == -1)
            {
                substr = data.Substring(index);
            }
            else
            {
                substr = data.Substring(index, end - index);
            }
            buttonB = bool.Parse(substr);
            // Debug.Log($"ButtonB: {substr}");
        }
    }
    
}

