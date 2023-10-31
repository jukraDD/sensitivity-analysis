namespace sensitivity_analysis
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btn3vars = new System.Windows.Forms.Button();
            this.btn2vars = new System.Windows.Forms.Button();
            this.pageDisplay = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(82)))), ((int)(((byte)(107)))));
            this.panelMenu.Controls.Add(this.btn3vars);
            this.panelMenu.Controls.Add(this.btn2vars);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 561);
            this.panelMenu.TabIndex = 0;
            // 
            // btn3vars
            // 
            this.btn3vars.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn3vars.FlatAppearance.BorderSize = 0;
            this.btn3vars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3vars.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3vars.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn3vars.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn3vars.Location = new System.Drawing.Point(0, 60);
            this.btn3vars.Name = "btn3vars";
            this.btn3vars.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btn3vars.Size = new System.Drawing.Size(220, 60);
            this.btn3vars.TabIndex = 1;
            this.btn3vars.Text = "                 3 Ausgangsvariablen";
            this.btn3vars.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn3vars.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn3vars.UseVisualStyleBackColor = true;
            this.btn3vars.Click += new System.EventHandler(this.btn3vars_Click);
            // 
            // btn2vars
            // 
            this.btn2vars.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn2vars.FlatAppearance.BorderSize = 0;
            this.btn2vars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2vars.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2vars.ForeColor = System.Drawing.Color.Gainsboro;
            this.btn2vars.Image = global::sensitivity_analysis.Properties.Resources.abc1;
            this.btn2vars.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn2vars.Location = new System.Drawing.Point(0, 0);
            this.btn2vars.Name = "btn2vars";
            this.btn2vars.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btn2vars.Size = new System.Drawing.Size(220, 60);
            this.btn2vars.TabIndex = 0;
            this.btn2vars.Text = "    2 Ausgangsvariablen";
            this.btn2vars.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn2vars.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn2vars.UseVisualStyleBackColor = true;
            this.btn2vars.Click += new System.EventHandler(this.btn2vars_Click);
            // 
            // pageDisplay
            // 
            this.pageDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDisplay.Location = new System.Drawing.Point(220, 0);
            this.pageDisplay.Name = "pageDisplay";
            this.pageDisplay.Size = new System.Drawing.Size(580, 561);
            this.pageDisplay.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.pageDisplay);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Sensitivitätsanalyse";
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btn2vars;
        private System.Windows.Forms.Panel pageDisplay;
        private System.Windows.Forms.Button btn3vars;
    }
}

