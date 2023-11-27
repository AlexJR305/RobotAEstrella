namespace RobotIA
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mapa = new Panel();
            menuStrip1 = new MenuStrip();
            comenzarToolStripMenuItem = new ToolStripMenuItem();
            reiniciarToolStripMenuItem = new ToolStripMenuItem();
            mapaSiguienteToolStripMenuItem = new ToolStripMenuItem();
            mapaNteriorToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // mapa
            // 
            mapa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mapa.Location = new Point(12, 30);
            mapa.Name = "mapa";
            mapa.Size = new Size(858, 861);
            mapa.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { comenzarToolStripMenuItem, reiniciarToolStripMenuItem, mapaSiguienteToolStripMenuItem, mapaNteriorToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(882, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // comenzarToolStripMenuItem
            // 
            comenzarToolStripMenuItem.Name = "comenzarToolStripMenuItem";
            comenzarToolStripMenuItem.Size = new Size(90, 24);
            comenzarToolStripMenuItem.Text = "Comenzar";
            comenzarToolStripMenuItem.Click += comenzarToolStripMenuItem_Click;
            // 
            // reiniciarToolStripMenuItem
            // 
            reiniciarToolStripMenuItem.Name = "reiniciarToolStripMenuItem";
            reiniciarToolStripMenuItem.Size = new Size(80, 24);
            reiniciarToolStripMenuItem.Text = "Reiniciar";
            reiniciarToolStripMenuItem.Click += reiniciarToolStripMenuItem_Click;
            // 
            // mapaSiguienteToolStripMenuItem
            // 
            mapaSiguienteToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            mapaSiguienteToolStripMenuItem.Name = "mapaSiguienteToolStripMenuItem";
            mapaSiguienteToolStripMenuItem.Size = new Size(127, 24);
            mapaSiguienteToolStripMenuItem.Text = "Mapa Siguiente";
            mapaSiguienteToolStripMenuItem.Click += mapaSiguienteToolStripMenuItem_Click;
            // 
            // mapaNteriorToolStripMenuItem
            // 
            mapaNteriorToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            mapaNteriorToolStripMenuItem.Name = "mapaNteriorToolStripMenuItem";
            mapaNteriorToolStripMenuItem.Size = new Size(119, 24);
            mapaNteriorToolStripMenuItem.Text = "Mapa Anterior";
            mapaNteriorToolStripMenuItem.Click += mapaNteriorToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 903);
            Controls.Add(mapa);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel mapa;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem comenzarToolStripMenuItem;
        private ToolStripMenuItem reiniciarToolStripMenuItem;
        private ToolStripMenuItem mapaNteriorToolStripMenuItem;
        private ToolStripMenuItem mapaSiguienteToolStripMenuItem;
    }
}