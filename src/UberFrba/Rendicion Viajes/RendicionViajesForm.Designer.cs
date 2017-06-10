namespace UberFrba.Rendicion_Viajes
{
    partial class RendicionViajesForm
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
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.viajesDataGridView = new System.Windows.Forms.DataGridView();
            this.importeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.turnoComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.datosChoferTB = new System.Windows.Forms.TextBox();
            this.buscarChoferBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.realizarPagoBtn = new System.Windows.Forms.Button();
            this.cerrarSesionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viajesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.importeTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.turnoComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.datosChoferTB);
            this.groupBox1.Controls.Add(this.buscarChoferBtn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.fechaDateTimePicker);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 395);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pago al Chofer";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Dutch801 XBd BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(26, 372);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(132, 14);
            this.label15.TabIndex = 40;
            this.label15.Text = "[*] : campos obligatorios";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.viajesDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(29, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 163);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de viajes que realizó el chofer:";
            // 
            // viajesDataGridView
            // 
            this.viajesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viajesDataGridView.Location = new System.Drawing.Point(7, 20);
            this.viajesDataGridView.Name = "viajesDataGridView";
            this.viajesDataGridView.Size = new System.Drawing.Size(306, 137);
            this.viajesDataGridView.TabIndex = 0;
            // 
            // importeTextBox
            // 
            this.importeTextBox.Location = new System.Drawing.Point(188, 164);
            this.importeTextBox.Name = "importeTextBox";
            this.importeTextBox.ReadOnly = true;
            this.importeTextBox.Size = new System.Drawing.Size(131, 20);
            this.importeTextBox.TabIndex = 38;
            this.importeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Importe total de la rendición:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Dutch801 XBd BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(225, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 20);
            this.label12.TabIndex = 36;
            this.label12.Text = "*";
            // 
            // turnoComboBox
            // 
            this.turnoComboBox.FormattingEnabled = true;
            this.turnoComboBox.Location = new System.Drawing.Point(88, 129);
            this.turnoComboBox.Name = "turnoComboBox";
            this.turnoComboBox.Size = new System.Drawing.Size(121, 21);
            this.turnoComboBox.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Turno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Dutch801 XBd BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(331, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("Dutch801 XBd BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(331, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 20);
            this.label14.TabIndex = 32;
            this.label14.Text = "*";
            // 
            // datosChoferTB
            // 
            this.datosChoferTB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.datosChoferTB.Location = new System.Drawing.Point(29, 93);
            this.datosChoferTB.Name = "datosChoferTB";
            this.datosChoferTB.ReadOnly = true;
            this.datosChoferTB.Size = new System.Drawing.Size(290, 20);
            this.datosChoferTB.TabIndex = 31;
            this.datosChoferTB.Text = "Nombre y Apellido del chofer";
            // 
            // buscarChoferBtn
            // 
            this.buscarChoferBtn.Location = new System.Drawing.Point(140, 61);
            this.buscarChoferBtn.Name = "buscarChoferBtn";
            this.buscarChoferBtn.Size = new System.Drawing.Size(112, 23);
            this.buscarChoferBtn.TabIndex = 30;
            this.buscarChoferBtn.Text = "Buscar chofer";
            this.buscarChoferBtn.UseVisualStyleBackColor = true;
            this.buscarChoferBtn.Click += new System.EventHandler(this.buscarChoferBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Chofer:";
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.Location = new System.Drawing.Point(88, 27);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(230, 20);
            this.fechaDateTimePicker.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha:";
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(13, 429);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 1;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // realizarPagoBtn
            // 
            this.realizarPagoBtn.Location = new System.Drawing.Point(273, 428);
            this.realizarPagoBtn.Name = "realizarPagoBtn";
            this.realizarPagoBtn.Size = new System.Drawing.Size(113, 23);
            this.realizarPagoBtn.TabIndex = 2;
            this.realizarPagoBtn.Text = "Realizar Pago";
            this.realizarPagoBtn.UseVisualStyleBackColor = true;
            this.realizarPagoBtn.Click += new System.EventHandler(this.realizarPagoBtn_Click);
            // 
            // cerrarSesionLinkLabel
            // 
            this.cerrarSesionLinkLabel.AutoSize = true;
            this.cerrarSesionLinkLabel.Location = new System.Drawing.Point(319, 9);
            this.cerrarSesionLinkLabel.Name = "cerrarSesionLinkLabel";
            this.cerrarSesionLinkLabel.Size = new System.Drawing.Size(67, 13);
            this.cerrarSesionLinkLabel.TabIndex = 3;
            this.cerrarSesionLinkLabel.TabStop = true;
            this.cerrarSesionLinkLabel.Text = "cerrar sesión";
            this.cerrarSesionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cerrarSesionLinkLabel_LinkClicked);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // RendicionViajesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 463);
            this.Controls.Add(this.cerrarSesionLinkLabel);
            this.Controls.Add(this.realizarPagoBtn);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "RendicionViajesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rendicion de Viajes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.viajesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox datosChoferTB;
        private System.Windows.Forms.Button buscarChoferBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox turnoComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox importeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView viajesDataGridView;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button realizarPagoBtn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.LinkLabel cerrarSesionLinkLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}