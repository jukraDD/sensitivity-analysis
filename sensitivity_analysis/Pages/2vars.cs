using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sensitivity_analysis.Pages
{
    public partial class _2vars : Form
    {
        double a, b, vara, varb, ab11, ab01, ab10, ab00 = -1;
        public _2vars()
        {
            InitializeComponent();
            tableProb.CellPaint += new TableLayoutCellPaintEventHandler(tableProb_CellPaint);
            LockInputAabhB();
        }

        // draw table
        private void tableProb_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
                }
                tableProb.BringToFront();
                if(e.Column >= 2)
                {
                    using (Pen pen = new Pen(Color.Black, 1))
                    {
                        e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    }
                }
            }

            if (e.Row == 1)
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom-1, e.CellBounds.Right, e.CellBounds.Bottom-1);
                }
                tableProb.BringToFront();
            }

            if (e.Row >= 2)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }
                tableProb.BringToFront();
            }

            if (e.Column == 0)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                }
                tableProb.BringToFront();
            }

            if (e.Column == 1)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                }
                tableProb.BringToFront();
            }

            if (e.Column == 2)
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                }
                tableProb.BringToFront();
            }

            if (e.Column == 3)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Right-1, e.CellBounds.Top, e.CellBounds.Right-1, e.CellBounds.Bottom);
                }
                if (e.Row >= 1)
                {
                    using (Pen pen = new Pen(Color.Black, 1))
                    {
                        e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                    }
                }
                tableProb.BringToFront();
            }
        }

        private void EnableEventhandler()
        {
            InputAabhB01.TextChanged += InputAabhB01_TextChanged;
            InputAabhB10.TextChanged += InputAabhB10_TextChanged;
            InputAabhB00.TextChanged += InputAabhB00_TextChanged;
        }

        private void DisableEventhandler()
        {
            InputAabhB01.TextChanged -= InputAabhB01_TextChanged;
            InputAabhB10.TextChanged -= InputAabhB10_TextChanged;
            InputAabhB00.TextChanged -= InputAabhB00_TextChanged;
        }

        // returns  for input d the value of 1-d
        private double not(double d)
        {
            return 1 - d;
        }

        // lock input fields for depending probabilities
        private void LockInputAabhB()
        {
            InputAabhB11.Enabled = false;
            InputAabhB01.Enabled = false;
            InputAabhB10.Enabled = false;
            InputAabhB00.Enabled = false;
        }

        // unlock input fields for depending probabilities
        private void UnlockInputAabhB()
        {
            InputAabhB11.Enabled = true;
            InputAabhB01.Enabled = true;
            InputAabhB10.Enabled = true;
            InputAabhB00.Enabled = true;
        }

        // reset input fields for P(A|B)
        private void ResetAbhInput(string exclude = null)
        {
            DisableEventhandler();
            if (exclude != "11") InputAabhB11.Text = "";
            if (exclude != "01") InputAabhB01.Text = "";
            if (exclude != "10") InputAabhB10.Text = "";
            if (exclude != "00") InputAabhB00.Text = "";
            EnableEventhandler();
            ab11 = -1;
            ab01 = -1;
            ab10 = -1;
            ab00 = -1;
        }

        // check if a, b and c are between 0 and 1
        private bool IsValidInputAB(double a, double b)
        {
            return !(a < 0 || a > 1 || b < 0 || b > 1);
        }

        // check if d is between 0 and 1
        private bool IsValidInput(double d)
        {
            return !(d < 0 || d > 1);
        }

        private void GetValues_AandB(object sender)
        {
            // reset input for depending probabilities
            ResetAbhInput();
            // input field for P(A) used
            if (sender == InputA)
            {
                // try getting double value from input
                if (!double.TryParse(InputA.Text.Replace(".", ","), out a) || !IsValidInput(a))
                {
                    a = -1;
                    // set error message if input field is not empty and does not contain a number
                    if (InputA.Text != "") labelInputError1.Text = "Die Werte für P(A) und P(B) müssen mindestens 0 und maximal 1 sein.";
                    else labelInputError1.Text = "";
                    output_PnotA.Text = "";
                    LabelAunabhB11.Text = "";
                    LabelAunabhB10.Text = "";
                    LabelAunabhB01.Text = "";
                    LabelAunabhB00.Text = "";
                    LockInputAabhB();           // lock input fields for depending probabilities
                }
                else
                {
                    output_PnotA.Text = not(a).ToString();     // set label for P(¬A)
                    // set labels for P(A) in table
                    LabelAunabhB11.Text = a.ToString();
                    LabelAunabhB10.Text = a.ToString();
                    LabelAunabhB01.Text = not(a).ToString();
                    LabelAunabhB00.Text = not(a).ToString();
                }
            }
            // input field for P(B) used
            else if (sender == InputB)
            {
                // try getting double value from input
                if (!double.TryParse(InputB.Text.Replace(".", ","), out b) || !IsValidInput(b))
                {
                    b = -1;
                    // set error message if input field is not empty and does not contain a number
                    if (InputB.Text != "") labelInputError1.Text = "Die Werte für P(A) und P(B) müssen mindestens 0 und maximal 1 sein.";
                    else labelInputError1.Text = "";
                    output_PnotB.Text = "";
                    LockInputAabhB();           // lock input fields for depending probabilities
                }
                else
                {
                    output_PnotB.Text = not(b).ToString();     // set label for P(¬B)
                }
            }
            else
            {
                labelInputError1.Text = "Ungültige Eingabe";
                LockInputAabhB();
            }

            // reset error message if input fields are empty
            if (InputA.Text == "" && InputB.Text == "")
            {
                labelInputError1.Text = String.Empty;
            }

            // unlock input fields for depending probabilities if input fields for P(A) and P(B) are not empty and contain valid values
            if (InputA.Text != "" && InputB.Text != "" && IsValidInputAB(a, b))
            {
                labelInputError1.Text = String.Empty;
                UnlockInputAabhB();
            }
            else        // else lock input fields for depending probabilities
            {
                LockInputAabhB();
            }
        }

        private void GetValues_VarAandVarB(object sender)
        {
            ResetAbhInput();
            if (sender == InputVarA)
            {
                if (!double.TryParse(InputVarA.Text.Replace(".", ","), out vara) || vara < 0)
                {
                    vara = 0;
                    labelInputError1.Text = "Die Werte für Var(A) und Var(B) müssen mindenstens 0 sein.";
                    label_PA.Text = "P(A):";
                }
                else {
                    if (vara > 0) {
                        label_PA.Text = "Mittelwert(A):";
                    }
                }
            }
            else if (sender == InputVarB)
            {
                if (!double.TryParse(InputVarB.Text.Replace(".", ","), out varb) || varb < 0)
                {
                    varb = 0;
                    labelInputError1.Text = "Die Werte für Var(A) und Var(B) müssen mindenstens 0 sein.";
                    label_PB.Text = "P(B):";
                }
                else {
                    if (varb > 0) {
                        label_PB.Text = "Mittelwert(B):";
                    }
                }
            }
            else
            {
                labelInputError1.Text = "Ungültige Eingabe";
            }
        }

        private bool IsValidInput(double d)
        {
            return !(d < 0 || d > 1);
        }

        private void ResetAbhInput(string exclude = null)
        {
            InputAabhB11.TextChanged -= InputAabhB11_TextChanged;
            InputAabhB01.TextChanged -= InputAabhB01_TextChanged;            
            InputAabhB10.TextChanged -= InputAabhB10_TextChanged;
            InputAabhB00.TextChanged -= InputAabhB00_TextChanged;
            if (exclude != "11") InputAabhB11.Text = "";
            if (exclude != "01") InputAabhB01.Text = "";
            if (exclude != "10") InputAabhB10.Text = "";
            if (exclude != "00") InputAabhB00.Text = "";
            InputAabhB11.TextChanged += InputAabhB11_TextChanged;
            InputAabhB01.TextChanged += InputAabhB01_TextChanged;
            InputAabhB10.TextChanged += InputAabhB10_TextChanged;
            InputAabhB00.TextChanged += InputAabhB00_TextChanged;
            ab11 = -1;
            ab01 = -1;
            ab10 = -1;
            ab00 = -1;
        }

        // get values for P(A|B)
        private void GetValues_AabhB(object sender)
        {
            // input field for P(A|B) used
            if (sender == InputAabhB11)
            {
                ab11 = -1;
                // if input field is empty reset error message and reset depending input fields
                if (InputAabhB11.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAbhInput();
                }
                // try getting double value from input
                else if (!double.TryParse(InputAabhB11.Text.Replace(".", ","), out ab11) || !IsValidInput(ab11))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    // check if input is valid
                    if (a/b < ab11)
                    {
                        labelInputError2.Text = "Der Wert für P(A|B) muss kleiner als der Quotient P(A)/P(B) (" + a / b + ") sein.";
                        ResetAbhInput("11");
                    }
                    else if ((a-not(b))/b > ab11)
                    {
                        labelInputError2.Text = "Der Wert für P(A|B) muss größer als der Quotient (P(A)-P(¬B))/P(B) (" + (a-not(b))/b + ") sein.";
                        ResetAbhInput("11");
                    }
                    else
                    {
                        // calculate depending values and set results in associated input fields
                        ab01 = not(ab11);
                        ab10 = (a - ab11 * b) / not(b);
                        ab00 = not(ab10);
                        DisableEventhandler();
                        InputAabhB01.Text = ab01.ToString();
                        InputAabhB10.Text = ab10.ToString();
                        InputAabhB00.Text = ab00.ToString();
                        EnableEventhandler();
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            // input field for P(¬A|B) used
            else if (sender == InputAabhB01)
            {
                ab01 = -1;
                // if input field is empty reset error message and reset depending input fields
                if (InputAabhB01.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAbhInput();
                }
                // try getting double value from input
                else if (!double.TryParse(InputAabhB01.Text.Replace(".", ","), out ab01) || !IsValidInput(ab01))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    // check if input is valid
                    if (not(a) / b < ab01)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|B) muss kleiner als der Quotient P(¬A)/P(B) (" + not(a)/b + ") sein.";
                        ResetAbhInput("01");
                    }
                    else if ((not(a) - not(b)) /b > ab01)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|B) muss größer als der Quotient (P(¬A)-P(¬B))/P(B) (" + (not(a) - not(b)) /b + ") sein.";
                        ResetAbhInput("01");
                    }
                    else
                    {
                        // calculate depending values and set results in associated input fields
                        ab11 = not(ab01);
                        ab10 = (a - ab11 * b) / not(b);
                        ab00 = not(ab10);
                        DisableEventhandler();
                        InputAabhB11.Text = ab11.ToString();
                        InputAabhB10.Text = ab10.ToString();
                        InputAabhB00.Text = ab00.ToString();
                        EnableEventhandler();
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            // input field for P(A|¬B) used
            else if (sender == InputAabhB10)
            {
                ab10 = -1;
                // if input field is empty reset error message and reset depending input fields
                if (InputAabhB10.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAbhInput();
                }
                // try getting double value from input
                else if (!double.TryParse(InputAabhB10.Text.Replace(".", ","), out ab10) || !IsValidInput(ab10))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    // check if input is valid
                    if (a/not(b) < ab10)
                    {
                        labelInputError2.Text = "Der Wert für P(A|¬B) muss kleiner als der Quotient P(A)/P(¬B) (" + a/not(b) + ") sein.";
                        ResetAbhInput("10");
                    }
                    else if ((a-b)/not(b) > ab10)
                    {
                        labelInputError2.Text = "Der Wert für P(A|¬B) muss größer als der Quotient (P(A)-P(B))/P(¬B) (" + (a-b)/not(b) + ") sein.";
                        ResetAbhInput("10");
                    }
                    else
                    {
                        // calculate depending values and set results in associated input fields
                        ab00 = not(ab10);
                        ab11 = (a - ab10 * not(b)) / b;
                        ab01 = not(ab11);
                        DisableEventhandler();
                        InputAabhB00.Text = ab00.ToString();
                        InputAabhB11.Text = ab11.ToString();
                        InputAabhB01.Text = ab01.ToString();
                        EnableEventhandler();
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            // input field for P(¬A|¬B) used
            else if (sender == InputAabhB00)
            {
                ab00 = -1;
                // if input field is empty reset error message and reset depending input fields
                if (InputAabhB00.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAbhInput();
                }
                // try getting double value from input
                else if (!double.TryParse(InputAabhB00.Text.Replace(".", ","), out ab00) || !IsValidInput(ab00))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    // check if input is valid
                    if (not(a)/not(b) < ab00)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|¬B) muss kleiner als der Quotient P(¬A)/P(¬B) (" + not(a)/not(b) + ") sein.";
                        ResetAbhInput("00");
                    }
                    else if ((not(a)-b)/not(b) > ab00)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|¬B) muss größer als der Quotient (P(¬A)-P(B))/P(¬B) (" + (not(a)-b)/not(b) + ") sein.";
                        ResetAbhInput("00");
                    }
                    else
                    {
                        // calculate depending values and set results in associated input fields
                        ab10 = not(ab00);
                        ab11 = (a - ab10 * not(b)) / b;
                        ab01 = not(ab11);
                        DisableEventhandler();
                        InputAabhB10.Text = ab10.ToString();
                        InputAabhB11.Text = ab11.ToString();
                        InputAabhB01.Text = ab01.ToString();
                        EnableEventhandler();
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
        }

        // create results for dependent and independent variables
        private void CreateResults()
        {
            double resAuBunabh, resAuBabh, resAoBunabh, resAoBabh;

            resAuBunabh = a * b;

            resAoBunabh = a + b - (a * b);

            resAuBabh = ab11 * b;

            resAoBabh = ab11 * b + ab10 * not(b) + ab01 * b;

            // output results
            outputAuBunabh.Text = "P(R) = " + resAuBunabh.ToString();
            outputAoBunabh.Text = "P(R) = " + resAoBunabh.ToString();
            outputAuBabh.Text = "P(R) = " + resAuBabh.ToString();
            outputAoBabh.Text = "P(R) = " + resAoBabh.ToString();
        }

        private void CreateResultsVar()
        {
            double resVarAuBunabh, resVarAuBabh, resVarAoBunabh, resVarAoBabh;
            double newB = 0.1;
            for (int i = 0; i < 1000; i++) {
                if (vara > 0) {
                    Random rand = new Random();
                    double u1 = 1.0 - rand.NextDouble();
                    double u2 = 1.0 - rand.NextDouble();
                    double randA = Math.Sqrt(vara) * Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); ;
                    double newA = 0.02 + randA;
                }
                if (varb > 0) {
                    //PB
                }
                //Calc
                //resVarAuBunabh = PA * PB;
            }
            //resVarAuBunabh = vara * varb;
            //Ausgabe für Print
            //outputvar1.Text = newA.ToString();

            //Zufallszahl Generieren
            Random random = new Random();

            int[] chartyvalues = new int[21];
            //Loop
            for (int i = 0; i < 1000; i++)
            {
                //Var Wert Berechnen
                
                double zufallszahl = random.NextDouble();
                //runden
                double gerundeteZahl = RoundToNearest(zufallszahl, 0.05);
                //zuordnen
                chartyvalues[(int)(gerundeteZahl / 0.05)]++;
            }

            /*int[] chartyvalues = { 50, 110, 105, 95, 91,
                              87, 77, 70, 50, 48,
                              35, 99, 300, 15, 10,
                              2, 1, 0, 79, 0, 0};
            */
            PrintChart(chartyvalues);

        }

        static double RoundToNearest(double value, double step)
        {
            // Runden auf das nächstgelegene Vielfache von "step"
            double gerundeteZahl = Math.Round(value / step) * step;
            return gerundeteZahl;
        }

        private void PrintChart(int[] chartyvalues)
        {
            //chart1.Visible = !chart1.Visible; //Sichtbarkeit ändern
            chart1.Visible = true;

            // Vor dem Hinzufügen neuer Daten die vorhandenen Daten löschen
            chart1.Series["Simulation"].Points.Clear();

            for (int i = 0; i<21 ; i++)
            {
                //Console.WriteLine(i*0.05 + "=" + chartyvalues[i]);
                chart1.Series["Simulation"].Points.AddXY(i * 0.05, chartyvalues[i]);
            }
        }

        /* ----------------------------------------------
                        EventListener
           ---------------------------------------------- */
        private void InputVarA_TextChanged(object sender, EventArgs e)
        {
            GetValues_VarAandVarB(sender);
        }

        private void InputVarB_TextChanged(object sender, EventArgs e)
        {
            GetValues_VarAandVarB(sender);
        }

        private void btn_simulate_Click(object sender, EventArgs e)
        {
            CreateResultsVar();
        }

        private void InputA_TextChanged(object sender, EventArgs e)
        {
            GetValues_AandB(sender);
        }

        private void InputB_TextChanged(object sender, EventArgs e)
        {
            GetValues_AandB(sender);
        }

        private void InputAabhB11_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhB(sender);
        }

        private void InputAabhB01_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhB(sender);
        }

        private void InputAabhB10_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhB(sender);
        }

        private void InputAabhB00_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhB(sender);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (vara > 0 || varb > 0) {
                    CreateResultsVar();
                }
            if (IsValidInputAB(a, b) && IsValidInput(ab11) && IsValidInput(ab01) && IsValidInput(ab10) && IsValidInput(ab00))
            {
                CreateResults();
                //check vara varb > 0  hier
            }
            else
            {
                labelInputError2.Text = "Bitte geben Sie zulässige Werte an. (Werte zwischen 0 und 1)";
            }
        }
    }
}