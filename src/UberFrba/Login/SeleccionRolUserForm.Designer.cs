namespace UberFrba.Login
{
    partial class SeleccionRolUserForm
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
            this.ingresarConRolButton = new System.Windows.Forms.Button();
            this.cerrarSesionLinkLabel = new System.Windows.Forms.LinkLabel();
            this.RolesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ingresarConRolButton);
            this.groupBox1.Controls.Add(this.cerrarSesionLinkLabel);
            this.groupBox1.Controls.Add(this.RolesComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bienvenido a Uber FRBA";
            // 
            // ingresarConRolButton
            // 
            this.ingresarConRolButton.Enabled = false;
            this.ingresarConRolButton.Location = new System.Drawing.Point(155, 139);
            this.ingresarConRolButton.Name = "ingresarConRolButton";
            this.ingresarConRolButton.Size = new System.Drawing.Size(75, 23);
            this.ingresarConRolButton.TabIndex = 3;
            this.ingresarConRolButton.Text = "Continuar >>";
            this.ingresarConRolButton.UseVisualStyleBackColor = true;
            this.ingresarConRolButton.Click += new System.EventHandler(this.ingresarConRolButton_Click);
            // 
            // cerrarSesionLinkLabel
            // 
            this.cerrarSesionLinkLabel.AutoSize = true;
            this.cerrarSesionLinkLabel.Location = new System.Drawing.Point(181, 20);
            this.cerrarSesionLinkLabel.Name = "cerrarSesionLinkLabel";
            this.cerrarSesionLinkLabel.Size = new System.Drawing.Size(67, 13);
            this.cerrarSesionLinkLabel.TabIndex = 2;
            this.cerrarSesionLinkLabel.TabStop = true;
            this.cerrarSesionLinkLabel.Text = "cerrar sesión";
            this.cerrarSesionLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cerrarSesionLinkLabel_LinkClicked);
            // 
            // RolesComboBox
            // 
            this.RolesComboBox.FormattingEnabled = true;
            this.RolesComboBox.Location = new System.Drawing.Point(33, 97);
            this.RolesComboBox.Name = "RolesComboBox";
            this.RolesComboBox.Size = new System.Drawing.Size(198, 21);
            this.RolesComboBox.TabIndex = 1;
            this.RolesComboBox.SelectedIndexChanged += new System.EventHandler(this.RolesComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione un rol:";
            // 
            // SeleccionRolUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 198);
            this.Controls.Add(this.groupBox1);
            this.Name = "SeleccionRolUserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de Rol";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ingresarConRolButton;
        private System.Windows.Forms.LinkLabel cerrarSesionLinkLabel;
        private System.Windows.Forms.ComboBox RolesComboBox;
    }
}