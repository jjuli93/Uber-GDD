namespace UberFrba.Abm_Turno
{
    partial class ModificarTurnoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.guardarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.habilitarCheckBox = new System.Windows.Forms.CheckBox();
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
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precioNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kmNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.guardarButton);
            this.groupBox1.Controls.Add(this.cancelarButton);
            this.groupBox1.Controls.Add(this.habilitarCheckBox);
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
            this.groupBox1.Size = new System.Drawing.Size(410, 299);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificación de turno";
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(261, 248);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(117, 23);
            this.guardarButton.TabIndex = 36;
            this.guardarButton.Text = "Guardar cambios";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(33, 249);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 35;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // habilitarCheckBox
            // 
            this.habilitarCheckBox.AutoSize = true;
            this.habilitarCheckBox.Location = new System.Drawing.Point(33, 202);
            this.habilitarCheckBox.Name = "habilitarCheckBox";
            this.habilitarCheckBox.Size = new System.Drawing.Size(64, 17);
            this.habilitarCheckBox.TabIndex = 34;
            this.habilitarCheckBox.Text = "Habilitar";
            this.habilitarCheckBox.UseVisualStyleBackColor = true;
            // 
            // precioNumericUpDown
            // 
            this.precioNumericUpDown.Location = new System.Drawing.Point(168, 164);
            this.precioNumericUpDown.Name = "precioNumericUpDown";
            this.precioNumericUpDown.Size = new System.Drawing.Size(99, 20);
            this.precioNumericUpDown.TabIndex = 33;
            // 
            // kmNumericUpDown
            // 
            this.kmNumericUpDown.Location = new System.Drawing.Point(168, 132);
            this.kmNumericUpDown.Name = "kmNumericUpDown";
            this.kmNumericUpDown.Size = new System.Drawing.Size(99, 20);
            this.kmNumericUpDown.TabIndex = 32;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.endDateTimePicker.Location = new System.Drawing.Point(168, 66);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.ShowUpDown = true;
            this.endDateTimePicker.Size = new System.Drawing.Size(99, 20);
            this.endDateTimePicker.TabIndex = 31;
            // 
            // beginDateTimePicker
            // 
            this.beginDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.beginDateTimePicker.Location = new System.Drawing.Point(168, 35);
            this.beginDateTimePicker.Name = "beginDateTimePicker";
            this.beginDateTimePicker.ShowUpDown = true;
            this.beginDateTimePicker.Size = new System.Drawing.Size(99, 20);
            this.beginDateTimePicker.TabIndex = 30;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.Location = new System.Drawing.Point(168, 99);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(211, 20);
            this.descripcionTextBox.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Precio base del turno [$]:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Valor del kilómetro [$]:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Descripción:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Hora de finalización:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Hora de inicio:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ModificarTurnoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 324);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificarTurnoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Turno";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.precioNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kmNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox habilitarCheckBox;
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
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}