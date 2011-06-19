using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace CID_USB_BaseStation
{
    class DataLogger
    {
        private static DataLogger instance;
        private bool isFileOpened = false;
        private string fileName = "";
        private StreamWriter sWrite = null;
        private UInt32 numValuesWritten = 0;

        public string FileName { get { return fileName; } }
        public bool LoggingActivated { get { return isFileOpened; } }
        public UInt32 NumValuesWritten { get { return numValuesWritten; } }

        public void Start(string fileName)
        {
            if (isFileOpened)
            {
                sWrite.Close(); // Close any previously opened files
            }
            numValuesWritten = 0;
            
            try
            {
                sWrite = new StreamWriter(fileName, false);
                this.fileName = fileName;
                isFileOpened = true;
            }
            catch (Exception ioe)
            {
                MessageBox.Show("Unable to create: " + fileName+ ": " + ioe.Message);
                this.fileName = "";
                this.isFileOpened = false;
            }
        }

        public void Stop()
        {
            if (isFileOpened)
            {
                numValuesWritten = 0;
                isFileOpened = false;
                fileName = "";
                sWrite.Close();
            }
        }

        public static DataLogger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataLogger();
                }
                return instance;
            }
        }

        public void LogLine(string data)
        {
            if (isFileOpened)
            {
                sWrite.WriteLine(data);
                ++numValuesWritten;
            }
        }

        public void LogLine(int data)
        {
            if (isFileOpened)
            {
                sWrite.WriteLine(data);
                ++numValuesWritten;
            }
        }

        private DataLogger() { }

        private DataLogger(string filename)
        {
            instance.fileName = fileName;
        }
    }
}
