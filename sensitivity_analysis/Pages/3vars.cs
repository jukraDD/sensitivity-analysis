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
    public partial class _3vars : Form
    {
        double a, b, c = -1;
        double ab111, ab011, ab101, ab001, ab110, ab010, ab100, ab000, ac111, ac011, ac101, ac001, ac110, ac010, ac100, ac000, bc111, bc011, bc101, bc001, bc110, bc010, bc100, bc000 = -1;
        TextBox[] abhInputs, abhInputsAB, abhInputsAC, abhInputsBC;
        Label[] unabhLabels;

        public _3vars()
        {
            InitializeComponent();
            tableProb.CellPaint += new TableLayoutCellPaintEventHandler(tableProb_CellPaint);
            abhInputs = new[] { InputAabhB111, InputAabhB011, InputAabhB101, InputAabhB001, InputAabhB110, InputAabhB010, InputAabhB100, InputAabhB000, InputAabhC111, InputAabhC011, InputAabhC101, InputAabhC001, InputAabhC110, InputAabhC010, InputAabhC100, InputAabhC000, InputBabhC111, InputBabhC011, InputBabhC101, InputBabhC001, InputBabhC110, InputBabhC010, InputBabhC100, InputBabhC000 };
            abhInputsAB = new[] { InputAabhB111, InputAabhB011, InputAabhB101, InputAabhB001, InputAabhB110, InputAabhB010, InputAabhB100, InputAabhB000 };
            abhInputsAC = new[] { InputAabhC111, InputAabhC011, InputAabhC101, InputAabhC001, InputAabhC110, InputAabhC010, InputAabhC100, InputAabhC000 };
            abhInputsBC = new[] { InputBabhC111, InputBabhC011, InputBabhC101, InputBabhC001, InputBabhC110, InputBabhC010, InputBabhC100, InputBabhC000 };
            unabhLabels = new[] { LabelAunabh111, LabelAunabh011, LabelAunabh101, LabelAunabh001, LabelAunabh110, LabelAunabh010, LabelAunabh100, LabelAunabh000 };
            LockAbhInput();
            relAB.SelectedIndex = 0;
            relABC.SelectedIndex = 0;
        }

        private void tableProb_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 1)
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }
            }
            if (e.Column == 3)
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                }
            }

            if (e.Row == 0)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
                }
            }
            if (e.Row > 1)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                }
            }

            if (e.Column < 3)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                }
            }
            if (e.Column == 6)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                }
            }
            if (e.Column > 3)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                }
            }
            tableProb.BringToFront();
        }

        private void panel_rel_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawLine(pen, 17, 17, 50, 45);
                e.Graphics.DrawLine(pen, 103, 17, 70, 45);
                e.Graphics.DrawLine(pen, 57, 70, 90, 98);
                e.Graphics.DrawLine(pen, 143, 70, 110, 98);
                e.Graphics.DrawLine(pen, 100, 126, 100, 154);
            }
        }

        private void LockAbhInput()
        {
            foreach (TextBox t in abhInputs)
            {
                t.Enabled = false;
            }
        }

        private void UnlockAbhInput()
        {
            foreach (TextBox t in abhInputs)
            {
                t.Enabled = true;
            }
        }

        private void ResetUnabhOutput()
        {
            foreach (Label l in unabhLabels)
            {
                l.Text = "";
            }
        }

        private void ResetAabhBInput(int? exclude = null)
        {
            int c = 0;
            foreach (TextBox t in abhInputsAB)
            {
                if (exclude != null && c == exclude) { c++; continue; }
                DisableEventhandler(0, c);
                t.Text = "";
                EnableEventhandler(0, c);
                c++;
            }
        }

        private void ResetAabhCInput(int? exclude = null)
        {
            int c = 0;
            foreach (TextBox t in abhInputsAC)
            {
                if (exclude != null && c == exclude) { c++; continue; }
                DisableEventhandler(1, c);
                t.Text = "";
                EnableEventhandler(1, c);
                c++;
            }
        }

        private void ResetBabhCInput(int? exclude = null)
        {
            int c = 0;
            foreach (TextBox t in abhInputsBC)
            {
                if (exclude != null && c == exclude) { c++; continue; }
                DisableEventhandler(2, c);
                t.Text = "";
                EnableEventhandler(2, c);
                c++;
            }
        }

        private void EnableEventhandler(int column, int row)
        {
            if (column == 0)
            {
                if (row == 0)      abhInputsAB[0].TextChanged += InputAabhB111_TextChanged;
                else if (row == 1) abhInputsAB[1].TextChanged += InputAabhB011_TextChanged;
                else if (row == 2) abhInputsAB[2].TextChanged += InputAabhB101_TextChanged;
                else if (row == 3) abhInputsAB[3].TextChanged += InputAabhB001_TextChanged;
                else if (row == 4) abhInputsAB[4].TextChanged += InputAabhB110_TextChanged;
                else if (row == 5) abhInputsAB[5].TextChanged += InputAabhB010_TextChanged;
                else if (row == 6) abhInputsAB[6].TextChanged += InputAabhB100_TextChanged;
                else if (row == 7) abhInputsAB[7].TextChanged += InputAabhB000_TextChanged;
            }
            else if (column == 1)
            {
                if (row == 0)      abhInputsAC[0].TextChanged += InputAabhC111_TextChanged;
                else if (row == 1) abhInputsAC[1].TextChanged += InputAabhC011_TextChanged;
                else if (row == 2) abhInputsAC[2].TextChanged += InputAabhC101_TextChanged;
                else if (row == 3) abhInputsAC[3].TextChanged += InputAabhC001_TextChanged;
                else if (row == 4) abhInputsAC[4].TextChanged += InputAabhC110_TextChanged;
                else if (row == 5) abhInputsAC[5].TextChanged += InputAabhC010_TextChanged;
                else if (row == 6) abhInputsAC[6].TextChanged += InputAabhC100_TextChanged;
                else if (row == 7) abhInputsAC[7].TextChanged += InputAabhC000_TextChanged;

            }
            else if (column == 2)
            {
                
            }
        }

        private void DisableEventhandler(int column, int row)
        {
            if (column == 0)
            {
                if (row == 0)      abhInputsAB[0].TextChanged -= InputAabhB111_TextChanged;
                else if (row == 1) abhInputsAB[1].TextChanged -= InputAabhB011_TextChanged;
                else if (row == 2) abhInputsAB[2].TextChanged -= InputAabhB101_TextChanged;
                else if (row == 3) abhInputsAB[3].TextChanged -= InputAabhB001_TextChanged;
                else if (row == 4) abhInputsAB[4].TextChanged -= InputAabhB110_TextChanged;
                else if (row == 5) abhInputsAB[5].TextChanged -= InputAabhB010_TextChanged;
                else if (row == 6) abhInputsAB[6].TextChanged -= InputAabhB100_TextChanged;
                else if (row == 7) abhInputsAB[7].TextChanged -= InputAabhB000_TextChanged;
            }
            else if (column == 1)
            {
                if (row == 0)      abhInputsAC[0].TextChanged -= InputAabhC111_TextChanged;
                else if (row == 1) abhInputsAC[1].TextChanged -= InputAabhC011_TextChanged;
                else if (row == 2) abhInputsAC[2].TextChanged -= InputAabhC101_TextChanged;
                else if (row == 3) abhInputsAC[3].TextChanged -= InputAabhC001_TextChanged;
                else if (row == 4) abhInputsAC[4].TextChanged -= InputAabhC110_TextChanged;
                else if (row == 5) abhInputsAC[5].TextChanged -= InputAabhC010_TextChanged;
                else if (row == 6) abhInputsAC[6].TextChanged -= InputAabhC100_TextChanged;
                else if (row == 7) abhInputsAC[7].TextChanged -= InputAabhC000_TextChanged;
            }
            else if (column == 2)
            {

            }
        }

        private void SetAabhBValues(int exclude, double[] values)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i == exclude) continue;
                DisableEventhandler(0, i);
                abhInputsAB[i].Text = values[i].ToString();
                EnableEventhandler(0, i);
            }
        }

        private void SetAabhCValues(int exclude, double[] values)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i == exclude) continue;
                DisableEventhandler(1, i);
                abhInputsAC[i].Text = values[i].ToString();
                EnableEventhandler(1, i);
            }
        }

        private bool IsValidInputABC(double a, double b, double c)
        {
            return !(a < 0 || a > 1 || b < 0 || b > 1 || c < 0 || c > 1);
        }

        private bool IsValidInput(double d)
        {
            return !(d < 0 || d > 1);
        }

        private void GetValues_ABC(object sender)
        {
            ResetAabhBInput(); ResetAabhCInput(); ResetBabhCInput();
            if (sender == InputA)
            {
                if (!double.TryParse(InputA.Text.Replace(".", ","), out a) || a > 1 || a < 0)
                {
                    a = -1;
                    if(InputA.Text != "") labelInputError1.Text = "Die Werte für P(A), P(B) und P(C) müssen mindestens 0 und maximal 1 sein.";
                    else labelInputError1.Text = "";
                    output_PnotA.Text = "";
                    ResetUnabhOutput();
                    LockAbhInput();
                }
                else
                {
                    output_PnotA.Text = (1 - a).ToString();
                    int index = 0;
                    foreach (Label l in unabhLabels)
                    {
                        if (index % 2 == 0) l.Text = a.ToString();
                        else l.Text = (1 - a).ToString();
                        index++;
                    }
                }
            }
            else if (sender == InputB)
            {
                if (!double.TryParse(InputB.Text.Replace(".", ","), out b) || b > 1 || b < 0)
                {
                    b = -1;
                    if (InputB.Text != "") labelInputError1.Text = "Die Werte für P(A), P(B) und P(C) müssen mindestens 0 und maximal 1 sein.";
                    else labelInputError1.Text = "";
                    output_PnotB.Text = "";
                    LockAbhInput();
                }
                else
                {
                    output_PnotB.Text = (1 - b).ToString();
                }
            }
            else if (sender == InputC)
            {
                if (!double.TryParse(InputC.Text.Replace(".", ","), out c) || c > 1 || c < 0)
                {
                    c = -1;
                    if (InputC.Text != "") labelInputError1.Text = "Die Werte für P(A), P(B) und P(C) müssen mindestens 0 und maximal 1 sein.";
                    else labelInputError1.Text = "";
                    output_PnotC.Text = "";
                    LockAbhInput();
                }
                else
                {
                    output_PnotC.Text = (1 - c).ToString();
                }
            }
            else
            {
                labelInputError1.Text = "Ungültige Eingabe";
                LockAbhInput();
            }

            if (InputA.Text == "" && InputB.Text == "" && InputC.Text == "")
            {
                labelInputError1.Text = String.Empty;
            }

            if (InputA.Text != "" && InputB.Text != "" && InputC.Text != "" && IsValidInputABC(a,b,c))
            {
                labelInputError1.Text = String.Empty;
                UnlockAbhInput();
            }
            else
            {
                LockAbhInput();
            }
        }

        private void GetValues_AabhB(object sender)
        {
            if (sender == InputAabhB111)
            {
                ab111 = -1;
                if (InputAabhB111.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhBInput();
                }
                else if (!double.TryParse(InputAabhB111.Text.Replace(".", ","), out ab111) || !IsValidInput(ab111))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if (a / b < ab111)
                    {
                        labelInputError2.Text = "Der Wert für P(A|B) muss kleiner als der Quotient P(A)/P(B) (" + a / b + ") sein.";
                        ResetAabhBInput(0);
                    }
                    else if ((a - (1 - b)) / b > ab111)
                    {
                        labelInputError2.Text = "Der Wert für P(A|B) muss größer als der Quotient (P(A)-P(¬B))/P(B) (" + (a - (1 - b)) / b + ") sein.";
                        ResetAabhBInput(0);
                    }
                    else
                    {
                        ab011 = 1 - ab111;
                        ab101 = (a - ab111 * b) / (1 - b);
                        ab001 = 1 - ab101;
                        ab110 = ab111;
                        ab010 = ab011;
                        ab100 = ab101;
                        ab000 = ab001;
                        double[] val = new[] { ab111, ab011, ab101, ab001, ab110, ab010, ab100, ab000 };
                        SetAabhBValues(0, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhB011)
            {
                ab011 = -1;
                if (InputAabhB011.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhBInput();
                }
                else if (!double.TryParse(InputAabhB011.Text.Replace(".", ","), out ab011) || !IsValidInput(ab011))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if ((1 - a) / b < ab011)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|B) muss kleiner als der Quotient P(¬A)/P(B) (" + (1 - a) / b + ") sein.";
                        ResetAabhBInput(1);
                    }
                    else if (((1 - a) - (1 - b)) / b > ab011)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|B) muss größer als der Quotient (P(¬A)-P(¬B))/P(B) (" + ((1 - a) - (1 - b)) / b + ") sein.";
                        ResetAabhBInput(1);
                    }
                    else
                    {
                        ab111 = 1 - ab011;
                        ab101 = (a - ab111 * b) / (1 - b);
                        ab001 = 1 - ab101;
                        ab010 = ab011;
                        ab110 = ab111;
                        ab100 = ab101;
                        ab000 = ab001;
                        double[] val = new[] { ab111, ab011, ab101, ab001, ab110, ab010, ab100, ab000 };
                        SetAabhBValues(1, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhB101)
            {
                ab101 = -1;
                if (InputAabhB101.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhBInput();
                }
                else if (!double.TryParse(InputAabhB101.Text.Replace(".", ","), out ab101) || !IsValidInput(ab101))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if (a / (1 - b) < ab101)
                    {
                        labelInputError2.Text = "Der Wert für P(A|¬B) muss kleiner als der Quotient P(A)/P(¬B) (" + a / (1 - b) + ") sein.";
                        ResetAabhBInput(2);
                    }
                    else if ((a - b) / (1 - b) > ab101)
                    {
                        labelInputError2.Text = "Der Wert für P(A|¬B) muss größer als der Quotient (P(A)-P(B))/P(¬B) (" + (a - b) / (1 - b) + ") sein.";
                        ResetAabhBInput(2);
                    }
                    else
                    {
                        ab001 = 1 - ab101;
                        ab111 = (a - ab101 * (1 - b)) / b;
                        ab011 = 1 - ab111;
                        ab100 = ab101;
                        ab000 = ab001;
                        ab110 = ab111;
                        ab010 = ab011;
                        double[] val = new[] { ab111, ab011, ab101, ab001, ab110, ab010, ab100, ab000 };
                        SetAabhBValues(2, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhB001)
            {
                ab001 = -1;
                if (InputAabhB001.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhBInput();
                }
                else if (!double.TryParse(InputAabhB001.Text.Replace(".", ","), out ab001) || !IsValidInput(ab001))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if ((1 - a) / (1 - b) < ab001)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|¬B) muss kleiner als der Quotient P(¬A)/P(¬B) (" + (1 - a) / (1 - b) + ") sein.";
                        ResetAabhBInput(3);
                    }
                    else if (((1 - a) - b) / (1 - b) > ab001)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|¬B) muss größer als der Quotient (P(¬A)-P(B))/P(¬B) (" + ((1 - a) - b) / (1 - b) + ") sein.";
                        ResetAabhBInput(3);
                    }
                    else
                    {
                        ab101 = 1 - ab001;
                        ab111 = (a - ab101 * (1 - b)) / b;
                        ab011 = 1 - ab111;
                        ab000 = ab001;
                        ab100 = ab101;
                        ab110 = ab111;
                        ab010 = ab011;
                        double[] val = new[] { ab111, ab011, ab101, ab001, ab110, ab010, ab100, ab000 };
                        SetAabhBValues(3, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhB110)
            {
                ab110 = -1;
                if (InputAabhB110.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhBInput();
                }
                else if (!double.TryParse(InputAabhB110.Text.Replace(".", ","), out ab110) || !IsValidInput(ab110))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if (a / b < ab110)
                    {
                        labelInputError2.Text = "Der Wert für P(A|B) muss kleiner als der Quotient P(A)/P(B) (" + a / b + ") sein.";
                        ResetAabhBInput(4);
                    }
                    else if ((a - (1 - b)) / b > ab110)
                    {
                        labelInputError2.Text = "Der Wert für P(A|B) muss größer als der Quotient (P(A)-P(¬B))/P(B) (" + (a - (1 - b)) / b + ") sein.";
                        ResetAabhBInput(4);
                    }
                    else
                    {
                        ab010 = 1 - ab110;
                        ab100 = (a - ab110 * b) / (1 - b);
                        ab000 = 1 - ab100;
                        ab111 = ab110;
                        ab011 = ab010;
                        ab101 = ab100;
                        ab001 = ab000;
                        double[] val = new[] { ab111, ab011, ab101, ab001, ab110, ab010, ab100, ab000 };
                        SetAabhBValues(4, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhB010)
            {
                ab010 = -1;
                if (InputAabhB010.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhBInput();
                }
                else if (!double.TryParse(InputAabhB010.Text.Replace(".", ","), out ab010) || !IsValidInput(ab010))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if ((1 - a) / b < ab010)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|B) muss kleiner als der Quotient P(¬A)/P(B) (" + (1 - a) / b + ") sein.";
                        ResetAabhBInput(5);
                    }
                    else if (((1 - a) - (1 - b)) / b > ab010)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|B) muss größer als der Quotient (P(¬A)-P(¬B))/P(B) (" + ((1 - a) - (1 - b)) / b + ") sein.";
                        ResetAabhBInput(5);
                    }
                    else
                    {
                        ab110 = 1 - ab010;
                        ab100 = (a - ab110 * b) / (1 - b);
                        ab000 = 1 - ab100;
                        ab011 = ab010;
                        ab111 = ab110;
                        ab101 = ab100;
                        ab001 = ab000;
                        double[] val = new[] { ab111, ab011, ab101, ab001, ab110, ab010, ab100, ab000 };
                        SetAabhBValues(5, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhB100)
            {
                ab100 = -1;
                if (InputAabhB100.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhBInput();
                }
                else if (!double.TryParse(InputAabhB100.Text.Replace(".", ","), out ab100) || !IsValidInput(ab100))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if (a / (1 - b) < ab100)
                    {
                        labelInputError2.Text = "Der Wert für P(A|¬B) muss kleiner als der Quotient P(A)/P(¬B) (" + a / (1 - b) + ") sein.";
                        ResetAabhBInput(6);
                    }
                    else if ((a - b) / (1 - b) > ab100)
                    {
                        labelInputError2.Text = "Der Wert für P(A|¬B) muss größer als der Quotient (P(A)-P(B))/P(¬B) (" + (a - b) / (1 - b) + ") sein.";
                        ResetAabhBInput(6);
                    }
                    else
                    {
                        ab000 = 1 - ab100;
                        ab110 = (a - ab100 * (1 - b)) / b;
                        ab010 = 1 - ab110;
                        ab101 = ab100;
                        ab001 = ab000;
                        ab111 = ab110;
                        ab011 = ab010;
                        double[] val = new[] { ab111, ab011, ab101, ab001, ab110, ab010, ab100, ab000 };
                        SetAabhBValues(6, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhB000)
            {
                ab000 = -1;
                if (InputAabhB000.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhBInput();
                }
                else if (!double.TryParse(InputAabhB000.Text.Replace(".", ","), out ab000) || !IsValidInput(ab000))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if ((1 - a) / (1 - b) < ab000)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|¬B) muss kleiner als der Quotient P(¬A)/P(¬B) (" + (1 - a) / (1 - b) + ") sein.";
                        ResetAabhBInput(7);
                    }
                    else if (((1 - a) - b) / (1 - b) > ab000)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|¬B) muss größer als der Quotient (P(¬A)-P(B))/P(¬B) (" + ((1 - a) - b) / (1 - b) + ") sein.";
                        ResetAabhBInput(7);
                    }
                    else
                    {
                        ab100 = 1 - ab000;
                        ab110 = (a - ab100 * (1 - b)) / b;
                        ab010 = 1 - ab110;
                        ab001 = ab000;
                        ab101 = ab100;
                        ab111 = ab110;
                        ab011 = ab010;
                        double[] val = new[] { ab111, ab011, ab101, ab001, ab110, ab010, ab100, ab000 };
                        SetAabhBValues(7, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
        }

        private void GetValues_AabhC(object sender)
        {
            if (sender == InputAabhC111)
            {
                ac111 = -1;
                if (InputAabhC111.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhCInput();
                }
                else if (!double.TryParse(InputAabhC111.Text.Replace(".", ","), out ac111) || !IsValidInput(ac111))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if (a / c < ac111)
                    {
                        labelInputError2.Text = "Der Wert für P(A|C) muss kleiner als der Quotient P(A)/P(C) (" + a / c + ") sein.";
                        ResetAabhCInput(0);
                    }
                    else if ((a - (1 - c)) / c > ac111)
                    {
                        labelInputError2.Text = "Der Wert für P(A|C) muss größer als der Quotient (P(A)-P(¬C))/P(C) (" + (a - (1 - c)) / c + ") sein.";
                        ResetAabhCInput(0);
                    }
                    else
                    {
                        ac011 = 1 - ac111;
                        ac110 = (a - ac111 * c) / (1 - c);
                        ac010 = 1 - ac110;
                        ac101 = ac111;
                        ac001 = ac011;
                        ac100 = ac110;
                        ac000 = ac010;
                        double[] val = new[] { ac111, ac011, ac101, ac001, ac110, ac010, ac100, ac000 };
                        SetAabhCValues(0, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhC011)
            {
                ac011 = -1;
                if (InputAabhC011.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhCInput();
                }
                else if (!double.TryParse(InputAabhC011.Text.Replace(".", ","), out ac011) || !IsValidInput(ac011))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if ((1 - a) / c < ac011)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|C) muss kleiner als der Quotient P(¬A)/P(C) (" + (1 - a) / c + ") sein.";
                        ResetAabhCInput(1);
                    }
                    else if (((1 - a) - (1 - c)) / c > ac011)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|C) muss größer als der Quotient (P(¬A)-P(¬C))/P(C) (" + ((1 - a) - (1 - c)) / c + ") sein.";
                        ResetAabhCInput(1);
                    }
                    else
                    {
                        ac111 = 1 - ac011;
                        ac110 = (a - ac111 * c) / (1 - c);
                        ac010 = 1 - ac110;
                        ac001 = ac011;
                        ac101 = ac111;
                        ac100 = ac110;
                        ac000 = ac010;
                        double[] val = new[] { ac111, ac011, ac101, ac001, ac110, ac010, ac100, ac000 };
                        SetAabhCValues(1, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhC101)
            {
                ac101 = -1;
                if (InputAabhC101.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhCInput();
                }
                else if (!double.TryParse(InputAabhC101.Text.Replace(".", ","), out ac101) || !IsValidInput(ac101))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if (a / c < ac101)
                    {
                        labelInputError2.Text = "Der Wert für P(A|C) muss kleiner als der Quotient P(A)/P(C) (" + a / c + ") sein.";
                        ResetAabhCInput(2);
                    }
                    else if ((a - (1 - c)) / b > ac101)
                    {
                        labelInputError2.Text = "Der Wert für P(A|C) muss größer als der Quotient (P(A)-P(¬C))/P(C) (" + (a - (1 - c)) / c + ") sein.";
                        ResetAabhCInput(2);
                    }
                    else
                    {
                        ac001 = 1 - ac101;
                        ac100 = (a - ac101 * c) / (1 - c);
                        ac000 = 1 - ac100;
                        ac111 = ac101;
                        ac011 = ac001;
                        ac110 = ac100;
                        ac010 = ac000;
                        double[] val = new[] { ac111, ac011, ac101, ac001, ac110, ac010, ac100, ac000 };
                        SetAabhCValues(2, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhC001)
            {
                ac001 = -1;
                if (InputAabhB001.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhCInput();
                }
                else if (!double.TryParse(InputAabhC001.Text.Replace(".", ","), out ac001) || !IsValidInput(ac001))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if ((1 - a) / c < ac001)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|C) muss kleiner als der Quotient P(¬A)/P(C) (" + (1 - c) / c + ") sein.";
                        ResetAabhCInput(3);
                    }
                    else if (((1 - a) - (1 - c)) / c > ac001)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|C) muss größer als der Quotient (P(¬A)-P(¬C))/P(C) (" + ((1 - a) - (1 - c)) / c + ") sein.";
                        ResetAabhCInput(3);
                    }
                    else
                    {
                        ac101 = 1 - ac001;
                        ac100 = (a - ac101 * c) / (1 - c);
                        ac000 = 1 - ac100;
                        ac011 = ac001;
                        ab111 = ab101;
                        ab110 = ab100;
                        ab010 = ab000;
                        double[] val = new[] { ac111, ac011, ac101, ac001, ac110, ac010, ac100, ac000 };
                        SetAabhCValues(3, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhC110)
            {
                ac110 = -1;
                if (InputAabhC110.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhCInput();
                }
                else if (!double.TryParse(InputAabhC110.Text.Replace(".", ","), out ac110) || !IsValidInput(ac110))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if (a / (1 - c) < ac110)
                    {
                        labelInputError2.Text = "Der Wert für P(A|¬C) muss kleiner als der Quotient P(A)/P(¬C) (" + a / (1 - c) + ") sein.";
                        ResetAabhCInput(4);
                    }
                    else if ((a - c) / (1 - c) > ac110)
                    {
                        labelInputError2.Text = "Der Wert für P(A|¬C) muss größer als der Quotient (P(A)-P(C))/P(¬C) (" + (a - c) / (1 - c) + ") sein.";
                        ResetAabhCInput(4);
                    }
                    else
                    {
                        ac010 = 1 - ac110;
                        ac111 = (a - ac110 * (1 - c)) / c;
                        ac011 = 1 - ac111;
                        ac100 = ac110;
                        ac000 = ac010;
                        ac101 = ac111;
                        ac001 = ac011;
                        double[] val = new[] { ac111, ac011, ac101, ac001, ac110, ac010, ac100, ac000 };
                        SetAabhCValues(4, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhC010)
            {
                ac010 = -1;
                if (InputAabhC010.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhCInput();
                }
                else if (!double.TryParse(InputAabhC010.Text.Replace(".", ","), out ac010) || !IsValidInput(ac010))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if ((1 - a) / (1 - c) < ac010)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|¬C) muss kleiner als der Quotient P(¬A)/P(¬C) (" + (1 - a) / (1 - c) + ") sein.";
                        ResetAabhCInput(5);
                    }
                    else if (((1 - a) - c) / (1 - c) > ac010)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|¬C) muss größer als der Quotient (P(¬A)-P(C))/P(¬C) (" + ((1 - a) - c) / (1 - c) + ") sein.";
                        ResetAabhCInput(5);
                    }
                    else
                    {
                        ac110 = 1 - ac010;
                        ac111 = (a - ac110 * (1 - b)) / b;
                        ac011 = 1 - ac111;
                        ac000 = ac010;
                        ac100 = ac110;
                        ac101 = ac111;
                        ac001 = ac011;
                        double[] val = new[] { ac111, ac011, ac101, ac001, ac110, ac010, ac100, ac000 };
                        SetAabhCValues(5, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhC100)
            {
                ac100 = -1;
                if (InputAabhC100.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhCInput();
                }
                else if (!double.TryParse(InputAabhC100.Text.Replace(".", ","), out ac100) || !IsValidInput(ac100))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if (a / (1 - c) < ac100)
                    {
                        labelInputError2.Text = "Der Wert für P(A|¬C) muss kleiner als der Quotient P(A)/P(¬C) (" + a / (1 - c) + ") sein.";
                        ResetAabhBInput(6);
                    }
                    else if ((a - c) / (1 - c) > ac100)
                    {
                        labelInputError2.Text = "Der Wert für P(A|¬C) muss größer als der Quotient (P(A)-P(C))/P(¬C) (" + (a - c) / (1 - c) + ") sein.";
                        ResetAabhBInput(6);
                    }
                    else
                    {
                        ac000 = 1 - ac100;
                        ac101 = (a - ac100 * (1 - b)) / b;
                        ac001 = 1 - ac101;
                        ac110 = ac100;
                        ac010 = ac000;
                        ac111 = ac101;
                        ac011 = ac001;
                        double[] val = new[] { ac111, ac011, ac101, ac001, ac110, ac010, ac100, ac000 };
                        SetAabhCValues(6, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputAabhC000)
            {
                ac000 = -1;
                if (InputAabhC000.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetAabhCInput();
                }
                else if (!double.TryParse(InputAabhC000.Text.Replace(".", ","), out ac000) || !IsValidInput(ac000))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if ((1 - a) / (1 - c) < ac000)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|¬C) muss kleiner als der Quotient P(¬A)/P(¬C) (" + (1 - a) / (1 - c) + ") sein.";
                        ResetAabhCInput(7);
                    }
                    else if (((1 - a) - c) / (1 - c) > ac000)
                    {
                        labelInputError2.Text = "Der Wert für P(¬A|¬C) muss größer als der Quotient (P(¬A)-P(C))/P(¬C) (" + ((1 - a) - c) / (1 - c) + ") sein.";
                        ResetAabhCInput(7);
                    }
                    else
                    {
                        ac100 = 1 - ac000;
                        ac101 = (a - ac100 * (1 - b)) / b;
                        ac001 = 1 - ac101;
                        ac010 = ac000;
                        ac110 = ac100;
                        ac111 = ac101;
                        ac011 = ac001;
                        double[] val = new[] { ac111, ac011, ac101, ac001, ac110, ac010, ac100, ac000 };
                        SetAabhCValues(7, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
        }

        private void InputA_TextChanged(object sender, EventArgs e)
        {
            GetValues_ABC(sender);
        }

        private void InputB_TextChanged(object sender, EventArgs e)
        {
            GetValues_ABC(sender);
        }

        private void InputC_TextChanged(object sender, EventArgs e)
        {
            GetValues_ABC(sender);
        }

        private void InputAabhB111_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhB(sender);
        }
        private void InputAabhB011_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhB(sender);
        }

        private void InputAabhB101_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhB(sender);
        }

        private void InputAabhB001_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhB(sender);
        }

        private void InputAabhB110_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhB(sender);
        }

        private void InputAabhB010_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhB(sender);
        }

        private void InputAabhB100_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhB(sender);
        }

        private void InputAabhB000_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhB(sender);
        }

        private void InputAabhC111_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhC(sender);
        }

        private void InputAabhC011_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhC(sender);
        }

        private void InputAabhC101_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhC(sender);
        }

        private void InputAabhC001_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhC(sender);
        }

        private void InputAabhC110_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhC(sender);
        }

        private void InputAabhC010_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhC(sender);
        }

        private void InputAabhC100_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhC(sender);
        }

        private void InputAabhC000_TextChanged(object sender, EventArgs e)
        {
            GetValues_AabhC(sender);
        }
    }
}
