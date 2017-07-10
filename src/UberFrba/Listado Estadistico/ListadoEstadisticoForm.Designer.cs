namespace UberFrba.Listado_Estadistico
{
    partial class ListadoEstadisticoForm
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
            this.listadoDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tiposListadoListBox = new System.Windows.Forms.ListBox();
            this.trimestreComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.yearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cerrarSesionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.volverButton = new System.Windows.Forms.Button();
            this.limpiarButton = new System.Windows.Forms.Button();
            this.consultarButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.listadoDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // listadoDataGridView
            // 
            this.listadoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listadoDataGridView.Location = new System.Drawing.Point(340, 41);
            this.listadoDataGridView.Name = "listadoDataGridView";
            this.listadoDataGridView.ReadOnly = true;
            this.listadoDataGridView.Size = new System.Drawing.Size(395, 226);
            this.listadoDataGridView.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tiposListadoListBox);
            this.groupBox1.Controls.Add(this.trimestreComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.yearNumericUpDown);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 223);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TOP 5";
            // 
            // tiposListadoListBox
            // 
            this.tiposListadoListBox.FormattingEnabled = true;
            this.tiposListadoListBox.Location = new System.Drawing.Point(21, 91);
            this.tiposListadoListBox.Name = "tiposListadoListBox";
            this.tiposListadoListBox.Size = new System.Drawing.Size(267, 121);
            this.tiposListadoListBox.TabIndex = 4;
            // 
            // trimestreComboBox
            // 
            this.trimestreComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trimestreComboBox.FormattingEnabled = true;
            this.trimestreComboBox.Location = new System.Drawing.Point(138, 53);
            this.trimestreComboBox.Name = "trimestreComboBox";
            this.trimestreComboBox.Size = new System.Drawing.Size(150, 21);
            this.trimestreComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Trimestre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Año:";
            // 
            // yearNumericUpDown
            // 
            this.yearNumericUpDown.Location = new System.Drawing.Point(21, 54);
            this.yearNumericUpDown.Name = "yearNumericUpDown";
            this.yearNumericUpDown.Size = new System.Drawing.Size(85, 20);
            this.yearNumericUpDown.TabIndex = 0;
            // 
            // cerrarSesionLinkLabel
            // 
            this.cerrarSesionLinkLabel.AutoSize = true;
            this.cerrarSesionLinkLabel.Location = new System.Drawing.Point(668, 12);
            this.cerrarSesionLinkLabel.Name = "cerrarSesionLinkLabel";
            this.cerrarSesionLinkLabel.Size = new System.Drawing.Size(67, 13);
            this.cerrarSesionLinkLabel.TabIndex = 22;
            this.cerrarSesionLinkLabel.TabStop = true;
            this.cerrarSesionLinkLabel.Text = "cerrar sesión";
            this.cerrarSesionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cerrarSesionLinkLabel_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(337, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Listado:";
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(33, 243);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(75, 23);
            this.volverButton.TabIndex = 24;
            this.volverButton.Text = "<< Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // limpiarButton
            // 
            this.limpiarButton.Location = new System.Drawing.Point(128, 243);
            this.limpiarButton.Name = "limpiarButton";
            this.limpiarButton.Size = new System.Drawing.Size(75, 23);
            this.limpiarButton.TabIndex = 25;
            this.limpiarButton.Text = "Limpiar todo";
            this.limpiarButton.UseVisualStyleBackColor = true;
            this.limpiarButton.Click += new System.EventHandler(this.limpiarButton_Click);
            // 
            // consultarButton
            // 
            this.consultarButton.Location = new System.Drawing.Point(225, 243);
            this.consultarButton.Name = "consultarButton";
            this.consultarButton.Size = new System.Drawing.Size(75, 23);
            this.consultarButton.TabIndex = 26;
            this.consultarButton.Text = "Consultar >>";
            this.consultarButton.UseVisualStyleBackColor = true;
            this.consultarButton.Click += new System.EventHandler(this.consultarButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // ListadoEstadisticoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 282);
            this.Controls.Add(this.consultarButton);
            this.Controls.Add(this.limpiarButton);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cerrarSesionLinkLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listadoDataGridView);
            this.Name = "ListadoEstadisticoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Estadístico";
            ((System.ComponentModel.ISupportInitialize)(this.listadoDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listadoDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown yearNumericUpDown;
        private System.Windows.Forms.ComboBox trimestreComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel cerrarSesionLinkLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Button limpiarButton;
        private System.Windows.Forms.ListBox tiposListadoListBox;
        private System.Windows.Forms.Button consultarButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}