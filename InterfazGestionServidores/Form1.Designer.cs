namespace InterfazGestionServidores
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox txtMetodos;
        private System.Windows.Forms.Button btnEjecutar;
        private System.Windows.Forms.TextBox txtInfo;

        private void InitializeComponent()
        {
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.txtMetodos = new System.Windows.Forms.TextBox();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
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
            this.txtLog.Size = new System.Drawing.Size(350, 200);
            this.txtLog.TabIndex = 0;
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(584, 304);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(120, 23);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "Modificar Comando";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditarServidor_Click);
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
            this.txtMetodos.Size = new System.Drawing.Size(300, 200);
            this.txtMetodos.TabIndex = 2;
            this.txtMetodos.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(584, 344);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(120, 23);
            this.btnEjecutar.TabIndex = 3;
            this.btnEjecutar.Text = "Ejecutar Comando";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            // 
            // txtInfo
            // 
            this.txtInfo.AcceptsReturn = true;
            this.txtInfo.AcceptsTab = true;
            this.txtInfo.AllowDrop = true;
            this.txtInfo.Location = new System.Drawing.Point(12, 250);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInfo.Size = new System.Drawing.Size(476, 188);
            this.txtInfo.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.txtMetodos);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.txtLog);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
