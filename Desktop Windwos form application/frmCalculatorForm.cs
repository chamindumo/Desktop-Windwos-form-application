#region Using Derectives
using System;
using System.Windows.Forms; 
#endregion

namespace Desktop_Windwos_form_application
{
    public class frmCalculatorForm: Form
    {
        #region Using Variable
        private double currentResult = 0;
        private char currentOperation = ' ';

        private TextBox textBox1;
        private Button btn2;
        private Button btn3;
        private Button btnPluse;
        private Button btn4;
        private Button btn5;
        private Button btn6;
        private Button btnMin;
        private Button btn7;
        private Button btn8;
        private Button btn9;
        private Button btnMulti;
        private Button btnEqual;
        private Button btnDot;
        private Button btn0;
        private Button btnReset;
        private Button btn1;
        #endregion
        #region Using Constructor
        public frmCalculatorForm()
        {
            InitializeComponent();
        }
        #endregion
        #region Using Initalize
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btnPluse = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btnMulti = new System.Windows.Forms.Button();
            this.btnEqual = new System.Windows.Forms.Button();
            this.btnDot = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(237, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(17, 79);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(60, 40);
            this.btn1.TabIndex = 1;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn2
            // 
            this.btn2.Location = new System.Drawing.Point(98, 79);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(61, 40);
            this.btn2.TabIndex = 2;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn3
            // 
            this.btn3.Location = new System.Drawing.Point(179, 79);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(58, 40);
            this.btn3.TabIndex = 3;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btnPluse
            // 
            this.btnPluse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPluse.Location = new System.Drawing.Point(260, 79);
            this.btnPluse.Name = "btnPluse";
            this.btnPluse.Size = new System.Drawing.Size(60, 40);
            this.btnPluse.TabIndex = 4;
            this.btnPluse.Text = "+";
            this.btnPluse.UseVisualStyleBackColor = true;
            this.btnPluse.Click += new System.EventHandler(this.btnPluse_Click);
            // 
            // btn4
            // 
            this.btn4.Location = new System.Drawing.Point(17, 125);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(60, 39);
            this.btn4.TabIndex = 5;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(98, 125);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(61, 39);
            this.btn5.TabIndex = 6;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn6
            // 
            this.btn6.Location = new System.Drawing.Point(179, 125);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(58, 39);
            this.btn6.TabIndex = 7;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btn6_Click);
            // 
            // btnMin
            // 
            this.btnMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMin.Location = new System.Drawing.Point(260, 125);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(60, 39);
            this.btnMin.TabIndex = 8;
            this.btnMin.Text = "-";
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btn7
            // 
            this.btn7.Location = new System.Drawing.Point(17, 170);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(60, 37);
            this.btn7.TabIndex = 9;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btn7_Click);
            // 
            // btn8
            // 
            this.btn8.Location = new System.Drawing.Point(98, 170);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(61, 37);
            this.btn8.TabIndex = 10;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.A_Click);
            // 
            // btn9
            // 
            this.btn9.Location = new System.Drawing.Point(179, 170);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(58, 37);
            this.btn9.TabIndex = 11;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btn9_Click);
            // 
            // btnMulti
            // 
            this.btnMulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMulti.Location = new System.Drawing.Point(260, 170);
            this.btnMulti.Name = "btnMulti";
            this.btnMulti.Size = new System.Drawing.Size(60, 37);
            this.btnMulti.TabIndex = 12;
            this.btnMulti.Text = "*";
            this.btnMulti.UseVisualStyleBackColor = true;
            this.btnMulti.Click += new System.EventHandler(this.button12_Click);
            // 
            // btnEqual
            // 
            this.btnEqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEqual.Location = new System.Drawing.Point(260, 213);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(60, 36);
            this.btnEqual.TabIndex = 13;
            this.btnEqual.Text = "=";
            this.btnEqual.UseVisualStyleBackColor = true;
            this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);
            // 
            // btnDot
            // 
            this.btnDot.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDot.Location = new System.Drawing.Point(179, 213);
            this.btnDot.Name = "btnDot";
            this.btnDot.Size = new System.Drawing.Size(58, 36);
            this.btnDot.TabIndex = 14;
            this.btnDot.Text = ".";
            this.btnDot.UseVisualStyleBackColor = true;
            this.btnDot.Click += new System.EventHandler(this.btnDot_Click);
            // 
            // btn0
            // 
            this.btn0.Location = new System.Drawing.Point(17, 213);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(142, 36);
            this.btn0.TabIndex = 15;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(260, 35);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(60, 20);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "<-";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmCalculatorForm
            // 
            this.ClientSize = new System.Drawing.Size(339, 261);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btnDot);
            this.Controls.Add(this.btnEqual);
            this.Controls.Add(this.btnMulti);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btnPluse);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.textBox1);
            this.Name = "frmCalculatorForm";
            this.Load += new System.EventHandler(this.frmCalculatorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        #region Using Items

        private void btn0_Click(object sender, EventArgs e)
        {
            AppendDigit("0");

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            currentResult = 0;
            currentOperation = ' ';
            textBox1.Clear();
        }

        private void A_Click(object sender, EventArgs e)
        {
            AppendDigit("8");

        }

        private void button12_Click(object sender, EventArgs e)
        {
            ProcessOperation('*');

        }

        private void frmCalculatorForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            AppendDigit("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            AppendDigit("2");

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            AppendDigit("3");

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            AppendDigit("4");

        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            AppendDigit(".");

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            AppendDigit("5");

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            AppendDigit("6");

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            AppendDigit("7");

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            AppendDigit("9");

        }

        private void btnPluse_Click(object sender, EventArgs e)
        {
            ProcessOperation('+');

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            PerformCalculation();

        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            ProcessOperation('-');

        }
        #endregion
        #region Using Method
        private void AppendDigit(string digit)
        {
            textBox1.Text += digit;
        }
        private void ProcessOperation(char operation)
        {
            // Attempt to parse the text in textBox1 to a double
            if (double.TryParse(textBox1.Text, out double enteredNumber))
            {
                // Perform the calculation based on the current operation
                switch (currentOperation)
                {
                    case '+':
                        currentResult += enteredNumber;
                        break;
                    case '-':
                        currentResult -= enteredNumber;
                        break;
                    case '*':
                        currentResult *= enteredNumber;
                        break;
                    default:
                        currentResult = enteredNumber;
                        break;
                }

                // Set the current operation for the next calculation
                currentOperation = operation;

                // Clear the TextBox for the next input
                textBox1.Clear();
            }
            else
            {
                // Handle the case when the entered text is not a valid numeric value
                // For example, display an error message or perform error handling.
                // Example:
                // MessageBox.Show("Invalid input. Please enter a valid number.");
            }
        }

        private void PerformCalculation()
        {
            // Attempt to parse the text in textBox1 to a double
            if (double.TryParse(textBox1.Text, out double enteredNumber))
            {
                // Perform the final calculation based on the current operation
                switch (currentOperation)
                {
                    case '+':
                        currentResult += enteredNumber;
                        break;
                    case '-':
                        currentResult -= enteredNumber;
                        break;
                    case '*':
                        currentResult *= enteredNumber;
                        break;
                    default:
                        currentResult = enteredNumber;
                        break;
                }

                // Display the result in the TextBox
                textBox1.Text = currentResult.ToString();

                // Reset the current operation
                currentOperation = ' ';
            }
            else
            {
                // Handle the case when the entered text is not a valid numeric value
                // For example, display an error message or perform error handling.
                // Example:
                // MessageBox.Show("Invalid input. Please enter a valid number.");
            }
        } 
        #endregion


    }
}
