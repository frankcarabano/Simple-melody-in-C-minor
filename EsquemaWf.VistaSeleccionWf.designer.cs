namespace Ekia.EsquemaWinForms {
	partial class VistaSeleccionWf {
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
		  this.cuadroLista = new System.Windows.Forms.Panel();
		  this.WidgetLista = new System.Windows.Forms.ListView();
		  this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
		  this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
		  this.cuadroLista.SuspendLayout();
		  this.SuspendLayout();
		  // 
		  // botonAceptar
		  // 
		  this.botonAceptar.BackColor = System.Drawing.Color.DarkGreen;
		  this.botonAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
		  this.botonAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSeaGreen;
		  this.botonAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OliveDrab;
		  this.botonAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		  this.botonAceptar.ForeColor = System.Drawing.Color.White;
		  this.botonAceptar.Location = new System.Drawing.Point(224, 225);
		  this.botonAceptar.Name = "botonAceptar";
		  this.botonAceptar.Size = new System.Drawing.Size(75, 28);
		  this.botonAceptar.TabIndex = 1;
		  this.botonAceptar.Text = "&Aceptar";
		  this.botonAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		  this.botonAceptar.UseVisualStyleBackColor = false;
		  // 
		  // botonCancelar
		  // 
		  this.botonCancelar.BackColor = System.Drawing.Color.DarkRed;
		  this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.OK;
		  this.botonCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
		  this.botonCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
		  this.botonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		  this.botonCancelar.ForeColor = System.Drawing.Color.White;
		  this.botonCancelar.Location = new System.Drawing.Point(343, 225);
		  this.botonCancelar.Name = "botonCancelar";
		  this.botonCancelar.Size = new System.Drawing.Size(75, 28);
		  this.botonCancelar.TabIndex = 2;
		  this.botonCancelar.Text = "&Cancelar";
		  this.botonCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		  this.botonCancelar.UseVisualStyleBackColor = false;
		  // 
		  // cuadroLista
		  // 
		  this.cuadroLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		  this.cuadroLista.Controls.Add(this.WidgetLista);
		  this.cuadroLista.Location = new System.Drawing.Point(12, 12);
		  this.cuadroLista.Name = "cuadroLista";
		  this.cuadroLista.Size = new System.Drawing.Size(618, 207);
		  this.cuadroLista.TabIndex = 3;
		  // 
		  // WidgetLista
		  // 
		  this.WidgetLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
		  		  		  | System.Windows.Forms.AnchorStyles.Left) 
		  		  		  | System.Windows.Forms.AnchorStyles.Right)));
		  this.WidgetLista.BackColor = System.Drawing.Color.PaleTurquoise;
		  this.WidgetLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		  this.WidgetLista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
		  		  		  this.columnHeader1,
		  		  		  this.columnHeader2});
		  this.WidgetLista.FullRowSelect = true;
		  this.WidgetLista.GridLines = true;
		  this.WidgetLista.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
		  this.WidgetLista.HideSelection = false;
		  this.WidgetLista.Location = new System.Drawing.Point(12, 19);
		  this.WidgetLista.MultiSelect = false;
		  this.WidgetLista.Name = "WidgetLista";
		  this.WidgetLista.Size = new System.Drawing.Size(592, 166);
		  this.WidgetLista.TabIndex = 1;
		  this.WidgetLista.UseCompatibleStateImageBehavior = false;
		  this.WidgetLista.View = System.Windows.Forms.View.Details;
		  // 
		  // VistaSeleccionWf
		  // 
		  this.AcceptButton = this.botonAceptar;
		  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		  this.BackColor = System.Drawing.Color.White;
		  this.CancelButton = this.botonCancelar;
		  this.ClientSize = new System.Drawing.Size(642, 262);
		  this.Controls.Add(this.cuadroLista);
		  this.Controls.Add(this.botonCancelar);
		  this.Controls.Add(this.botonAceptar);
		  this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		  this.Name = "VistaSeleccionWf";
		  this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		  this.Text = "Selección Lista";
		  this.Shown += new System.EventHandler(this.VistaMostrada);
		  this.cuadroLista.ResumeLayout(false);
		  this.ResumeLayout(false);
		}

		#endregion

		protected System.Windows.Forms.Panel cuadroLista;
		protected System.Windows.Forms.ListView WidgetLista;
		protected System.Windows.Forms.Button botonAceptar;
		protected System.Windows.Forms.ColumnHeader columnHeader1;
		protected System.Windows.Forms.ColumnHeader columnHeader2;
		protected System.Windows.Forms.Button botonCancelar;
	}
}