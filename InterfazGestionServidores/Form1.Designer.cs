namespace InterfazGestionServidores
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnCargarComandos;
        private System.Windows.Forms.TextBox txtMetodos;
        private System.Windows.Forms.Button btnEjecutar;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnCargarComandos = new System.Windows.Forms.Button();
            this.txtMetodos = new System.Windows.Forms.TextBox();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.AcceptsReturn = true;
            this.txtLog.AcceptsTab = true;
            this.txtLog.AllowDrop = true;
            this.txtLog.Location = new System.Drawing.Point(12, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(350, 300);
            this.txtLog.TabIndex = 0;
           // this.txtLog.SelectionChanged += new System.EventHandler(this.txtLog_SelectionChanged);
            // 
            // btnCargarComandos
            // 
            this.btnCargarComandos.Location = new System.Drawing.Point(388, 17);
            this.btnCargarComandos.Name = "btnCargarComandos";
            this.btnCargarComandos.Size = new System.Drawing.Size(120, 23);
            this.btnCargarComandos.TabIndex = 1;
            this.btnCargarComandos.Text = "Cargar Comandos";
            this.btnCargarComandos.UseVisualStyleBackColor = true;
            this.btnCargarComandos.Click += new System.EventHandler(this.btnCargarComandos_Click);
            // 
            // txtMetodos
            // 
            this.txtMetodos.AcceptsReturn = true;
            this.txtMetodos.AcceptsTab = true;
            this.txtMetodos.AllowDrop = true;
            this.txtMetodos.Location = new System.Drawing.Point(488, 12);
            this.txtMetodos.Multiline = true;
            this.txtMetodos.Name = "txtMetodos";
            this.txtMetodos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMetodos.Size = new System.Drawing.Size(300, 300);
            this.txtMetodos.TabIndex = 2;
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(600, 350);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(120, 23);
            this.btnEjecutar.TabIndex = 3;
            this.btnEjecutar.Text = "Ejecutar Método";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.txtMetodos);
            this.Controls.Add(this.btnCargarComandos);
            this.Controls.Add(this.txtLog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
