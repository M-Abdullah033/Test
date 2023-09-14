using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScientificCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtinput.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtinput.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtinput.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtinput.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtinput.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtinput.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtinput.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtinput.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtinput.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtinput.Text += "0";
        }

        private void btnclr_Click(object sender, EventArgs e)
        {
            txtinput.Clear();
            txtoutput.Clear();
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            txtinput.Text += " / ";
        }

        private void btnmul_Click(object sender, EventArgs e)
        {
            txtinput.Text += " * ";
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            txtinput.Text += " - ";
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            txtinput.Text += " + ";
        }

        private void btnDeci_Click(object sender, EventArgs e)
        {
            txtinput.Text += " . ";
        }
        private string selectedFunction; // Store the selected trigonometric function.
        private double selectedAngle;    // Store the selected angle.

        private void btnsin_Click(object sender, EventArgs e)
        {
            // Set the selected function when the sin button is clicked.
            selectedFunction = "sin";
        }

        private void btncos_Click(object sender, EventArgs e)
        {
            // Set the selected function when the cos button is clicked.
            selectedFunction = "cos";
        }

        private void btntan_Click(object sender, EventArgs e)
        {
            // Set the selected function when the tan button is clicked.
            selectedFunction = "tan";
        }

       private void btnEq_Click(object sender, EventArgs e)
{
    string expression = txtinput.Text;

    // Check if the expression contains trigonometric functions (sin, cos, tan).
    if (expression.Contains("sin") || expression.Contains("cos") || expression.Contains("tan"))
    {
        // Trigonometric function handling (similar to the existing code).
        string selectedFunction = "";
        double selectedAngle = double.NaN;

        if (expression.Contains("sin"))
        {
            selectedFunction = "sin";
        }
        else if (expression.Contains("cos"))
        {
            selectedFunction = "cos";
        }
        else if (expression.Contains("tan"))
        {
            selectedFunction = "tan";
        }

        // Extract the angle from the expression.
        string anglePattern = @"(\d+(\.\d+)?)"; // Regular expression to match a number.
        Match angleMatch = Regex.Match(expression, anglePattern);
        if (angleMatch.Success)
        {
            if (double.TryParse(angleMatch.Value, out selectedAngle))
            {
                double radians = selectedAngle * (Math.PI / 180.0);
                double result = 0; // Initialize result.

                // Calculate the result based on the selected function.
                switch (selectedFunction)
                {
                    case "sin":
                        result = Math.Sin(radians);
                        break;
                    case "cos":
                        result = Math.Cos(radians);
                        break;
                    case "tan":
                        result = Math.Tan(radians);
                        break;
                }

                // Display the result.
                txtoutput.Text += selectedFunction + "(" + selectedAngle + ") = " + result + "\r\n";
                ;
            }
            else
            {
                // Handle invalid input or display an error message.
                txtoutput.Text += "Invalid input for trigonometric function. Please enter a numeric angle.\r\n";
            }
        }
        else
        {
            // Handle invalid input or display an error message.
            txtoutput.Text += "Invalid input for trigonometric function. Please enter a numeric angle.\r\n";
        }
    }
    else
    {
        // No trigonometric functions found, perform regular arithmetic operations.
        try
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);

            object result = row["expression"];

            if (result != null)
            {
                double numericResult;
                if (double.TryParse(result.ToString(), out numericResult))
                {
                    txtoutput.Text += expression + " = " + numericResult + "\r\n";
                }
                else
                {
                    txtoutput.Text += "Error: Invalid expression\r\n";
                }
            }
            else
            {
                txtoutput.Text += "Error: Invalid expression\r\n";
            }
        }
        catch (Exception ex)
        {
            txtoutput.Text += "Error: " + ex.Message + "\r\n";
        }
    }
}


    }       
}

