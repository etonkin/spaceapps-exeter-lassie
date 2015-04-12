using System;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace EV3Windows
{
    public partial class MainForm : Form
    {
        private Brick brick;
        private BluetoothCommunication _conType;

        private bool robotIsConcerned = false;
        private bool signIsFacingAstronaut = false;

        public MainForm()
        {
            InitializeComponent();

            string[] ports = SerialPort.GetPortNames();
            comPortsComboBox.Items.AddRange(ports);
            comPortsComboBox.SelectedIndex = comPortsComboBox.Items.Count - 1;

            //brick.SystemCommand.CopyFileAsync("Panic.rsf","apps/Panic.rsf");
            //brick.SystemCommand.CopyFileAsync("Phew.rsf", "apps/Phew.rsf");
        }

        private void buttonFlashLed_Click(object sender, EventArgs e)
        {
            FlashLeds();
        }

        private void FlashLeds()
        {
            brick.DirectCommand.SetLedPatternAsync(LedPattern.RedFlash);
        }

        private async void WriteOutText()
        {
            //await brick.DirectCommand.DrawFillWindowAsync(Lego.Ev3.Core.Color.Foreground, 0, 100);
            await brick.DirectCommand.CleanUIAsync();
            await brick.DirectCommand.DrawTextAsync(Lego.Ev3.Core.Color.Background, 20, 20, textBox2.Text);
            await brick.DirectCommand.UpdateUIAsync();
        }

        private async void Connect()
        {
            _conType = new BluetoothCommunication(comPortsComboBox.SelectedItem.ToString());

            brick = new Brick(_conType, true);
            brick.BrickChanged += brickChanged;
            try
            {
                await brick.ConnectAsync();
                outputTextBox.AppendText("Connected" + Environment.NewLine);
                brick.Ports[InputPort.Four].SetMode(InfraredMode.Seek);
            }
            catch (Exception)
            {
                outputTextBox.AppendText("Could not connect" + Environment.NewLine);
            }
        }

        private void brickChanged(object sender, BrickChangedEventArgs e)
        {
            //outputTextBox.AppendText("Something happened");
            Track();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await brick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.All, 50, 300, true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WriteOutText();
        }

        private void buttonAlright_Click(object sender, EventArgs e)
        {
            //Motor D rotates sign, Motor A waves it

            //Rotate sign to face astronaut
            RotateSign();

            do
            {
                WaveSign();
                FlashLeds();
                Thread.Sleep(2000);
            } while (robotIsConcerned);
        }

        private void RotateSign()
        {
            if (signIsFacingAstronaut)
            {
                brick.DirectCommand.SetMotorPolarity(OutputPort.D, Polarity.Forward);
                brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.D, 50, 250, true);
                signIsFacingAstronaut = false;
            }
            else
            {
                brick.DirectCommand.SetMotorPolarity(OutputPort.D, Polarity.Backward);
                brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.D, 50, 250, true);
                signIsFacingAstronaut = true;
            }
        }

        private async void WaveSign()
        {
            //await brick.DirectCommand.SetMotorPolarity(OutputPort.A, Polarity.Forward);
            //await brick.DirectCommand.StepMotorAtPowerAsync(OutputPort.A, 50, 0, 50, 0, true);
            //Thread.Sleep(1000);
            //for (var i = 0; i < 5; i++)
            //{
            //    await brick.DirectCommand.SetMotorPolarity(OutputPort.A, Polarity.Opposite);
            //    await brick.DirectCommand.StepMotorAtPowerAsync(OutputPort.A, 50, 0, 30, 0, true);
            //    Thread.Sleep(1000);
            //}
            //await brick.DirectCommand.SetMotorPolarity(OutputPort.A, Polarity.Opposite);
            //await brick.DirectCommand.StepMotorAtPowerAsync(OutputPort.A, 50, 0, 15, 0, false);
            //Thread.Sleep(1000);

            try
            {
                await brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.A, 10, 200, true);
                Thread.Sleep(350);
                for (var i = 0; i < 5; i++)
                {
                    await brick.DirectCommand.SetMotorPolarity(OutputPort.A, Polarity.Opposite);
                    await brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.A, 10, 400, true);
                    Thread.Sleep(550);
                }
                await brick.DirectCommand.SetMotorPolarity(OutputPort.A, Polarity.Opposite);
                await brick.DirectCommand.TurnMotorAtSpeedForTimeAsync(OutputPort.A, 10, 200, false);
                Thread.Sleep(350); //Todo Remove sleep hacks from all over the place
            }
            catch (Exception ex)
            {
                //Don't panic, you probably forgot to connect
                outputTextBox.AppendText(ex.Message);
            }
        }

        private void buttonWave_Click(object sender, EventArgs e)
        {
            WaveSign();
        }

        private void buttonRotate_Click(object sender, EventArgs e)
        {
            RotateSign();
        }

        private async void buttonBrakesOff_Click(object sender, EventArgs e)
        {
            await brick.DirectCommand.StopMotorAsync(OutputPort.All, false);
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            brick.Disconnect();
        }

        private void buttonLedOff_Click(object sender, EventArgs e)
        {
            StopLeds();
        }

        private void StopLeds()
        {
            brick.DirectCommand.SetLedPatternAsync(LedPattern.Black);
        }

        private void buttonRunAway_Click(object sender, EventArgs e)
        {
            RunAway();
        }

        private async void RunAway()
        {
            brick.BatchCommand.SetMotorPolarity(OutputPort.B, Polarity.Forward);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.B, 30, 5000, true);
            brick.BatchCommand.SetMotorPolarity(OutputPort.C, Polarity.Backward);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, 30, 5000, true);
            await brick.BatchCommand.SendCommandAsync();

            Thread.Sleep(5000);

            brick.BatchCommand.SetMotorPolarity(OutputPort.B, Polarity.Backward);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.B, 30, 500, true);
            brick.BatchCommand.SetMotorPolarity(OutputPort.C, Polarity.Forward);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, 30, 500, true);
            await brick.BatchCommand.SendCommandAsync();

            Thread.Sleep(500);

            brick.BatchCommand.SetMotorPolarity(OutputPort.B, Polarity.Forward);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.B, 50, 2000, true);
            brick.BatchCommand.TurnMotorAtPowerForTime(OutputPort.C, 50, 2000, true);
            await brick.BatchCommand.SendCommandAsync();
        }

        private async void buttonPushImage_Click(object sender, EventArgs e)
        {
            await brick.DirectCommand.DrawImageAsync(Color.Foreground, 0, 0, "Astronaut");
            await brick.DirectCommand.UpdateUIAsync();
        }

        private async void buttonPanic_Click(object sender, EventArgs e)
        {
            await brick.DirectCommand.PlaySoundAsync(100, "prjs/LassieProject/Panic");
        }

        private async void buttonPhew_Click(object sender, EventArgs e)
        {
            await brick.DirectCommand.PlaySoundAsync(100, "prjs/Phew");
        }

        private void Track()
        {
            var d = brick.Ports[InputPort.Four].PercentValue;
            var n = brick.Ports[InputPort.Four].Name;
            labelTrack.Text = String.Format("IR Dir: Sensor {0} - {1}°", n, d);
        }

        private void buttonCloseIn_Click(object sender, EventArgs e)
        {
            CloseIn();
        }

        private void CloseIn()
        {
            throw new NotImplementedException();
        }
    }
}
