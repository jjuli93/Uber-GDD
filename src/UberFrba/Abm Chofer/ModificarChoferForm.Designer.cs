namespace UberFrba.Abm_Chofer
{
    partial class ModificarChoferForm
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
            this.fnDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.habilitarCheckBox = new System.Windows.Forms.CheckBox();
            this.mailTextBox = new System.Windows.Forms.TextBox();
            this.telefonoTextBox = new System.Windows.Forms.TextBox();
            this.direccionTextBox = new System.Windows.Forms.TextBox();
            this.dniTextBox = new System.Windows.Forms.TextBox();
            this.apeliidoTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.guardarButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fnDateTimePicker);
            this.groupBox1.Controls.Add(this.habilitarCheckBox);
            this.groupBox1.Controls.Add(this.mailTextBox);
            this.groupBox1.Controls.Add(this.telefonoTextBox);
            this.groupBox1.Controls.Add(this.direccionTextBox);
            this.groupBox1.Controls.Add(this.dniTextBox);
            this.groupBox1.Controls.Add(this.apeliidoTextBox);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 292);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar un chofer";
            // 
            // fnDateTimePicker
            // 
            this.fnDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fnDateTimePicker.Location = new System.Drawing.Point(138, 221);
            this.fnDateTimePicker.Name = "fnDateTimePicker";
            this.fnDateTimePicker.Size = new System.Drawing.Size(190, 20);
            this.fnDateTimePicker.TabIndex = 82;
            // 
            // habilitarCheckBox
            // 
            this.habilitarCheckBox.AutoSize = true;
            this.habilitarCheckBox.Location = new System.Drawing.Point(25, 255);
            this.habilitarCheckBox.Name = "habilitarCheckBox";
            this.habilitarCheckBox.Size = new System.Drawing.Size(64, 17);
            this.habilitarCheckBox.TabIndex = 32;
            this.habilitarCheckBox.Text = "Habilitar";
            this.habilitarCheckBox.UseVisualStyleBackColor = true;
            // 
            // mailTextBox
            // 
            this.mailTextBox.Location = new System.Drawing.Point(90, 188);
            this.mailTextBox.Name = "mailTextBox";
            this.mailTextBox.Size = new System.Drawing.Size(190, 20);
            this.mailTextBox.TabIndex = 28;
            // 
            // telefonoTextBox
            // 
            this.telefonoTextBox.Location = new System.Drawing.Point(90, 157);
            this.telefonoTextBox.MaxLength = 12;
            this.telefonoTextBox.Name = "telefonoTextBox";
            this.telefonoTextBox.Size = new System.Drawing.Size(145, 20);
            this.telefonoTextBox.TabIndex = 27;
            this.telefonoTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telefonoTextBox_KeyPress);
            // 
            // direccionTextBox
            // 
            this.direccionTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.direccionTextBox.Location = new System.Drawing.Point(130, 124);
            this.direccionTextBox.Name = "direccionTextBox";
            this.direccionTextBox.Size = new System.Drawing.Size(198, 20);
            this.direccionTextBox.TabIndex = 26;
            // 
            // dniTextBox
            // 
            this.dniTextBox.Location = new System.Drawing.Point(90, 92);
            this.dniTextBox.MaxLength = 10;
            this.dniTextBox.Name = "dniTextBox";
            this.dniTextBox.Size = new System.Drawing.Size(145, 20);
            this.dniTextBox.TabIndex = 25;
            this.dniTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dniTextBox_KeyPress);
            // 
            // apeliidoTextBox
            // 
            this.apeliidoTextBox.Location = new System.Drawing.Point(90, 62);
            this.apeliidoTextBox.Name = "apeliidoTextBox";
            this.apeliidoTextBox.Size = new System.Drawing.Size(190, 20);
            this.apeliidoTextBox.TabIndex = 24;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Location = new System.Drawing.Point(90, 32);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(190, 20);
            this.nombreTextBox.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Fecha de nacimiento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Mail:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Teléfono:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Direccion completa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "DNI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Apellido:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre: ";
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(38, 312);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 1;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(231, 312);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(109, 23);
            this.guardarButton.TabIndex = 2;
            this.guardarButton.Text = "Guardar cambios";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ModificarChoferForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 349);
            this.Controls.Add(this.guardarButton);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificarChoferForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar un Chofer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox habilitarCheckBox;
        private System.Windows.Forms.TextBox mailTextBox;
        private System.Windows.Forms.TextBox telefonoTextBox;
        private System.Windows.Forms.TextBox direccionTextBox;
        private System.Windows.Forms.TextBox dniTextBox;
        private System.Windows.Forms.TextBox apeliidoTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DateTimePicker fnDateTimePicker;
    }
}