namespace PathFinding
{
    partial class PathfindingForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grid = new System.Windows.Forms.PictureBox();
            this.btnResolve = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.BackColor = System.Drawing.SystemColors.Control;
            this.grid.Location = new System.Drawing.Point(45, 60);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(300, 300);
            this.grid.TabIndex = 0;
            this.grid.TabStop = false;
            this.grid.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintGrid);
            this.grid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.grid.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            this.grid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // btnResolve
            // 
            this.btnResolve.BackColor = System.Drawing.Color.YellowGreen;
            this.btnResolve.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnResolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResolve.Location = new System.Drawing.Point(45, 22);
            this.btnResolve.Name = "btnResolve";
            this.btnResolve.Size = new System.Drawing.Size(75, 23);
            this.btnResolve.TabIndex = 1;
            this.btnResolve.Text = "Solve";
            this.btnResolve.UseVisualStyleBackColor = false;
            this.btnResolve.Click += new System.EventHandler(this.ResolveClick);
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.Location = new System.Drawing.Point(126, 22);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 2;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.RestartClick);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 378);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(89, 13);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Notification Label";
            // 
            // PathfindingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnResolve);
            this.Controls.Add(this.grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PathfindingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pathfinding A*";
            this.Load += new System.EventHandler(this.PathfindingLoad);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox grid;
        private System.Windows.Forms.Button btnResolve;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblMessage;
    }
}

