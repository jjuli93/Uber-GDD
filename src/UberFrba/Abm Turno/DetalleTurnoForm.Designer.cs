namespace UberFrba.Abm_Turno
{
    partial class DetalleTurnoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.habilitadoCheckBox = new System.Windows.Forms.CheckBox();
            this.precioNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.kmNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.beginDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.volverButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precioNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kmNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.habilitadoCheckBox);
            this.groupBox1.Controls.Add(this.precioNumericUpDown);
            this.groupBox1.Controls.Add(this.kmNumericUpDown);
            this.groupBox1.Controls.Add(this.endDateTimePicker);
            this.groupBox1.Controls.Add(this.beginDateTimePicker);
            this.groupBox1.Controls.Add(this.descripcionTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 238);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del turno";
            // 
            // habilitadoCheckBox
            // 
            this.habilitadoCheckBox.AutoSize = true;
            this.habilitadoCheckBox.Enabled = false;
            this.habilitadoCheckBox.Location = new System.Drawing.Point(24, 202);
            this.habilitadoCheckBox.Name = "habilitadoCheckBox";
            this.habilitadoCheckBox.Size = new System.Drawing.Size(73, 17);
            this.habilitadoCheckBox.TabIndex = 34;
            this.habilitadoCheckBox.Text = "Habilitado";
            this.habilitadoCheckBox.UseVisualStyleBackColor = true;
            // 
            // precioNumericUpDown
            // 
            this.precioNumericUpDown.Enabled = false;
            this.precioNumericUpDown.Location = new System.Drawing.Point(159, 161);
            this.precioNumericUpDown.Name = "precioNumericUpDown";
            this.precioNumericUpDown.Size = new System.Drawing.Size(99, 20);
            this.precioNumericUpDown.TabIndex = 33;
            // 
            // kmNumericUpDown
            // 
            this.kmNumericUpDown.Enabled = false;
            this.kmNumericUpDown.Location = new System.Drawing.Point(159, 129);
            this.kmNumericUpDown.Name = "kmNumericUpDown";
            this.kmNumericUpDown.Size = new System.Drawing.Size(99, 20);
            this.kmNumericUpDown.TabIndex = 32;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Enabled = false;
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endDateTimePicker.Location = new System.Drawing.Point(160, 63);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.ShowUpDown = true;
            this.endDateTimePicker.Size = new System.Drawing.Size(99, 20);
            this.endDateTimePicker.TabIndex = 31;
            // 
            // beginDateTimePicker
            // 
            this.beginDateTimePicker.Enabled = false;
            this.beginDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.beginDateTimePicker.Location = new System.Drawing.Point(159, 32);
            this.beginDateTimePicker.Name = "beginDateTimePicker";
            this.beginDateTimePicker.ShowUpDown = true;
            this.beginDateTimePicker.Size = new System.Drawing.Size(99, 20);
            this.beginDateTimePicker.TabIndex = 30;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.Enabled = false;
            this.descripcionTextBox.Location = new System.Drawing.Point(159, 96);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(211, 20);
            this.descripcionTextBox.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Precio base del turno [$]:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Valor del kilómetro [$]:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Descripción:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Hora de finalización:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Hora de inicio:";
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(37, 271);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(75, 23);
            this.volverButton.TabIndex = 35;
            this.volverButton.Text = "<< Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // DetalleTurnoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 316);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "DetalleTurnoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle del Turno";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precioNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kmNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown precioNumericUpDown;
        private System.Windows.Forms.NumericUpDown kmNumericUpDown;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DateTimePicker beginDateTimePicker;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox habilitadoCheckBox;
        private System.Windows.Forms.Button volverButton;
    }
}