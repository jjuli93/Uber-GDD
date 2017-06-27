namespace UberFrba.Abm_Automovil
{
    partial class ABMAutomovilForm
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
            this.modeloComboBox = new System.Windows.Forms.ComboBox();
            this.crearButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.turnoComboBox = new System.Windows.Forms.ComboBox();
            this.nombreChoferTB = new System.Windows.Forms.TextBox();
            this.buscarChoferButton = new System.Windows.Forms.Button();
            this.patenteTextBox = new System.Windows.Forms.TextBox();
            this.marcaComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.buscarAutoButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cerrarSesionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.licenciaTextBox = new System.Windows.Forms.TextBox();
            this.rodadoTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.rodadoTextBox);
            this.groupBox1.Controls.Add(this.licenciaTextBox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.modeloComboBox);
            this.groupBox1.Controls.Add(this.crearButton);
            this.groupBox1.Controls.Add(this.cancelarButton);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.turnoComboBox);
            this.groupBox1.Controls.Add(this.nombreChoferTB);
            this.groupBox1.Controls.Add(this.buscarChoferButton);
            this.groupBox1.Controls.Add(this.patenteTextBox);
            this.groupBox1.Controls.Add(this.marcaComboBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 362);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nuevo automovil";
            // 
            // modeloComboBox
            // 
            this.modeloComboBox.FormattingEnabled = true;
            this.modeloComboBox.Location = new System.Drawing.Point(104, 62);
            this.modeloComboBox.Name = "modeloComboBox";
            this.modeloComboBox.Size = new System.Drawing.Size(190, 21);
            this.modeloComboBox.TabIndex = 22;
            // 
            // crearButton
            // 
            this.crearButton.Location = new System.Drawing.Point(220, 330);
            this.crearButton.Name = "crearButton";
            this.crearButton.Size = new System.Drawing.Size(97, 23);
            this.crearButton.TabIndex = 21;
            this.crearButton.Text = "Crear nuevo";
            this.crearButton.UseVisualStyleBackColor = true;
            this.crearButton.Click += new System.EventHandler(this.crearButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(33, 330);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 19;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Dutch801 XBd BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(29, 302);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 14);
            this.label11.TabIndex = 18;
            this.label11.Text = "[*] : campos obligatorios";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Dutch801 XBd BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(300, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Dutch801 XBd BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(201, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Dutch801 XBd BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(300, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Dutch801 XBd BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(300, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Dutch801 XBd BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(300, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "*";
            // 
            // turnoComboBox
            // 
            this.turnoComboBox.FormattingEnabled = true;
            this.turnoComboBox.Location = new System.Drawing.Point(104, 192);
            this.turnoComboBox.Name = "turnoComboBox";
            this.turnoComboBox.Size = new System.Drawing.Size(190, 21);
            this.turnoComboBox.TabIndex = 10;
            // 
            // nombreChoferTB
            // 
            this.nombreChoferTB.Location = new System.Drawing.Point(32, 160);
            this.nombreChoferTB.Name = "nombreChoferTB";
            this.nombreChoferTB.ReadOnly = true;
            this.nombreChoferTB.Size = new System.Drawing.Size(285, 20);
            this.nombreChoferTB.TabIndex = 9;
            // 
            // buscarChoferButton
            // 
            this.buscarChoferButton.Location = new System.Drawing.Point(104, 123);
            this.buscarChoferButton.Name = "buscarChoferButton";
            this.buscarChoferButton.Size = new System.Drawing.Size(75, 23);
            this.buscarChoferButton.TabIndex = 8;
            this.buscarChoferButton.Text = "Buscar";
            this.buscarChoferButton.UseVisualStyleBackColor = true;
            this.buscarChoferButton.Click += new System.EventHandler(this.buscarChoferButton_Click);
            // 
            // patenteTextBox
            // 
            this.patenteTextBox.Location = new System.Drawing.Point(104, 93);
            this.patenteTextBox.Name = "patenteTextBox";
            this.patenteTextBox.Size = new System.Drawing.Size(190, 20);
            this.patenteTextBox.TabIndex = 7;
            // 
            // marcaComboBox
            // 
            this.marcaComboBox.FormattingEnabled = true;
            this.marcaComboBox.Location = new System.Drawing.Point(104, 30);
            this.marcaComboBox.Name = "marcaComboBox";
            this.marcaComboBox.Size = new System.Drawing.Size(190, 21);
            this.marcaComboBox.TabIndex = 5;
            this.marcaComboBox.SelectedIndexChanged += new System.EventHandler(this.marcaComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Turno: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chofer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Patente:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Modelo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marca: ";
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(137, 15);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 20;
            this.limpiarButton.Text = "Limpiar";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // buscarAutoButton
            // 
            this.buscarAutoButton.Location = new System.Drawing.Point(45, 15);
            this.buscarAutoButton.Name = "buscarAutoButton";
            this.buscarAutoButton.Size = new System.Drawing.Size(75, 23);
            this.buscarAutoButton.TabIndex = 1;
            this.buscarAutoButton.Text = "Buscar";
            this.buscarAutoButton.UseVisualStyleBackColor = true;
            this.buscarAutoButton.Click += new System.EventHandler(this.buscarAutoButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // cerrarSesionLinkLabel
            // 
            this.cerrarSesionLinkLabel.AutoSize = true;
            this.cerrarSesionLinkLabel.Location = new System.Drawing.Point(288, 15);
            this.cerrarSesionLinkLabel.Name = "cerrarSesionLinkLabel";
            this.cerrarSesionLinkLabel.Size = new System.Drawing.Size(67, 13);
            this.cerrarSesionLinkLabel.TabIndex = 21;
            this.cerrarSesionLinkLabel.TabStop = true;
            this.cerrarSesionLinkLabel.Text = "cerrar sesión";
            this.cerrarSesionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cerrarSesionLinkLabel_LinkClicked);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 232);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Licencia Nro. :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 268);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 13);
            this.label13.TabIndex = 24;
            this.label13.Text = "Rodado:";
            // 
            // licenciaTextBox
            // 
            this.licenciaTextBox.Location = new System.Drawing.Point(112, 229);
            this.licenciaTextBox.Name = "licenciaTextBox";
            this.licenciaTextBox.Size = new System.Drawing.Size(182, 20);
            this.licenciaTextBox.TabIndex = 25;
            // 
            // rodadoTextBox
            // 
            this.rodadoTextBox.Location = new System.Drawing.Point(104, 265);
            this.rodadoTextBox.Name = "rodadoTextBox";
            this.rodadoTextBox.Size = new System.Drawing.Size(190, 20);
            this.rodadoTextBox.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("Dutch801 XBd BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(300, 265);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 20);
            this.label14.TabIndex = 27;
            this.label14.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Dutch801 XBd BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(300, 229);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 20);
            this.label15.TabIndex = 28;
            this.label15.Text = "*";
            // 
            // ABMAutomovilForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 425);
            this.Controls.Add(this.cerrarSesionLinkLabel);
            this.Controls.Add(this.buscarAutoButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "ABMAutomovilForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABM Automovil";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox turnoComboBox;
        private System.Windows.Forms.TextBox nombreChoferTB;
        private System.Windows.Forms.Button buscarChoferButton;
        private System.Windows.Forms.TextBox patenteTextBox;
        private System.Windows.Forms.ComboBox marcaComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button crearButton;
        private System.Windows.Forms.Button buscarAutoButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.LinkLabel cerrarSesionLinkLabel;
        private System.Windows.Forms.ComboBox modeloComboBox;
        private System.Windows.Forms.TextBox rodadoTextBox;
        private System.Windows.Forms.TextBox licenciaTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
    }
}