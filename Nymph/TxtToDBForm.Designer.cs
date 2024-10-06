namespace DarkPrinc3_DB_Editor
{
    partial class TxtToDBForm
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
            this.InsertToDB = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.Label();
            this.addTxt = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // InsertToDB
            // 
            this.InsertToDB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.InsertToDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InsertToDB.Location = new System.Drawing.Point(12, 12);
            this.InsertToDB.Name = "InsertToDB";
            this.InsertToDB.Size = new System.Drawing.Size(166, 23);
            this.InsertToDB.TabIndex = 6;
            this.InsertToDB.Text = "Txt Verilerini Tabloya Aktar";
            this.InsertToDB.UseVisualStyleBackColor = true;
            this.InsertToDB.Click += new System.EventHandler(this.InsertToDB_Click);
            // 
            // txtPath
            // 
            this.txtPath.AutoSize = true;
            this.txtPath.Location = new System.Drawing.Point(193, 46);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(0, 13);
            this.txtPath.TabIndex = 5;
            // 
            // addTxt
            // 
            this.addTxt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.addTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTxt.Location = new System.Drawing.Point(12, 41);
            this.addTxt.Name = "addTxt";
            this.addTxt.Size = new System.Drawing.Size(166, 23);
            this.addTxt.TabIndex = 4;
            this.addTxt.Text = "Txt Yükle";
            this.addTxt.UseVisualStyleBackColor = true;
            this.addTxt.Click += new System.EventHandler(this.addTxt_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Linen;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.Location = new System.Drawing.Point(12, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(855, 357);
            this.dataGridView1.TabIndex = 7;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(676, 43);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(191, 20);
            this.searchTextBox.TabIndex = 8;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(592, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "CodeName128";
            // 
            // TxtToDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 438);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.InsertToDB);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.addTxt);
            this.Name = "TxtToDBForm";
            this.Text = "TxtToDBForm";
            this.Load += new System.EventHandler(this.TxtToDBForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InsertToDB;
        private System.Windows.Forms.Label txtPath;
        private System.Windows.Forms.Button addTxt;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label1;
    }
}