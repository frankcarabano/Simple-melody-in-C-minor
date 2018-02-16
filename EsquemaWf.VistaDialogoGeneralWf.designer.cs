namespace Ekia.EsquemaWinForms {
	partial class VistaDialogoGeneralWf {
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
		  this.botonAceptar = new System.Windows.Forms.Button();
		  this.botonCancelar = new System.Windows.Forms.Button();
		  ((System.ComponentModel.ISupportInitialize)(this.Incumplimiento)).BeginInit();
		  this.SuspendLayout();
		  // 
		  // botonAceptar
		  // 
		  this.botonAceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		  this.botonAceptar.BackColor = System.Drawing.Color.DarkGreen;
		  this.botonAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
		  this.botonAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSeaGreen;
		  this.botonAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OliveDrab;
		  this.botonAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		  this.botonAceptar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.botonAceptar.ForeColor = System.Drawing.Color.White;
		  this.botonAceptar.Location = new System.Drawing.Point(73, 212);
		  this.botonAceptar.Name = "botonAceptar";
		  this.botonAceptar.Size = new System.Drawing.Size(77, 25);
		  this.botonAceptar.TabIndex = 1;
		  this.botonAceptar.Text = "&Aceptar";
		  this.botonAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		  this.botonAceptar.UseVisualStyleBackColor = false;
		  // 
		  // botonCancelar
		  // 
		  this.botonCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		  this.botonCancelar.BackColor = System.Drawing.Color.DarkRed;
		  this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		  this.botonCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
		  this.botonCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
		  this.botonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		  this.botonCancelar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.botonCancelar.ForeColor = System.Drawing.Color.White;
		  this.botonCancelar.Location = new System.Drawing.Point(191, 212);
		  this.botonCancelar.Name = "botonCancelar";
		  this.botonCancelar.Size = new System.Drawing.Size(77, 25);
		  this.botonCancelar.TabIndex = 2;
		  this.botonCancelar.Text = "&Cancelar";
		  this.botonCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		  this.botonCancelar.UseVisualStyleBackColor = false;
		  // 
		  // VistaDialogoGeneralWf
		  // 
		  this.AcceptButton = this.botonAceptar;
		  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		  this.BackColor = System.Drawing.Color.White;
		  this.CancelButton = this.botonCancelar;
		  this.ClientSize = new System.Drawing.Size(340, 243);
		  this.Controls.Add(this.botonCancelar);
		  this.Controls.Add(this.botonAceptar);
		  this.Name = "VistaDialogoGeneralWf";
		  this.Controls.SetChildIndex(this.Nula, 0);
		  this.Controls.SetChildIndex(this.botonAceptar, 0);
		  this.Controls.SetChildIndex(this.botonCancelar, 0);
		  ((System.ComponentModel.ISupportInitialize)(this.Incumplimiento)).EndInit();
		  this.ResumeLayout(false);
		  this.PerformLayout();
		}

		#endregion

		protected System.Windows.Forms.Button botonAceptar;
		protected System.Windows.Forms.Button botonCancelar;
	}
}

