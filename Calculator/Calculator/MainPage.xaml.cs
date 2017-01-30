﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;

        public MainPage()
        {
            InitializeComponent();
        }

        //Click sur un nombre
        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
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
                this.resultText.Text = number.ToString("N0");
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }
            }
        }

        //Click sur un opérateur
        void OnSelectOperator(object sender, EventArgs e)
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }
        
        // Click racine carré
        void OnSelectSqrt(object sender, EventArgs e)
        {
            double number;
            if (double.TryParse(this.resultText.Text, out number))
            {
                this.resultText.Text = "";
                string tempResult = "";
                tempResult += Math.Sqrt(number);
                //Ne pas afficher de 10 nombre après la virgule 
                if (tempResult.Length > 10)
                    tempResult = tempResult.Substring(0, 10);
                this.resultText.Text += tempResult;
            }
        }

        //Effacer ecran
        void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            this.resultText.Text = "0";
        }

        //Calculer
        void OnCalculate(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                double result = 0;
                switch (mathOperator)
                {
                    case "/":
                        result = firstNumber / secondNumber;
                        break;
                    case "X":
                        result = firstNumber * secondNumber;
                        break;
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    default:
                        break;
                }

                firstNumber = result;
                this.resultText.Text = result.ToString("N0");
                currentState = -1;
            }
        }
    }
}
