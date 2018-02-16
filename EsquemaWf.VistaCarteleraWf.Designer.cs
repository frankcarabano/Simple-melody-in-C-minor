namespace Ekia.EsquemaWinForms {
   partial class VistaCarteleraWf {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
        this.components = new System.ComponentModel.Container();
        this.vistaMensajes = new System.Windows.Forms.ListView();
        this.listaImagenes = new System.Windows.Forms.ImageList(this.components);
        this.SuspendLayout();
        // 
        // vistaMensajes
        // 
        this.vistaMensajes.Activation = System.Windows.Forms.ItemActivation.OneClick;
        this.vistaMensajes.BackColor = System.Drawing.Color.White;
        this.vistaMensajes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.vistaMensajes.Dock = System.Windows.Forms.DockStyle.Fill;
        this.vistaMensajes.HideSelection = false;
        this.vistaMensajes.LargeImageList = this.listaImagenes;
        this.vistaMensajes.Location = new System.Drawing.Point(0, 0);
        this.vistaMensajes.MultiSelect = false;
        this.vistaMensajes.Name = "vistaMensajes";
        this.vistaMensajes.ShowItemToolTips = true;
        this.vistaMensajes.Size = new System.Drawing.Size(816, 494);
        this.vistaMensajes.TabIndex = 0;
        this.vistaMensajes.UseCompatibleStateImageBehavior = false;
        // 
        // listaImagenes
        // 
        this.listaImagenes.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
        this.listaImagenes.ImageSize = new System.Drawing.Size(48, 48);
        this.listaImagenes.TransparentColor = System.Drawing.Color.Transparent;
        // 
        // VistaCarteleraWf
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(816, 494);
        this.Controls.Add(this.vistaMensajes);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Name = "VistaCarteleraWf";
        this.ResumeLayout(false);
      }

      #endregion

      protected System.Windows.Forms.ImageList listaImagenes;
      protected System.Windows.Forms.ListView vistaMensajes;

   }
}