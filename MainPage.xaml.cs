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
        string mathOperator;
        int currentState = 1;
        string conteiner1, conteiner2;

        public MainPage()
        {
            InitializeComponent();
            Clear(this, null);
        }

        void SelectNumber(object select, EventArgs e)
        {
            Button button = (Button)select;
            string pressed = button.Text;

            if (this.resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            this.resultText.Text += pressed;

            double number;
            if (double.TryParse(this.resultText.Text, out number))
            {
                this.resultText.Text = number.ToString("");
                if (currentState == 1)
                {
                    firstNumber = number;
                    this.operationText.Text = firstNumber.ToString();
                    conteiner1 = firstNumber.ToString();
                }
                else
                {
                    secondNumber = number;
                    this.operationText.Text = conteiner1+conteiner2+secondNumber.ToString() ;
                }
            }
            

        }

        void SelectOperator(object select, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)select;
            string pressed = button.Text;
            mathOperator = pressed;
            this.operationText.Text =conteiner1 + mathOperator;
            conteiner2 = mathOperator;
        }



        void Calculate (object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                double result = MathOperator.Calculate(firstNumber, secondNumber, mathOperator);

                this.resultText.Text = result.ToString();
                firstNumber = Convert.ToDouble(result);
                this.operationText.Text = firstNumber.ToString();
            }
        }

        void Clear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
            this.operationText.Text = " ";
        }
    }
}
