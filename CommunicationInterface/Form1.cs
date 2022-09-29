/*
    Communication Interface windows App for FS19
    @author:    Tiszai Istvan(tiszaii@hotmail.com)
    @history:	2022 - 09 - 30
*/

using System;
using System.IO;
using System.Windows.Forms;
using InputSimulatorStandard.Native;
using InputSimulatorStandard;

namespace CommunicationInterface
{
    public partial class Form1 : Form
    {
        private InputSimulator simulator;
       
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            simulator = new InputSimulator();
        }

        private void writeBtn_Click(object sender, EventArgs e)
        {
            using (XmlFiles _xml = new XmlFiles())
            {
                if (!_xml.Writting((int)numericUpDown.Value, wtextBx.Text))
                {
                    error_lbl.Text = "Not started FarmingSimulator2019, or AppToFS19.xml file writting failer!";                   
                }
                else
                {
                    simulator.Keyboard.KeyDown(VirtualKeyCode.VK_1);                   
                    simulator.Keyboard.KeyUp(VirtualKeyCode.VK_1);
                    error_lbl.Text = "";
                    MessageBox.Show("AppToFS19.xml file writting success!", "GOOD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (File.Exists(XmlFiles.xmlFS19ReadingFileName))
            {
                using (XmlFiles _xml = new XmlFiles())
                {                    
                    Tuple<string, string> _tuple = _xml.Reading();
                    if (_tuple.Item1 == "-1")
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            error_lbl.Text = "Not started FarmingSimulator2019, or FS19ToApp.xml not can reading!";
                        }));                       
                    }
                    else
                    {
                        this.Invoke(new MethodInvoker(() =>
                        {
                            rnumberBx.Text = _tuple.Item1;
                            rtextBx.Text = _tuple.Item2;
                            error_lbl.Text = "";
                        }));
                    }
                }
            }
        }
    }
}
