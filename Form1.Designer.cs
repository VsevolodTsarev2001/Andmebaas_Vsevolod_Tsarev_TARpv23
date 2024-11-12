namespace Andmebaas_Vsevolod_Tsarev_TARpv23
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Nimetus_txt = new System.Windows.Forms.TextBox();
            this.Kogus_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Hind_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.andmebaasDataSet = new Andmebaas_Vsevolod_Tsarev_TARpv23.AndmebaasDataSet();
            this.andmebaasDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toodeTableAdapter = new Andmebaas_Vsevolod_Tsarev_TARpv23.AndmebaasDataSetTableAdapters.ToodeTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.andmebaasDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.andmebaasDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label1.Location = new System.Drawing.Point(21, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nimetus";
            // 
            // Nimetus_txt
            // 
            this.Nimetus_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Nimetus_txt.Location = new System.Drawing.Point(120, 38);
            this.Nimetus_txt.Name = "Nimetus_txt";
            this.Nimetus_txt.Size = new System.Drawing.Size(100, 32);
            this.Nimetus_txt.TabIndex = 1;
            // 
            // Kogus_txt
            // 
            this.Kogus_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Kogus_txt.Location = new System.Drawing.Point(120, 91);
            this.Kogus_txt.Name = "Kogus_txt";
            this.Kogus_txt.Size = new System.Drawing.Size(100, 32);
            this.Kogus_txt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(40, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kogus";
            // 
            // Hind_txt
            // 
            this.Hind_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Hind_txt.Location = new System.Drawing.Point(120, 139);
            this.Hind_txt.Name = "Hind_txt";
            this.Hind_txt.Size = new System.Drawing.Size(100, 32);
            this.Hind_txt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.Location = new System.Drawing.Point(57, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hind";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 245);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(748, 179);
            this.dataGridView1.TabIndex = 6;
            // 
            // toodeBindingSource
            // 
            this.toodeBindingSource.DataMember = "Toode";
            this.toodeBindingSource.DataSource = this.andmebaasDataSet;
            // 
            // andmebaasDataSet
            // 
            this.andmebaasDataSet.DataSetName = "AndmebaasDataSet";
            this.andmebaasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // andmebaasDataSetBindingSource
            // 
            this.andmebaasDataSetBindingSource.DataSource = this.andmebaasDataSet;
            this.andmebaasDataSetBindingSource.Position = 0;
            // 
            // toodeTableAdapter
            // 
            this.toodeTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.button1.Location = new System.Drawing.Point(26, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 47);
            this.button1.TabIndex = 7;
            this.button1.Text = "Lisa andmed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.button2.Location = new System.Drawing.Point(207, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 47);
            this.button2.TabIndex = 8;
            this.button2.Text = "Kustuta andmed";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.button3.Location = new System.Drawing.Point(395, 192);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(195, 47);
            this.button3.TabIndex = 9;
            this.button3.Text = "Uuenda andmed";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Hind_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Kogus_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Nimetus_txt);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.andmebaasDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.andmebaasDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Nimetus_txt;
        private System.Windows.Forms.TextBox Kogus_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Hind_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource andmebaasDataSetBindingSource;
        private AndmebaasDataSet andmebaasDataSet;
        private System.Windows.Forms.BindingSource toodeBindingSource;
        private AndmebaasDataSetTableAdapters.ToodeTableAdapter toodeTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

