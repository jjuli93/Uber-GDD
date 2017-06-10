namespace UberFrba.Abm_Rol
{
    partial class DetalleRolForm
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
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.volverButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.funcionalidadesLB = new System.Windows.Forms.ListBox();
            this.habilitadoCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.Location = new System.Drawing.Point(97, 53);
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.ReadOnly = true;
            this.descripcionTextBox.Size = new System.Drawing.Size(189, 20);
            this.descripcionTextBox.TabIndex = 20;
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Location = new System.Drawing.Point(81, 20);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.ReadOnly = true;
            this.nombreTextBox.Size = new System.Drawing.Size(205, 20);
            this.nombreTextBox.TabIndex = 19;
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(28, 257);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(75, 23);
            this.volverButton.TabIndex = 18;
            this.volverButton.Text = "<< Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Funcionalidades:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Nombre: ";
            // 
            // funcionalidadesLB
            // 
            this.funcionalidadesLB.Enabled = false;
            this.funcionalidadesLB.FormattingEnabled = true;
            this.funcionalidadesLB.Location = new System.Drawing.Point(28, 112);
            this.funcionalidadesLB.Name = "funcionalidadesLB";
            this.funcionalidadesLB.Size = new System.Drawing.Size(258, 95);
            this.funcionalidadesLB.TabIndex = 21;
            // 
            // habilitadoCheckBox
            // 
            this.habilitadoCheckBox.AutoSize = true;
            this.habilitadoCheckBox.Enabled = false;
            this.habilitadoCheckBox.Location = new System.Drawing.Point(28, 224);
            this.habilitadoCheckBox.Name = "habilitadoCheckBox";
            this.habilitadoCheckBox.Size = new System.Drawing.Size(73, 17);
            this.habilitadoCheckBox.TabIndex = 22;
            this.habilitadoCheckBox.Text = "Habilitado";
            this.habilitadoCheckBox.UseVisualStyleBackColor = true;
            // 
            // DetalleRolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 295);
            this.Controls.Add(this.habilitadoCheckBox);
            this.Controls.Add(this.funcionalidadesLB);
            this.Controls.Add(this.descripcionTextBox);
            this.Controls.Add(this.nombreTextBox);
            this.Controls.Add(this.volverButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DetalleRolForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle del Rol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox funcionalidadesLB;
        private System.Windows.Forms.CheckBox habilitadoCheckBox;
    }
}