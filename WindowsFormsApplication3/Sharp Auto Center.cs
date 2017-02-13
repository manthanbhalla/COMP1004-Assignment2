using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    // Sharp Auto Center	

    // Name: Manthan Bhalla

    // Student Id: 200331757

    // Date : 12 February, 2017	


    // A form to calculate total sales bonus that every employee receives on the basis of

    // total monlthy sales and the percentage of hours worked by the employee


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program calculates the amount due on a new or used vehicle.", "About", MessageBoxButtons.OK);
        }

        void showAdditionalItems()
        {
            double AdditionalCost = 0;

            if (checkBox1.Checked)
            {
                AdditionalCost += 425.76;
            }

            if (checkBox2.Checked)
            {
                AdditionalCost += 987.41;
            }

            if (checkBox3.Checked)
            {
                AdditionalCost += 1741.23;
            }
            if (checkBox4.Checked)
            {
                AdditionalCost += 500.90;
            }

            if (radioButton1.Checked)
            {
                AdditionalCost += 0;
            }
            else if (radioButton2.Checked)
            {
                AdditionalCost += 345.72;
            }
            else if (radioButton3.Checked)
            {
                AdditionalCost += 599.99;
            }
            else if (radioButton4.Checked)
            {
                AdditionalCost += 675.49;
            }
            textBox2.Text = String.Format("{0:C}", AdditionalCost);
        }

        // When checked, call method to add and display value
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            showAdditionalItems();
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            showAdditionalItems();
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            showAdditionalItems();
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            showAdditionalItems();
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            showAdditionalItems();
        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            showAdditionalItems();
        }
        private void RadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            showAdditionalItems();

        }
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the color dialog
            colorDialog.ShowDialog();

            // If user pressed ok

            textBox1.ForeColor = colorDialog.Color;
            textBox2.ForeColor = colorDialog.Color;

        }

        // Set the font style for the textboxes
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.ShowDialog();

            textBox1.Font = fontDialog.Font;
            textBox2.Font = fontDialog.Font;
        }

        //-------------------------------------------------------------------------------
        // Validate that the text in BasePriceTextBox is numeric
        //-------------------------------------------------------------------------------       
        private void TradeInAllowanceTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateNumericTextBox(textBox6, e);
        }

        //-------------------------------------------------------------------------------
        // Validate that the text in BasePriceTextBox is numeric
        //------------------------
        private void BasePriceTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateNumericTextBox(textBox1, e);
        }


        //-------------------------------------------------------------------------------
        // Calculates and displays the sub total, total, and amount due in currency format.
        // Validates that the required fields are not empty.
        //-------------------------------------------------------------------------------       
        private void CalculateButton1_Click(object sender, EventArgs e)
        {
            // if the textboxes are empty, notify user
            if (textBox1.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please fill the required fields.", "Oops!", MessageBoxButtons.OK);
            }
            else
            {
                double basePrice = Double.Parse(textBox1.Text.Replace("$", ""));
                double tradeInAllowance = Double.Parse(textBox6.Text.Replace("$", ""));
                double additionalOptions = Double.Parse("0" + textBox2.Text.Replace("$", ""));

                // calculate and display the sub total
                double subTotal = Double.Parse(textBox1.Text.Replace("$", "")) + additionalOptions;
                textBox3.Text = String.Format("{0:C}", subTotal);

                // calculate tax on subTotal and set the total textbox
                double total = Math.Round(calculateTaxOn(subTotal), 2);
                textBox5.Text = String.Format("{0:C}", total);

                // subtract any trade-in value from total and display in amount due textbox
                double amountDue = Math.Round(total - tradeInAllowance, 2);
                textBox7.Text = String.Format("{0:C}", amountDue);

                // format input textboxes to display as currency
                textBox1.Text = String.Format("{0:C}", basePrice);
                textBox6.Text = String.Format("{0:C}", tradeInAllowance);
                textBox2.Text = String.Format("{0:C}", additionalOptions);
            }
        }

        //-------------------------------------------------------------------------------
        // Clear all textboxes and set options to default
        //-------------------------------------------------------------------------------       
        private void ClearButton1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "0";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";

            radioButton1.Checked = true;

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }
        //-------------------------------------------------------------------------------
        // Checks if the value in the textbox is numeric, notifies the user
        // if it is not numeric, and can't lose focus until it is either numeric or blank
        //-------------------------------------------------------------------------------       
        private void validateNumericTextBox(TextBox textbox, CancelEventArgs e)
        {
            double num;
            if (double.TryParse(textbox.Text, out num))
            {
                // It's a number!
            }
            else
            {
                MessageBox.Show("Please enter a numeric value.", "Oops!", MessageBoxButtons.OK);
            }
                // if the textbox is blank, allow focus change
                if (textbox.Text == "")
                {
                    e.Cancel = false;
                }
            }


        // Calculate sales tax on a double value and return the result

        private double calculateTaxOn(double value)
        {
            return value * 1.13;
        }

        // Close the form
        private void ExitButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}