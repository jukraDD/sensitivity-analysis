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
        double ab111, ab011, ab101, ab001, ab110, ab010, ab100, ab000, bc111, bc011, bc101, bc001, bc110, bc010, bc100, bc000 = -1;
        TextBox[] abhInputs, abhInputsAB, abhInputsBC;
        Label[] unabhLabels;

        public _3vars()
        {
            InitializeComponent();
            tableProb.CellPaint += new TableLayoutCellPaintEventHandler(tableProb_CellPaint);
            abhInputs = new[] { InputAabhB111, InputAabhB011, InputAabhB101, InputAabhB001, InputAabhB110, InputAabhB010, InputAabhB100, InputAabhB000, InputBabhC111, InputBabhC011, InputBabhC101, InputBabhC001, InputBabhC110, InputBabhC010, InputBabhC100, InputBabhC000 };
            abhInputsAB = new[] { InputAabhB111, InputAabhB011, InputAabhB101, InputAabhB001, InputAabhB110, InputAabhB010, InputAabhB100, InputAabhB000 };
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
            if (e.Column == 4 || e.Column == 5)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Left, e.CellBounds.Bottom);
                }
            }
            if (e.Column == 5)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawLine(pen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
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

        private void ResetBabhCInput(int? exclude = null)
        {
            int c = 0;
            foreach (TextBox t in abhInputsBC)
            {
                if (exclude != null && c == exclude) { c++; continue; }
                DisableEventhandler(1, c);
                t.Text = "";
                EnableEventhandler(1, c);
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
                if (row == 0)      abhInputsBC[0].TextChanged += InputBabhC111_TextChanged;
                else if (row == 1) abhInputsBC[1].TextChanged += InputBabhC011_TextChanged;
                else if (row == 2) abhInputsBC[2].TextChanged += InputBabhC101_TextChanged;
                else if (row == 3) abhInputsBC[3].TextChanged += InputBabhC001_TextChanged;
                else if (row == 4) abhInputsBC[4].TextChanged += InputBabhC110_TextChanged;
                else if (row == 5) abhInputsBC[5].TextChanged += InputBabhC010_TextChanged;
                else if (row == 6) abhInputsBC[6].TextChanged += InputBabhC100_TextChanged;
                else if (row == 7) abhInputsBC[7].TextChanged += InputBabhC000_TextChanged;
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
                if (row == 0)      abhInputsBC[0].TextChanged -= InputBabhC111_TextChanged;
                else if (row == 1) abhInputsBC[1].TextChanged -= InputBabhC011_TextChanged;
                else if (row == 2) abhInputsBC[2].TextChanged -= InputBabhC101_TextChanged;
                else if (row == 3) abhInputsBC[3].TextChanged -= InputBabhC001_TextChanged;
                else if (row == 4) abhInputsBC[4].TextChanged -= InputBabhC110_TextChanged;
                else if (row == 5) abhInputsBC[5].TextChanged -= InputBabhC010_TextChanged;
                else if (row == 6) abhInputsBC[6].TextChanged -= InputBabhC100_TextChanged;
                else if (row == 7) abhInputsBC[7].TextChanged -= InputBabhC000_TextChanged;
            }
        }

        private void SetAabhBValues(int? exclude, double[] values)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i == exclude) continue;
                DisableEventhandler(0, i);
                abhInputsAB[i].Text = values[i].ToString();
                EnableEventhandler(0, i);
            }
        }

        private void SetBabhCValues(int? exclude, double[] values)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i == exclude) continue;
                DisableEventhandler(1, i);
                abhInputsBC[i].Text = values[i].ToString();
                EnableEventhandler(1, i);
            }
        }

        private void SetAunabhB()
        {
            ab111 = a;
            ab011 = 1 - a;
            ab101 = a;
            ab001 = 1 - a;
            ab110 = a;
            ab010 = 1 - a;
            ab100 = a;
            ab000 = 1 - a;
            double[] val = new[] { ab111, ab011, ab101, ab001, ab110, ab010, ab100, ab000 };
            SetAabhBValues(null, val);
        }

        private void SetBunabhC()
        {
            bc111 = b;
            bc011 = b;
            bc101 = 1 - b;
            bc001 = 1 - b;
            bc110 = b;
            bc010 = b;
            bc100 = 1 - b;
            bc000 = 1 - b;
            double[] val = new[] { bc111, bc011, bc101, bc001, bc110, bc010, bc100, bc000 };
            SetBabhCValues(null, val);
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
            ResetAabhBInput(); ResetBabhCInput();
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
        private void GetValues_BabhC(object sender)
        {
            if (sender == InputBabhC111)
            {
                bc111 = -1;
                if (InputBabhC111.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetBabhCInput();
                }
                else if (!double.TryParse(InputBabhC111.Text.Replace(".", ","), out bc111) || !IsValidInput(bc111))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if (b / c < bc111)
                    {
                        labelInputError2.Text = "Der Wert für P(B|C) muss kleiner als der Quotient P(B)/P(C) (" + b / c + ") sein.";
                        ResetBabhCInput(0);
                    }
                    else if ((b - (1 - c)) / c > bc111)
                    {
                        labelInputError2.Text = "Der Wert für P(B|C) muss größer als der Quotient (P(B)-P(¬C))/P(C) (" + (b - (1 - c)) / c + ") sein.";
                        ResetBabhCInput(0);
                    }
                    else
                    {
                        bc101 = 1 - bc111;
                        bc110 = (b - bc111 * c) / (1 - c);
                        bc100 = 1 - bc110;
                        bc011 = bc111;
                        bc001 = bc101;
                        bc010 = bc110;
                        bc000 = bc100;
                        double[] val = new[] { bc111, bc011, bc101, bc001, bc110, bc010, bc100, bc000 };
                        SetBabhCValues(0, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputBabhC011)
            {
                bc011 = -1;
                if (InputBabhC011.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetBabhCInput();
                }
                else if (!double.TryParse(InputBabhC011.Text.Replace(".", ","), out bc011) || !IsValidInput(bc011))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if (b / c < bc011)
                    {
                        labelInputError2.Text = "Der Wert für P(B|C) muss kleiner als der Quotient P(B)/P(C) (" + b / c + ") sein.";
                        ResetBabhCInput(1);
                    }
                    else if ((b - (1 - c)) / c > bc011)
                    {
                        labelInputError2.Text = "Der Wert für P(B|C) muss größer als der Quotient (P(B)-P(¬C))/P(C) (" + (b - (1 - c)) / c + ") sein.";
                        ResetBabhCInput(1);
                    }
                    else
                    {
                        bc001 = 1 - bc011;
                        bc010 = (b - bc011 * c) / (1 - c);
                        bc000 = 1 - bc010;
                        bc111 = bc011;
                        bc101 = bc001;
                        bc110 = bc010;
                        bc100 = bc000;
                        double[] val = new[] { bc111, bc011, bc101, bc001, bc110, bc010, bc100, bc000 };
                        SetBabhCValues(1, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputBabhC101)
            {
                bc101 = -1;
                if (InputBabhC101.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetBabhCInput();
                }
                else if (!double.TryParse(InputBabhC101.Text.Replace(".", ","), out bc101) || !IsValidInput(bc101))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if ((1 - b) / c < bc101)
                    {
                        labelInputError2.Text = "Der Wert für P(¬B|C) muss kleiner als der Quotient P(¬B)/P(C) (" + (1 - b) / c + ") sein.";
                        ResetBabhCInput(2);
                    }
                    else if (((1 - b) - (1 - c)) / c > bc101)
                    {
                        labelInputError2.Text = "Der Wert für P(¬B|C) muss größer als der Quotient (P(¬B)-P(¬C))/P(C) (" + ((1 - b) - (1 - c)) / c + ") sein.";
                        ResetBabhCInput(2);
                    }
                    else
                    {
                        bc111 = 1 - bc101;
                        bc110 = (b - bc111 * c) / (1 - c);
                        bc100 = 1 - bc110;
                        bc001 = bc101;
                        bc011 = bc111;
                        bc010 = bc110;
                        bc000 = bc100;
                        double[] val = new[] { bc111, bc011, bc101, bc001, bc110, bc010, bc100, bc000 };
                        SetBabhCValues(2, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputBabhC001)
            {
                bc001 = -1;
                if (InputBabhC001.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetBabhCInput();
                }
                else if (!double.TryParse(InputBabhC001.Text.Replace(".", ","), out bc001) || !IsValidInput(bc001))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if ((1 - b) / c < bc001)
                    {
                        labelInputError2.Text = "Der Wert für P(¬B|C) muss kleiner als der Quotient P(¬B)/P(C) (" + (1 - b) / c + ") sein.";
                        ResetBabhCInput(3);
                    }
                    else if (((1 - b) - (1 - c)) / c > bc001)
                    {
                        labelInputError2.Text = "Der Wert für P(¬B|C) muss größer als der Quotient (P(¬B)-P(¬C))/P(C) (" + ((1 - b) - (1 - c)) / c + ") sein.";
                        ResetBabhCInput(3);
                    }
                    else
                    {
                        bc011 = 1 - bc001;
                        bc010 = (b - bc011 * c) / (1 - c);
                        bc000 = 1 - bc010;
                        bc101 = bc001;
                        bc111 = bc011;
                        bc110 = bc010;
                        bc100 = bc000;
                        double[] val = new[] { bc111, bc011, bc101, bc001, bc110, bc010, bc100, bc000 };
                        SetBabhCValues(3, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputBabhC110)
            {
                bc110 = -1;
                if (InputBabhC110.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetBabhCInput();
                }
                else if (!double.TryParse(InputBabhC110.Text.Replace(".", ","), out bc110) || !IsValidInput(bc110))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if (b / (1 - c) < bc110)
                    {
                        labelInputError2.Text = "Der Wert für P(B|¬C) muss kleiner als der Quotient P(B)/P(¬C) (" + b / (1 - c) + ") sein.";
                        ResetBabhCInput(4);
                    }
                    else if ((b - c) / (1 - c) > bc110)
                    {
                        labelInputError2.Text = "Der Wert für P(B|¬C) muss größer als der Quotient (P(B)-P(C))/P(¬C) (" + (b - c) / (1 - c) + ") sein.";
                        ResetBabhCInput(4);
                    }
                    else
                    {
                        bc100 = 1 - bc110;
                        bc111 = (b - bc110 * (1 - c)) / c;
                        bc101 = 1 - bc111;
                        bc010 = bc110;
                        bc000 = bc100;
                        bc011 = bc111;
                        bc001 = bc101;
                        double[] val = new[] { bc111, bc011, bc101, bc001, bc110, bc010, bc100, bc000 };
                        SetBabhCValues(4, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputBabhC010)
            {
                bc010 = -1;
                if (InputBabhC010.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetBabhCInput();
                }
                else if (!double.TryParse(InputBabhC010.Text.Replace(".", ","), out bc010) || !IsValidInput(bc010))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if (b / (1 - c) < bc010)
                    {
                        labelInputError2.Text = "Der Wert für P(B|¬C) muss kleiner als der Quotient P(B)/P(¬C) (" + b / (1 - c) + ") sein.";
                        ResetBabhCInput(5);
                    }
                    else if ((b - c) / (1 - c) > bc010)
                    {
                        labelInputError2.Text = "Der Wert für P(B|¬C) muss größer als der Quotient (P(B)-P(C))/P(¬C) (" + (b - c) / (1 - c) + ") sein.";
                        ResetBabhCInput(5);
                    }
                    else
                    {
                        bc000 = 1 - bc010;
                        bc011 = (b - bc010 * (1 - c)) / c;
                        bc001 = 1 - bc011;
                        bc110 = bc010;
                        bc100 = bc000;
                        bc111 = bc011;
                        bc101 = bc001;
                        double[] val = new[] { bc111, bc011, bc101, bc001, bc110, bc010, bc100, bc000 };
                        SetBabhCValues(5, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputBabhC100)
            {
                bc100 = -1;
                if (InputBabhC100.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetBabhCInput();
                }
                else if (!double.TryParse(InputBabhC100.Text.Replace(".", ","), out bc100) || !IsValidInput(bc100))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if ((1 - b) / (1 - c) < bc100)
                    {
                        labelInputError2.Text = "Der Wert für P(¬B|¬C) muss kleiner als der Quotient P(¬B)/P(¬C) (" + (1 - b) / (1 - c) + ") sein.";
                        ResetBabhCInput(6);
                    }
                    else if (((1 - b) - c) / (1 - c) > bc100)
                    {
                        labelInputError2.Text = "Der Wert für P(¬B|¬C) muss größer als der Quotient (P(¬B)-P(C))/P(¬C) (" + ((1 - b) - c) / (1 - c) + ") sein.";
                        ResetBabhCInput(6);
                    }
                    else
                    {
                        bc110 = 1 - bc100;
                        bc111 = (b - bc110 * (1 - c)) / c;
                        bc101 = 1 - bc111;
                        bc000 = bc100;
                        bc010 = bc110;
                        bc011 = bc111;
                        bc001 = bc101;
                        double[] val = new[] { bc111, bc011, bc101, bc001, bc110, bc010, bc100, bc000 };
                        SetBabhCValues(6, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
            else if (sender == InputBabhC000)
            {
                bc000 = -1;
                if (InputBabhC000.Text == "")
                {
                    labelInputError2.Text = String.Empty;
                    ResetBabhCInput();
                }
                else if (!double.TryParse(InputBabhC000.Text.Replace(".", ","), out bc000) || !IsValidInput(bc000))
                {
                    labelInputError2.Text = "Die angegebenen Werte müssen mindestens 0 und maximal 1 sein.";
                }
                else
                {
                    if ((1 - b) / (1 - c) < bc000)
                    {
                        labelInputError2.Text = "Der Wert für P(¬B|¬C) muss kleiner als der Quotient P(¬B)/P(¬C) (" + (1 - b) / (1 - c) + ") sein.";
                        ResetBabhCInput(7);
                    }
                    else if (((1 - b) - c) / (1 - c) > bc000)
                    {
                        labelInputError2.Text = "Der Wert für P(¬B|¬C) muss größer als der Quotient (P(¬B)-P(C))/P(¬C) (" + ((1 - b) - c) / (1 - c) + ") sein.";
                        ResetBabhCInput(7);
                    }
                    else
                    {
                        bc010 = 1 - bc000;
                        bc011 = (b - bc010 * (1 - c)) / c;
                        bc001 = 1 - bc011;
                        bc100 = bc000;
                        bc110 = bc010;
                        bc111 = bc011;
                        bc101 = bc001;
                        double[] val = new[] { bc111, bc011, bc101, bc001, bc110, bc010, bc100, bc000 };
                        SetBabhCValues(7, val);
                        labelInputError2.Text = String.Empty;
                    }
                }
            }
        }
        private void CreateResults()
        {
            double resABunabh, resABabh, resABCunabh, resABCabh = 0;

            if (relAB.SelectedIndex == 0)
            {
                resABunabh = a * b;
                if (relABC.SelectedIndex == 0)
                {
                    resABCunabh = resABunabh * c;
                    outputUnabh.Text = "P(R) = " + resABCunabh.ToString();
                }
                else if (relABC.SelectedIndex == 1)
                {
                    resABCunabh = resABunabh + c - (resABunabh * c);
                    outputUnabh.Text = "P(R) = " + resABCunabh.ToString();
                }
            }
            else if (relAB.SelectedIndex == 1)
            {
                resABunabh = a + b - (a * b);
                if (relABC.SelectedIndex == 0)
                {
                    resABCunabh = resABunabh * c;
                    outputUnabh.Text = "P(R) = " + resABCunabh.ToString();
                }
                else if (relABC.SelectedIndex == 1)
                {
                    resABCunabh = resABunabh + c - (resABunabh * c);
                    outputUnabh.Text = "P(R) = " + resABCunabh.ToString();
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
        private void InputBabhC111_TextChanged(object sender, EventArgs e)
        {
            GetValues_BabhC(sender);
        }

        private void InputBabhC011_TextChanged(object sender, EventArgs e)
        {
            GetValues_BabhC(sender);
        }

        private void InputBabhC101_TextChanged(object sender, EventArgs e)
        {
            GetValues_BabhC(sender);
        }

        private void InputBabhC001_TextChanged(object sender, EventArgs e)
        {
            GetValues_BabhC(sender);
        }

        private void InputBabhC110_TextChanged(object sender, EventArgs e)
        {
            GetValues_BabhC(sender);
        }

        private void InputBabhC010_TextChanged(object sender, EventArgs e)
        {
            GetValues_BabhC(sender);
        }

        private void InputBabhC100_TextChanged(object sender, EventArgs e)
        {
            GetValues_BabhC(sender);
        }

        private void InputBabhC000_TextChanged(object sender, EventArgs e)
        {
            GetValues_BabhC(sender);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (IsValidInputABC(a, b, c))
            {
                if (InputAabhB111.Text == "") SetAunabhB();
                if (InputBabhC111.Text == "") SetBunabhC();
                CreateResults();
            }
            else
            {
                labelInputError1.Text = "Bitte geben Sie zulässige Werte an. (Werte zwischen 0 und 1)";
            }
        }
    }
}
