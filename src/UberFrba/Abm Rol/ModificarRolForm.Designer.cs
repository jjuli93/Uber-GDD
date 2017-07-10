namespace UberFrba.Abm_Rol
{
    partial class ModificarRolForm
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
            this.habilitarCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.guardarButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.chkListBoxFuncs = new System.Windows.Forms.CheckedListBox();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.habilitarCheckBox);
            this.groupBox1.Controls.Add(this.cancelarButton);
            this.groupBox1.Controls.Add(this.guardarButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkListBoxFuncs);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 292);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar rol";
            // 
            // habilitarCheckBox
            // 
            this.habilitarCheckBox.AutoSize = true;
            this.habilitarCheckBox.Location = new System.Drawing.Point(31, 201);
            this.habilitarCheckBox.Name = "habilitarCheckBox";
            this.habilitarCheckBox.Size = new System.Drawing.Size(64, 17);
            this.habilitarCheckBox.TabIndex = 18;
            this.habilitarCheckBox.Text = "Habilitar";
            this.habilitarCheckBox.UseVisualStyleBackColor = true;
            this.habilitarCheckBox.CheckedChanged += new System.EventHandler(this.habilitarCheckBox_CheckedChanged);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(31, 242);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 17;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // guardarButton
            // 
            this.guardarButton.Location = new System.Drawing.Point(200, 242);
            this.guardarButton.Name = "guardarButton";
            this.guardarButton.Size = new System.Drawing.Size(111, 23);
            this.guardarButton.TabIndex = 15;
            this.guardarButton.Text = "Guardar cambios";
            this.guardarButton.UseVisualStyleBackColor = true;
            this.guardarButton.Click += new System.EventHandler(this.guardarButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Funcionalidades: ";
            // 
            // chkListBoxFuncs
            // 
            this.chkListBoxFuncs.FormattingEnabled = true;
            this.chkListBoxFuncs.Location = new System.Drawing.Point(31, 91);
            this.chkListBoxFuncs.Name = "chkListBoxFuncs";
            this.chkListBoxFuncs.Size = new System.Drawing.Size(280, 94);
            this.chkListBoxFuncs.TabIndex = 13;
            //this.chkListBoxFuncs.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListBoxFuncs_ItemCheck);
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Location = new System.Drawing.Point(98, 28);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(213, 20);
            this.nombreTextBox.TabIndex = 10;
            this.nombreTextBox.TextChanged += new System.EventHandler(this.nombreTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nombre: ";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ModificarRolForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 317);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificarRolForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar Rol";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button guardarButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox chkListBoxFuncs;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox habilitarCheckBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}