namespace UberFrba.Abm_Automovil
{
    partial class ModificarAutomovilForm
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
            this.habilitarCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.guardarButton = new System.Windows.Forms.Button();
            this.turnoComboBox = new System.Windows.Forms.ComboBox();
            this.nombreChoferTB = new System.Windows.Forms.TextBox();
            this.buscarChoferButton = new System.Windows.Forms.Button();
            this.patenteTextBox = new System.Windows.Forms.TextBox();
            this.modeloTextBox = new System.Windows.Forms.TextBox();
            this.marcaComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rodadoTextBox = new System.Windows.Forms.TextBox();
            this.licenciaTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rodadoTextBox);
            this.groupBox1.Controls.Add(this.licenciaTextBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.habilitarCheckBox);
            this.groupBox1.Controls.Add(this.cancelarButton);
            this.groupBox1.Controls.Add(this.guardarButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 390);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar automovil";
            // 
            // habilitarCheckBox
            // 
            this.habilitarCheckBox.AutoSize = true;
            this.habilitarCheckBox.Location = new System.Drawing.Point(37, 306);
            this.habilitarCheckBox.Name = "habilitarCheckBox";
            this.habilitarCheckBox.Size = new System.Drawing.Size(64, 17);
            this.habilitarCheckBox.TabIndex = 3;
            this.habilitarCheckBox.Text = "Habilitar";
            this.habilitarCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(26, 349);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 2;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(194, 349);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(116, 23);
            this.guardarButton.TabIndex = 1;
            this.guardarButton.Text = "Guardar cambios";
            this.guardarButton.UseVisualStyleBackColor = true;
            // 
            // turnoComboBox
            // 
            this.turnoComboBox.FormattingEnabled = true;
            this.turnoComboBox.Location = new System.Drawing.Point(122, 204);
            this.turnoComboBox.Name = "turnoComboBox";
            this.turnoComboBox.Size = new System.Drawing.Size(190, 21);
            this.turnoComboBox.TabIndex = 21;
            // 
            // nombreChoferTB
            // 
            this.nombreChoferTB.Location = new System.Drawing.Point(40, 172);
            this.nombreChoferTB.Name = "nombreChoferTB";
            this.nombreChoferTB.ReadOnly = true;
            this.nombreChoferTB.Size = new System.Drawing.Size(285, 20);
            this.nombreChoferTB.TabIndex = 20;
            // 
            // buscarChoferButton
            // 
            this.buscarChoferButton.Location = new System.Drawing.Point(122, 135);
            this.buscarChoferButton.Name = "buscarChoferButton";
            this.buscarChoferButton.Size = new System.Drawing.Size(75, 23);
            this.buscarChoferButton.TabIndex = 19;
            this.buscarChoferButton.Text = "Buscar";
            this.buscarChoferButton.UseVisualStyleBackColor = true;
            this.buscarChoferButton.Click += new System.EventHandler(this.buscarChoferButton_Click);
            // 
            // patenteTextBox
            // 
            this.patenteTextBox.Location = new System.Drawing.Point(122, 105);
            this.patenteTextBox.Name = "patenteTextBox";
            this.patenteTextBox.Size = new System.Drawing.Size(190, 20);
            this.patenteTextBox.TabIndex = 18;
            // 
            // modeloTextBox
            // 
            this.modeloTextBox.Location = new System.Drawing.Point(122, 74);
            this.modeloTextBox.Name = "modeloTextBox";
            this.modeloTextBox.Size = new System.Drawing.Size(190, 20);
            this.modeloTextBox.TabIndex = 17;
            // 
            // marcaComboBox
            // 
            this.marcaComboBox.FormattingEnabled = true;
            this.marcaComboBox.Location = new System.Drawing.Point(122, 42);
            this.marcaComboBox.Name = "marcaComboBox";
            this.marcaComboBox.Size = new System.Drawing.Size(190, 21);
            this.marcaComboBox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Turno: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Chofer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Patente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Modelo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Marca: ";
            // 
            // rodadoTextBox
            // 
            this.rodadoTextBox.Location = new System.Drawing.Point(109, 265);
            this.rodadoTextBox.Name = "rodadoTextBox";
            this.rodadoTextBox.Size = new System.Drawing.Size(190, 20);
            this.rodadoTextBox.TabIndex = 30;
            // 
            // licenciaTextBox
            // 
            this.licenciaTextBox.Location = new System.Drawing.Point(117, 229);
            this.licenciaTextBox.Name = "licenciaTextBox";
            this.licenciaTextBox.Size = new System.Drawing.Size(182, 20);
            this.licenciaTextBox.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(35, 268);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Rodado:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 232);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Licencia Nro. :";
            // 
            // ModificarAutomovilForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 415);
            this.Controls.Add(this.turnoComboBox);
            this.Controls.Add(this.nombreChoferTB);
            this.Controls.Add(this.buscarChoferButton);
            this.Controls.Add(this.patenteTextBox);
            this.Controls.Add(this.modeloTextBox);
            this.Controls.Add(this.marcaComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificarAutomovilForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Automovil";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox turnoComboBox;
        private System.Windows.Forms.TextBox nombreChoferTB;
        private System.Windows.Forms.Button buscarChoferButton;
        private System.Windows.Forms.TextBox patenteTextBox;
        private System.Windows.Forms.TextBox modeloTextBox;
        private System.Windows.Forms.ComboBox marcaComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.CheckBox habilitarCheckBox;
        private System.Windows.Forms.TextBox rodadoTextBox;
        private System.Windows.Forms.TextBox licenciaTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
    }
}