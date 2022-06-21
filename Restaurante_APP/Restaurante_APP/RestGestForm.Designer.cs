namespace Restaurante_APP
{
    partial class RestGestForm
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestGestForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.acessoRapidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gesstãoDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestaoGlobalDeRestaurantesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestaoDeClientesButton = new System.Windows.Forms.Button();
            this.gestaoGlobalDeRestaurantesButton = new System.Windows.Forms.Button();
            this.pedidosButton = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acessoRapidoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 64);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(443, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // acessoRapidoToolStripMenuItem
            // 
            this.acessoRapidoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gesstãoDeClientesToolStripMenuItem,
            this.gestaoGlobalDeRestaurantesToolStripMenuItem,
            this.pedidosToolStripMenuItem});
            this.acessoRapidoToolStripMenuItem.Name = "acessoRapidoToolStripMenuItem";
            this.acessoRapidoToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.acessoRapidoToolStripMenuItem.Text = "Acesso Rápido";
            // 
            // gesstãoDeClientesToolStripMenuItem
            // 
            this.gesstãoDeClientesToolStripMenuItem.Name = "gesstãoDeClientesToolStripMenuItem";
            this.gesstãoDeClientesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.gesstãoDeClientesToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.gesstãoDeClientesToolStripMenuItem.Text = "Gesstão de Clientes";
            this.gesstãoDeClientesToolStripMenuItem.Click += new System.EventHandler(this.gesstãoDeClientesToolStripMenuItem_Click);
            // 
            // gestaoGlobalDeRestaurantesToolStripMenuItem
            // 
            this.gestaoGlobalDeRestaurantesToolStripMenuItem.Name = "gestaoGlobalDeRestaurantesToolStripMenuItem";
            this.gestaoGlobalDeRestaurantesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.gestaoGlobalDeRestaurantesToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.gestaoGlobalDeRestaurantesToolStripMenuItem.Text = "Gestão Global de Restaurantes";
            this.gestaoGlobalDeRestaurantesToolStripMenuItem.Click += new System.EventHandler(this.gestaoGlobalDeRestaurantesToolStripMenuItem_Click);
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.pedidosToolStripMenuItem.Text = "Pedidos";
            this.pedidosToolStripMenuItem.Click += new System.EventHandler(this.pedidosToolStripMenuItem_Click);
            // 
            // gestaoDeClientesButton
            // 
            this.gestaoDeClientesButton.Location = new System.Drawing.Point(6, 93);
            this.gestaoDeClientesButton.Name = "gestaoDeClientesButton";
            this.gestaoDeClientesButton.Size = new System.Drawing.Size(213, 45);
            this.gestaoDeClientesButton.TabIndex = 1;
            this.gestaoDeClientesButton.Text = "Gestão de Clientes";
            this.gestaoDeClientesButton.UseVisualStyleBackColor = true;
            this.gestaoDeClientesButton.Click += new System.EventHandler(this.gestaoDeClientesButton_Click);
            // 
            // gestaoGlobalDeRestaurantesButton
            // 
            this.gestaoGlobalDeRestaurantesButton.Location = new System.Drawing.Point(225, 93);
            this.gestaoGlobalDeRestaurantesButton.Name = "gestaoGlobalDeRestaurantesButton";
            this.gestaoGlobalDeRestaurantesButton.Size = new System.Drawing.Size(212, 45);
            this.gestaoGlobalDeRestaurantesButton.TabIndex = 2;
            this.gestaoGlobalDeRestaurantesButton.Text = "Gestão Global de Restaurantes";
            this.gestaoGlobalDeRestaurantesButton.UseVisualStyleBackColor = true;
            this.gestaoGlobalDeRestaurantesButton.Click += new System.EventHandler(this.gestaoGlobalDeRestaurantesButton_Click);
            // 
            // pedidosButton
            // 
            this.pedidosButton.Location = new System.Drawing.Point(6, 144);
            this.pedidosButton.Name = "pedidosButton";
            this.pedidosButton.Size = new System.Drawing.Size(431, 45);
            this.pedidosButton.TabIndex = 3;
            this.pedidosButton.Text = "Pedidos";
            this.pedidosButton.UseVisualStyleBackColor = true;
            this.pedidosButton.Click += new System.EventHandler(this.pedidosButton_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // RestGestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 195);
            this.Controls.Add(this.pedidosButton);
            this.Controls.Add(this.gestaoGlobalDeRestaurantesButton);
            this.Controls.Add(this.gestaoDeClientesButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "RestGestForm";
            this.Text = "RestGest";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem acessoRapidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gesstãoDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestaoGlobalDeRestaurantesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.Button gestaoDeClientesButton;
        private System.Windows.Forms.Button gestaoGlobalDeRestaurantesButton;
        private System.Windows.Forms.Button pedidosButton;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
    }
}

