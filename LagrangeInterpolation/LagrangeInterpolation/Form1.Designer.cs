namespace LagrangeInterpolation
{
    partial class CanvasForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainCanvas = new System.Windows.Forms.PictureBox();
            this.TCanvas = new System.Windows.Forms.PictureBox();
            this.ChordLCB = new System.Windows.Forms.CheckBox();
            this.CLBtn = new System.Windows.Forms.Button();
            this.LagrangeOrGaussCB = new System.Windows.Forms.CheckBox();
            this.ClearBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // MainCanvas
            // 
            this.MainCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainCanvas.BackColor = System.Drawing.Color.White;
            this.MainCanvas.Location = new System.Drawing.Point(13, 13);
            this.MainCanvas.Name = "MainCanvas";
            this.MainCanvas.Size = new System.Drawing.Size(1106, 477);
            this.MainCanvas.TabIndex = 0;
            this.MainCanvas.TabStop = false;
            this.MainCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.MainCanvas_Paint);
            this.MainCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainCanvas_MouseDown);
            this.MainCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainCanvas_MouseMove);
            this.MainCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainCanvas_MouseUp);
            // 
            // TCanvas
            // 
            this.TCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TCanvas.BackColor = System.Drawing.Color.White;
            this.TCanvas.Location = new System.Drawing.Point(12, 533);
            this.TCanvas.Name = "TCanvas";
            this.TCanvas.Size = new System.Drawing.Size(1107, 60);
            this.TCanvas.TabIndex = 1;
            this.TCanvas.TabStop = false;
            this.TCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.TCanvas_Paint);
            this.TCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TCanvas_MouseDown);
            this.TCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TCanvas_MouseMove);
            this.TCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TCanvas_MouseUp);
            // 
            // ChordLCB
            // 
            this.ChordLCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ChordLCB.AutoSize = true;
            this.ChordLCB.Location = new System.Drawing.Point(408, 502);
            this.ChordLCB.Name = "ChordLCB";
            this.ChordLCB.Size = new System.Drawing.Size(137, 20);
            this.ChordLCB.TabIndex = 2;
            this.ChordLCB.Text = "Use chord lengths";
            this.ChordLCB.UseVisualStyleBackColor = true;
            this.ChordLCB.CheckedChanged += new System.EventHandler(this.ChordLCB_CheckedChanged);
            // 
            // CLBtn
            // 
            this.CLBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CLBtn.Location = new System.Drawing.Point(581, 496);
            this.CLBtn.Name = "CLBtn";
            this.CLBtn.Size = new System.Drawing.Size(137, 31);
            this.CLBtn.TabIndex = 3;
            this.CLBtn.Text = "Set chord length";
            this.CLBtn.UseVisualStyleBackColor = true;
            this.CLBtn.Click += new System.EventHandler(this.CLBtn_Click);
            // 
            // LagrangeOrGaussCB
            // 
            this.LagrangeOrGaussCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LagrangeOrGaussCB.AutoSize = true;
            this.LagrangeOrGaussCB.Checked = true;
            this.LagrangeOrGaussCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LagrangeOrGaussCB.Location = new System.Drawing.Point(12, 502);
            this.LagrangeOrGaussCB.Name = "LagrangeOrGaussCB";
            this.LagrangeOrGaussCB.Size = new System.Drawing.Size(353, 20);
            this.LagrangeOrGaussCB.TabIndex = 4;
            this.LagrangeOrGaussCB.Text = "Use Lagrange Interpolation insted of Gauss elimination";
            this.LagrangeOrGaussCB.UseVisualStyleBackColor = true;
            this.LagrangeOrGaussCB.CheckedChanged += new System.EventHandler(this.LagrangeOrGaussCB_CheckedChanged);
            // 
            // ClearBTN
            // 
            this.ClearBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ClearBTN.Location = new System.Drawing.Point(724, 496);
            this.ClearBTN.Name = "ClearBTN";
            this.ClearBTN.Size = new System.Drawing.Size(137, 31);
            this.ClearBTN.TabIndex = 5;
            this.ClearBTN.Text = "Clear canvas";
            this.ClearBTN.UseVisualStyleBackColor = true;
            this.ClearBTN.Click += new System.EventHandler(this.ClearBTN_Click);
            // 
            // CanvasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 605);
            this.Controls.Add(this.ClearBTN);
            this.Controls.Add(this.LagrangeOrGaussCB);
            this.Controls.Add(this.CLBtn);
            this.Controls.Add(this.ChordLCB);
            this.Controls.Add(this.TCanvas);
            this.Controls.Add(this.MainCanvas);
            this.Name = "CanvasForm";
            this.Text = "Lagrange interpolation";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.MainCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainCanvas;
        private System.Windows.Forms.PictureBox TCanvas;
        private System.Windows.Forms.CheckBox ChordLCB;
        private System.Windows.Forms.Button CLBtn;
        private System.Windows.Forms.CheckBox LagrangeOrGaussCB;
        private System.Windows.Forms.Button ClearBTN;
    }
}

