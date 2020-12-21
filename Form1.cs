using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace ReconocimientodeVoz
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine oreja = new SpeechRecognitionEngine();

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            oreja.SetInputToDefaultAudioDevice();
            oreja.LoadGrammar(new DictationGrammar());
            oreja.SpeechRecognized += Detection;
            oreja.RecognizeAsync(RecognizeMode.Multiple);

        }

        private void Detection(object sender, SpeechRecognizedEventArgs e)
        {
            textBox1.Text = e.Result.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oreja.RecognizeAsyncStop();
        }
    }
}
