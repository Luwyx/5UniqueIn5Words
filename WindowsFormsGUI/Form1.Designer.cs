namespace WindowsFormsGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnRunSolver;
        private System.Windows.Forms.Button btnExport;
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
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.BtnSolve = new System.Windows.Forms.Button();
            this.BtnExport = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTimeTaken = new System.Windows.Forms.Label();
            this.lblCombinationsFound = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(28, 34);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(100, 278);
            this.BtnBrowse.TabIndex = 0;
            this.BtnBrowse.Text = "Import";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // BtnSolve
            // 
            this.BtnSolve.Location = new System.Drawing.Point(670, 34);
            this.BtnSolve.Name = "BtnSolve";
            this.BtnSolve.Size = new System.Drawing.Size(101, 278);
            this.BtnSolve.TabIndex = 1;
            this.BtnSolve.Text = "Calculate";
            this.BtnSolve.UseVisualStyleBackColor = true;
            this.BtnSolve.Click += new System.EventHandler(this.btnRunSolver_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Location = new System.Drawing.Point(466, 331);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(187, 50);
            this.BtnExport.TabIndex = 2;
            this.BtnExport.Text = "Export";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(149, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(504, 278);
            this.dataGridView1.TabIndex = 0;
            // 
            // lblTimeTaken
            // 
            this.lblTimeTaken.AutoSize = true;
            this.lblTimeTaken.Location = new System.Drawing.Point(160, 365);
            this.lblTimeTaken.Name = "lblTimeTaken";
            this.lblTimeTaken.Size = new System.Drawing.Size(83, 16);
            this.lblTimeTaken.TabIndex = 6;
            this.lblTimeTaken.Text = "Time Taken:";
            // 
            // lblCombinationsFound
            // 
            this.lblCombinationsFound.AutoSize = true;
            this.lblCombinationsFound.Location = new System.Drawing.Point(160, 331);
            this.lblCombinationsFound.Name = "lblCombinationsFound";
            this.lblCombinationsFound.Size = new System.Drawing.Size(133, 16);
            this.lblCombinationsFound.TabIndex = 5;
            this.lblCombinationsFound.Text = "Combinations Found:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTimeTaken);
            this.Controls.Add(this.lblCombinationsFound);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.BtnSolve);
            this.Controls.Add(this.BtnBrowse);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.Button BtnSolve;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTimeTaken;
        private System.Windows.Forms.Label lblCombinationsFound;
    }
}

