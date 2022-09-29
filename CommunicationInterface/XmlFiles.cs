/*
    Communication Interface windows App for FS19
    @author:    Tiszai Istvan(tiszaii@hotmail.com)
    @history:	2022 - 09 - 30
*/

using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace CommunicationInterface
{  
    public class XmlFiles : IDisposable
    {
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);       
        private string xmlFS19WrittingFileName = Program.DRIVER + "AppToFS19.xml";
        static public string xmlFS19ReadingFileName = Program.DRIVER + "FS19ToApp.xml";        

        #region public functions 
        public XmlFiles ()
        {
        }

        //-----------------------
        public void Dispose()
        {
        }

        //-----------------------
        public bool Writting(int number_a, string text_a)
        {
            Process _proc = Process.GetProcessesByName("FarmingSimulator2019Game").FirstOrDefault();
            if (_proc != null)
            {
                IntPtr h = _proc.MainWindowHandle;
                SetForegroundWindow(h);
            }
            else
            {
                return false;
            }

            bool _result = false;
            XmlWriter _xmlWriter = null;
            try
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.NewLineOnAttributes = false;
                xmlWriterSettings.Indent = true;
                _xmlWriter = XmlWriter.Create(xmlFS19WrittingFileName, xmlWriterSettings);
                _xmlWriter.WriteStartDocument();
                _xmlWriter.WriteStartElement("AppToFS19");
                _xmlWriter.WriteAttributeString("text", text_a);
                _xmlWriter.WriteAttributeString("number", number_a.ToString());
                _xmlWriter.WriteEndElement();                  
                _xmlWriter.WriteEndDocument();
                _xmlWriter.Close();          
                _result = true;
            }
            catch (Exception msg)
            {
                if (_xmlWriter != null)
                {
                    _xmlWriter.Close();
                }
            }
            return _result;
        }

        //-----------------------
        public Tuple<string, string> Reading()
        {
            XmlTextReader _reader = null;
            string _number = "";           
            string _text = "";
            int _numberInt = -1;

            try
            {
                string _element;
                _reader = new XmlTextReader(xmlFS19ReadingFileName);                

                while (_reader.Read())
                {
                    switch (_reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            _element = _reader.Name;
                            while (_reader.MoveToNextAttribute())
                            {
                                if (_reader.Name.Equals("text"))
                                {
                                    _text = _reader.Value;
                                    
                                }
                                else
                                if (_reader.Name.Equals("number"))
                                {
                                    _number = _reader.Value;                                   
                                }
                            }
                            break;
                        case XmlNodeType.Text:
                            break;
                        case XmlNodeType.EndElement:
                            break;
                    }
                }
                _reader.Close();
                if (!String.IsNullOrEmpty(_number))
                {
                    try
                    {
                        _numberInt = Int32.Parse(_number);
                        return Tuple.Create(_number, _text);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show($"XML.reading():Unable to convert '{_reader.Value}'.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (OverflowException)
                    {
                        MessageBox.Show($"XML.reading():'{_reader.Value}' is out of range of the Int32 type. '{_reader.Value}'.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return Tuple.Create("-1", "");
                }
            }
            catch (Exception msg)
            {
                if (_reader != null)
                {
                    _reader.Close();
                }
                MessageBox.Show($"XML.reading(): ' {msg}'.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            return Tuple.Create("-1", "");
        }
        #endregion

        #region private functions 
        #endregion
    }
}