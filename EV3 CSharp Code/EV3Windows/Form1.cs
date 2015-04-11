using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace EV3Windows
{
    public partial class Form1 : Form
    {
        private Brick _brick;
        private BluetoothCommunication _conType;

        public Form1()
        {
            InitializeComponent();

            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FlashLeds();
        }

        private async void FlashLeds()
        {
            await _brick.DirectCommand.SetLedPatternAsync(LedPattern.Black);
            Thread.Sleep(1000);
            await _brick.DirectCommand.SetLedPatternAsync(LedPattern.GreenFlash);
            Thread.Sleep(1000);
            await _brick.DirectCommand.SetLedPatternAsync(LedPattern.Black);
        }

        private async void WriteOutText()
        {
            //await _brick.DirectCommand.DrawFillWindowAsync(Lego.Ev3.Core.Color.Foreground, 0, 100);
            await _brick.DirectCommand.CleanUIAsync();
            await _brick.DirectCommand.DrawTextAsync(Lego.Ev3.Core.Color.Background, 20, 20, textBox2.Text);
            await _brick.DirectCommand.UpdateUIAsync();
        }

        private async void Connect()
        {
            _conType = new BluetoothCommunication(comboBox1.SelectedItem.ToString());

            _brick = new Brick(_conType, true);
            _brick.BrickChanged += _brick_BrickChanged;
            try
            {
                await _brick.ConnectAsync();
                textBox1.AppendText("Connected" + Environment.NewLine);
            }
            catch (Exception)
            {
                textBox1.AppendText("Could not connect" + Environment.NewLine);
            }
        }

        private async void MotorPlayClicked()
        {
            await _brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.All, 50, 300, true);
        }

        private void _brick_BrickChanged(object sender, BrickChangedEventArgs e)
        {
            //textBox1.AppendText("Something happened");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MotorPlayClicked();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WriteOutText();
        }
    }
}
