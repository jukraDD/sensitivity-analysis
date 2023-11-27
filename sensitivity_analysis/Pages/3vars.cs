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
        TextBox[] abhInputs;
        Label[] unabhLabels;

        public _3vars()
        {
            InitializeComponent();
            tableProb.CellPaint += new TableLayoutCellPaintEventHandler(tableProb_CellPaint);
            abhInputs = new[] { InputAabhB111, InputAabhB011, InputAabhB101, InputAabhB001, InputAabhB110, InputAabhB010, InputAabhB100, InputAabhB000, InputAabhC111, InputAabhC011, InputAabhC101, InputAabhC001, InputAabhC110, InputAabhC010, InputAabhC100, InputAabhC000, InputBabhC111, InputBabhC011, InputBabhC101, InputBabhC001, InputBabhC110, InputBabhC010, InputBabhC100, InputBabhC000 };
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

        private void ResetAbhInput()
        {
            foreach (TextBox t in abhInputs)
            {
                t.Text = "";
            }
        }

        private bool IsValidInputABC(double a, double b, double c)
        {
            return !(a < 0 || a > 1 || b < 0 || b > 1 || c < 0 || c > 1);
        }

        private void GetValues_ABC(object sender)
        {
            ResetAbhInput();
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
    }
}
