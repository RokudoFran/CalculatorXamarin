using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorXamarin
{
    public partial class MainPage : ContentPage
    {
        double firstNumber=0, secondNumber=0;
        string marthOperator;
        string conteinerNumber;
        int A = 0;

        public MainPage()
        {
            InitializeComponent();
            Clear(this, null);
        }

        void SelectNumber(object select, EventArgs e)
        {
            Button button = (Button)select;

            if (A==0)
            {
                conteinerNumber = button.Text.ToString();
                this.resultText.Text = conteinerNumber;
                firstNumber = Convert.ToDouble(conteinerNumber);
            }
            else
            {
                conteinerNumber = button.Text.ToString();
                this.resultText.Text  += conteinerNumber;
                secondNumber = Convert.ToDouble(conteinerNumber);
            }

        }

        void SelectOperator(object select, EventArgs e)
        {
            if (firstNumber != 0)
            {
                A = 1;
                Button button = (Button)select;
                marthOperator = button.Text;
                this.resultText.Text += marthOperator;
            }
        }

        public static double Calculate(double value1, double value2, string mathOperator)
        {
            double result = 0;

            switch (mathOperator)
            {
                case "÷":
                    result = value1 / value2;
                    break;
                case "×":
                    result = value1 * value2;
                    break;
                case "+":
                    result = value1 + value2;
                    break;
                case "-":
                    result = value1 - value2;
                    break;
            }

            return result;
        }

        void Calculate (object sender, EventArgs e)
        {
            if (firstNumber!=0 && secondNumber!=0)
            {
                var result = Calculate(firstNumber, secondNumber, marthOperator);

                this.resultText.Text = result.ToString();
                firstNumber = Convert.ToDouble(result);
            }
        }

        void Clear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            A = 0;
            this.resultText.Text = "0";
        }
    }
}
