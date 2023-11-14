using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sensitivity_analysis.Pages
{
    public partial class _2vars : Form
    {
        double a, b, ab11, ab01, ab10, ab00 = -1;
        public _2vars()
        {
            InitializeComponent();
            tableProb.CellPaint += new TableLayoutCellPaintEventHandler(tableProb_CellPaint);
            LockInputAabhB();
        }

        private void LockInputAabhB()
        {
            InputAabhB11.Enabled = false;
            InputAabhB01.Enabled = false;
            InputAabhB10.Enabled = false;
            InputAabhB00.Enabled = false;
        }

        private void UnlockInputAabhB()
        {
            InputAabhB11.Enabled = true;
            InputAabhB01.Enabled = true;
            InputAabhB10.Enabled = true;
            InputAabhB00.Enabled = true;
        }

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

        private bool IsValidInputAB(double a, double b)
        {
            return !(a < 0 || a > 1 || b < 0 || b > 1);
        }

        private void GetValues_AandB(object sender)
        {
            ResetAbhInput();
            if (sender == InputA)
            {
                if (!double.TryParse(InputA.Text.Replace(".", ","), out a) || a > 1 || a < 0)
                {
                    a = -1;
                    labelInputError1.Text = "Die Werte für P(A) und P(B) müssen mindestens 0 und maximal 1 sein.";
                    output_PnotA.Text = "";
                    LabelAunabhB11.Text = "";
                    LabelAunabhB10.Text = "";
                    LabelAunabhB01.Text = "";
                    LabelAunabhB00.Text = "";
                    LockInputAabhB();
                }
                else
                {
                    output_PnotA.Text = (1 - a).ToString();
                    LabelAunabhB11.Text = a.ToString();
                    LabelAunabhB10.Text = a.ToString();
                    LabelAunabhB01.Text = (1 - a).ToString();
                    LabelAunabhB00.Text = (1 - a).ToString();
                }
            }
            else if (sender == InputB)
            {
                if (!double.TryParse(InputB.Text.Replace(".", ","), out b) || b > 1 || b < 0)
                {
                    b = -1;
                    labelInputError1.Text = "Die Werte für P(A) und P(B) müssen mindestens 0 und maximal 1 sein.";
                    output_PnotB.Text = "";
                    LockInputAabhB();
                }
                else
                {
                    output_PnotB.Text = (1 - b).ToString();
                }
            }
            else
            {
                labelInputError1.Text = "Ungültige Eingabe";
                LockInputAabhB();
            }

            if (InputA.Text == "" && InputB.Text == "")
            {
                labelInputError1.Text = String.Empty;
            }
            
            if (InputA.Text != "" && InputB.Text != "" && IsValidInputAB(a, b))
            {
                labelInputError1.Text = String.Empty;
                UnlockInputAabhB();
            }
            else
            {
                LockInputAabhB();
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

        private void GetValues_AabhB(object sender)
        {
            if (sender == InputAabhB11)
            {
                ab11 = -1;
                if (InputAabhB11.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAbhInput();
                }
                else if (!double.TryParse(InputAabhB11.Text.Replace(".", ","), out ab11) || !IsValidInput(ab11))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if (a/b < ab11)
                    {
                        labelInputError2.Text = "Der Wert für P(A|B) muss kleiner als der Quotient P(A)/P(B) (" + a / b + ") sein.";
                        ResetAbhInput("11");
                    }
                    else
                    {
                        ab01 = 1 - ab11;
                        ab10 = (a - ab11 * b) / (1 - b);
                        ab00 = 1 - ab10;
                        InputAabhB01.TextChanged -= InputAabhB01_TextChanged;
                        InputAabhB10.TextChanged -= InputAabhB10_TextChanged;
                        InputAabhB00.TextChanged -= InputAabhB00_TextChanged;
                        InputAabhB01.Text = ab01.ToString();
                        InputAabhB10.Text = ab10.ToString();
                        InputAabhB00.Text = ab00.ToString();
                        InputAabhB01.TextChanged += InputAabhB01_TextChanged;
                        InputAabhB10.TextChanged += InputAabhB10_TextChanged;
                        InputAabhB00.TextChanged += InputAabhB00_TextChanged;
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhB01)
            {
                ab01 = -1;
                if (InputAabhB01.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAbhInput();
                }
                else if (!double.TryParse(InputAabhB01.Text.Replace(".", ","), out ab01) || !IsValidInput(ab01))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if ((1-a) / b < ab01)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|B) muss kleiner als der Quotient P(¬A)/P(B) (" + (1-a)/b + ") sein.";
                        ResetAbhInput("01");
                    }
                    else
                    {
                        ab11 = 1 - ab01;
                        ab10 = (a - ab11 * b) / (1 - b);
                        ab00 = 1 - ab10;
                        InputAabhB11.TextChanged -= InputAabhB11_TextChanged;
                        InputAabhB10.TextChanged -= InputAabhB10_TextChanged;
                        InputAabhB00.TextChanged -= InputAabhB00_TextChanged;
                        InputAabhB11.Text = ab11.ToString();
                        InputAabhB10.Text = ab10.ToString();
                        InputAabhB00.Text = ab00.ToString();
                        InputAabhB11.TextChanged += InputAabhB11_TextChanged;
                        InputAabhB10.TextChanged += InputAabhB10_TextChanged;
                        InputAabhB00.TextChanged += InputAabhB00_TextChanged;
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhB10)
            {
                ab10 = -1;
                if (InputAabhB10.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAbhInput();
                }
                else if (!double.TryParse(InputAabhB10.Text.Replace(".", ","), out ab10) || !IsValidInput(ab10))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if (a / (1-b) < ab10)
                    {
                        labelInputError2.Text = "Der Wert für P(A|¬B) muss kleiner als der Quotient P(A)/P(¬B) (" + a/(1-b) + ") sein.";
                        ResetAbhInput("10");
                    }
                    else
                    {
                        ab00 = 1 - ab10;
                        ab11 = (a - ab10 * (1 - b)) / b;
                        ab01 = 1 - ab11;
                        InputAabhB00.TextChanged -= InputAabhB00_TextChanged;
                        InputAabhB11.TextChanged -= InputAabhB11_TextChanged;
                        InputAabhB01.TextChanged -= InputAabhB01_TextChanged;
                        InputAabhB00.Text = ab00.ToString();
                        InputAabhB11.Text = ab11.ToString();
                        InputAabhB01.Text = ab01.ToString();
                        InputAabhB00.TextChanged += InputAabhB00_TextChanged;
                        InputAabhB11.TextChanged += InputAabhB11_TextChanged;
                        InputAabhB01.TextChanged += InputAabhB01_TextChanged;
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhB00)
            {
                ab00 = -1;
                if (InputAabhB00.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAbhInput();
                }
                else if (!double.TryParse(InputAabhB00.Text.Replace(".", ","), out ab00) || !IsValidInput(ab00))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if ((1-a)/(1-b) < ab00)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|¬B) muss kleiner als der Quotient P(¬A)/P(¬B) (" + (1-a)/(1-b) + ") sein.";
                        ResetAbhInput("00");
                    }
                    else
                    {
                        ab10 = 1 - ab00;
                        ab11 = (a - ab10 * (1 - b)) / b;
                        ab01 = 1 - ab11;
                        InputAabhB10.TextChanged -= InputAabhB10_TextChanged;
                        InputAabhB11.TextChanged -= InputAabhB11_TextChanged;
                        InputAabhB01.TextChanged -= InputAabhB01_TextChanged;
                        InputAabhB10.Text = ab10.ToString();
                        InputAabhB11.Text = ab11.ToString();
                        InputAabhB01.Text = ab01.ToString();
                        InputAabhB10.TextChanged += InputAabhB10_TextChanged;
                        InputAabhB11.TextChanged += InputAabhB11_TextChanged;
                        InputAabhB01.TextChanged += InputAabhB01_TextChanged;
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
        }

        private void CreateResults()
        {
            double resAuBunabh, resAuBabh, resAoBunabh, resAoBabh;

            resAuBunabh = a * b;

            resAoBunabh = a + b - (a * b);

            resAuBabh = ab11 * b;

            resAoBabh = ab11 * b + ab10 * (1 - b) + ab01 * b;

            outputAuBunabh.Text = "P(C) = " + resAuBunabh.ToString();
            outputAoBunabh.Text = "P(C) = " + resAoBunabh.ToString();
            outputAuBabh.Text = "P(C) = " + resAuBabh.ToString();
            outputAoBabh.Text = "P(C) = " + resAoBabh.ToString();
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
            if (IsValidInputAB(a, b) && IsValidInput(ab11) && IsValidInput(ab01) && IsValidInput(ab10) && IsValidInput(ab00))
            {
                CreateResults();
            }
            else
            {
                labelInputError2.Text = "Bitte geben Sie zulässige Werte an. (Werte zwischen 0 und 1)";
            }
        }
    }
}
