namespace Nymph
{
    partial class ExcellForm
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
            this.addExcell = new System.Windows.Forms.Button();
            this.excellPath = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.autoExcell = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // addExcell
            // 
            this.addExcell.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.addExcell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addExcell.Location = new System.Drawing.Point(12, 40);
            this.addExcell.Name = "addExcell";
            this.addExcell.Size = new System.Drawing.Size(166, 23);
            this.addExcell.TabIndex = 0;
            this.addExcell.Text = "Manuel Excel Yükle";
            this.addExcell.UseVisualStyleBackColor = true;
            this.addExcell.Click += new System.EventHandler(this.addExcell_Click);
            // 
            // excellPath
            // 
            this.excellPath.AutoSize = true;
            this.excellPath.Location = new System.Drawing.Point(193, 45);
            this.excellPath.Name = "excellPath";
            this.excellPath.Size = new System.Drawing.Size(0, 13);
            this.excellPath.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Linen;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.Location = new System.Drawing.Point(12, 69);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(855, 357);
            this.dataGridView1.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // autoExcell
            // 
            this.autoExcell.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.autoExcell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.autoExcell.Location = new System.Drawing.Point(12, 11);
            this.autoExcell.Name = "autoExcell";
            this.autoExcell.Size = new System.Drawing.Size(166, 23);
            this.autoExcell.TabIndex = 3;
            this.autoExcell.Text = "Klasördeki Excelleri Analiz Et";
            this.autoExcell.UseVisualStyleBackColor = true;
            // 
            // ExcellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 438);
            this.Controls.Add(this.autoExcell);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.excellPath);
            this.Controls.Add(this.addExcell);
            this.Name = "ExcellForm";
            this.Text = "ExcellForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addExcell;
        private System.Windows.Forms.Label excellPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button autoExcell;
    }
}