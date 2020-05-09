namespace ExamRevision
{
    partial class Form3
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gettableButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.cascadeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(793, 384);
            this.dataGridView1.TabIndex = 0;
            // 
            // gettableButton
            // 
            this.gettableButton.Location = new System.Drawing.Point(12, 403);
            this.gettableButton.Name = "gettableButton";
            this.gettableButton.Size = new System.Drawing.Size(130, 26);
            this.gettableButton.TabIndex = 1;
            this.gettableButton.Text = "Get Table";
            this.gettableButton.UseVisualStyleBackColor = true;
            this.gettableButton.Click += new System.EventHandler(this.gettableButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(466, 406);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(90, 23);
            this.createButton.TabIndex = 2;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // cascadeButton
            // 
            this.cascadeButton.Location = new System.Drawing.Point(562, 406);
            this.cascadeButton.Name = "cascadeButton";
            this.cascadeButton.Size = new System.Drawing.Size(138, 23);
            this.cascadeButton.TabIndex = 3;
            this.cascadeButton.Text = "Cascade Delete";
            this.cascadeButton.UseVisualStyleBackColor = true;
            this.cascadeButton.Click += new System.EventHandler(this.cascadeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(706, 406);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(99, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 441);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.cascadeButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.gettableButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button gettableButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button cascadeButton;
        private System.Windows.Forms.Button deleteButton;
    }
}