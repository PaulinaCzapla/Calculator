using System;
using System.Windows;
using System.Collections.Generic;

namespace calculator
{
    public partial class MainWindow : Window
    {
        private Equation equation;
        private Memory memory;       
        public MainWindow()
        {
            InitializeComponent();


            ResultText.Text = string.Empty;
            equation= new Equation();
            memory = new Memory();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;

            var button = sender as System.Windows.Controls.Button;
            char currentNumber = button.Name[button.Name.Length -1];
            CurrentOperationText.Text += currentNumber;
        }

        private void ButtonSqrt_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;
            if(equation.CheckPreviousOperation(ref ResultText, ref CurrentOperationText))
            {
                CurrentOperationText.Text = CurrentOperationText.Text + "sqrt";
                CurrentOperationText.Text = equation.CalculateResult(ref CurrentOperationText);
            }
        }

        private void ButtonPower_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;
            if(equation.CheckPreviousOperation(ref ResultText, ref CurrentOperationText))
            CurrentOperationText.Text += "^";
        }

        private void ButtonDivision_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;
            if(equation.CheckPreviousOperation(ref ResultText, ref CurrentOperationText))
            CurrentOperationText.Text += "/";
        }

        private void ButtonSubtraction_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;
            if(equation.CheckPreviousOperation(ref ResultText, ref CurrentOperationText))
            CurrentOperationText.Text += "-";
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;
            if(equation.CheckPreviousOperation(ref ResultText, ref CurrentOperationText))
            CurrentOperationText.Text += "*";
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;
            if(equation.CheckPreviousOperation(ref ResultText, ref CurrentOperationText))
            CurrentOperationText.Text += "+";
        }



        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            string result = string.Empty;
            try
            {
                result = equation.CalculateResult(ref CurrentOperationText);
            }
            catch(Exception er)
            {
                Console.WriteLine(er.Message);
                MessageBox.Show("Blad: " + er.Message);
            }
            ResultText.Text = result;
            memory.setMemory(result);
            CurrentOperationText.Text = string.Empty;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentOperationText.Text != string.Empty)
            {
                string text = CurrentOperationText.Text.Remove(CurrentOperationText.Text.Length - 1);
                CurrentOperationText.Text = text;
            }
        }


        private void ButtonMakeDouble_Click(object sender, RoutedEventArgs e) => CurrentOperationText.Text += ",";
        

        private void ButtonMC_Click(object sender, RoutedEventArgs e)
        {
            string tmp = CurrentOperationText.Text;
            memory.AddToMemory( ref tmp);
            CurrentOperationText.Text = tmp;
        }

       
    }
}
