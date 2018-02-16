using System.Windows.Forms;

namespace Ekia.EsquemaWinForms {
	partial class VistaWf {
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent() {
		  this.components = new System.ComponentModel.Container();
		  this.Nula = new System.Windows.Forms.Label();
		  this.Incumplimiento = new System.Windows.Forms.ErrorProvider(this.components);
		  this.tipText = new System.Windows.Forms.ToolTip(this.components);
		  ((System.ComponentModel.ISupportInitialize)(this.Incumplimiento)).BeginInit();
		  this.SuspendLayout();
		  // 
		  // Nula
		  // 
		  this.Nula.AutoSize = true;
		  this.Nula.Location = new System.Drawing.Point(-5, -5);
		  this.Nula.Name = "Nula";
		  this.Nula.Size = new System.Drawing.Size(0, 13);
		  this.Nula.TabIndex = 0;
		  // 
		  // Incumplimiento
		  // 
		  this.Incumplimiento.ContainerControl = this;
		  // 
		  // tipText
		  // 
		  this.tipText.IsBalloon = true;
		  // 
		  // VistaWf
		  // 
		  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		  this.BackColor = System.Drawing.Color.White;
		  this.ClientSize = new System.Drawing.Size(479, 407);
		  this.Controls.Add(this.Nula);
		  this.Name = "VistaWf";
		  this.Text = "VistaWf";
		  this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IntentoCierre);
		  ((System.ComponentModel.ISupportInitialize)(this.Incumplimiento)).EndInit();
		  this.ResumeLayout(false);
		  this.PerformLayout();
		}

		#endregion
		protected ErrorProvider Incumplimiento;
		protected Label Nula;
      protected ToolTip tipText;
	}
}