namespace Ekia.EsquemaWinForms {
	partial class VistaFicheroMaestroWf {
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
		  System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaFicheroMaestroWf));
		  this.barraStatus = new System.Windows.Forms.StatusStrip();
		  this.ayudaEdicion = new System.Windows.Forms.ToolStripStatusLabel();
		  this.statusControlador = new System.Windows.Forms.ToolStripStatusLabel();
		  this.cuentaRegistros = new System.Windows.Forms.ToolStripStatusLabel();
		  this.marcoBarra = new System.Windows.Forms.Panel();
		  this.barraHerramientas = new System.Windows.Forms.ToolStrip();
		  this.botonInicio = new System.Windows.Forms.ToolStripButton();
		  this.botonPrevio = new System.Windows.Forms.ToolStripButton();
		  this.botonSiguiente = new System.Windows.Forms.ToolStripButton();
		  this.botonFinal = new System.Windows.Forms.ToolStripButton();
		  this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		  this.botonCrear = new System.Windows.Forms.ToolStripButton();
		  this.botonDuplicar = new System.Windows.Forms.ToolStripButton();
		  this.botonBuscar = new System.Windows.Forms.ToolStripButton();
		  this.botonModificar = new System.Windows.Forms.ToolStripButton();
		  this.botonEliminar = new System.Windows.Forms.ToolStripButton();
		  this.botonArchivar = new System.Windows.Forms.ToolStripButton();
		  this.barraRight = new System.Windows.Forms.Panel();
		  this.barraBottom = new System.Windows.Forms.Panel();
		  this.barraLeft = new System.Windows.Forms.Panel();
		  this.barraTop = new System.Windows.Forms.Panel();
		  ((System.ComponentModel.ISupportInitialize)(this.Incumplimiento)).BeginInit();
		  this.barraStatus.SuspendLayout();
		  this.marcoBarra.SuspendLayout();
		  this.barraHerramientas.SuspendLayout();
		  this.SuspendLayout();
		  // 
		  // barraStatus
		  // 
		  this.barraStatus.AllowMerge = false;
		  this.barraStatus.AutoSize = false;
		  this.barraStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
		  		  		  this.ayudaEdicion,
		  		  		  this.statusControlador,
		  		  		  this.cuentaRegistros});
		  this.barraStatus.Location = new System.Drawing.Point(0, 402);
		  this.barraStatus.Name = "barraStatus";
		  this.barraStatus.Size = new System.Drawing.Size(632, 22);
		  this.barraStatus.SizingGrip = false;
		  this.barraStatus.TabIndex = 4;
		  // 
		  // ayudaEdicion
		  // 
		  this.ayudaEdicion.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
		  this.ayudaEdicion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		  this.ayudaEdicion.Name = "ayudaEdicion";
		  this.ayudaEdicion.Size = new System.Drawing.Size(41, 17);
		  this.ayudaEdicion.Text = "Ayuda";
		  // 
		  // statusControlador
		  // 
		  this.statusControlador.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
		  this.statusControlador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		  this.statusControlador.Name = "statusControlador";
		  this.statusControlador.Size = new System.Drawing.Size(515, 17);
		  this.statusControlador.Spring = true;
		  this.statusControlador.Text = "Status";
		  // 
		  // cuentaRegistros
		  // 
		  this.cuentaRegistros.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
		  this.cuentaRegistros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		  this.cuentaRegistros.Name = "cuentaRegistros";
		  this.cuentaRegistros.Size = new System.Drawing.Size(61, 17);
		  this.cuentaRegistros.Text = "Lista vacía";
		  // 
		  // marcoBarra
		  // 
		  this.marcoBarra.BackColor = System.Drawing.SystemColors.ControlDarkDark;
		  this.marcoBarra.Controls.Add(this.barraHerramientas);
		  this.marcoBarra.Controls.Add(this.barraRight);
		  this.marcoBarra.Controls.Add(this.barraBottom);
		  this.marcoBarra.Controls.Add(this.barraLeft);
		  this.marcoBarra.Controls.Add(this.barraTop);
		  this.marcoBarra.Dock = System.Windows.Forms.DockStyle.Top;
		  this.marcoBarra.Location = new System.Drawing.Point(0, 0);
		  this.marcoBarra.Name = "marcoBarra";
		  this.marcoBarra.Size = new System.Drawing.Size(632, 55);
		  this.marcoBarra.TabIndex = 6;
		  // 
		  // barraHerramientas
		  // 
		  this.barraHerramientas.BackColor = System.Drawing.Color.Black;
		  this.barraHerramientas.Dock = System.Windows.Forms.DockStyle.Fill;
		  this.barraHerramientas.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.barraHerramientas.ImageScalingSize = new System.Drawing.Size(32, 32);
		  this.barraHerramientas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
		  		  		  this.botonInicio,
		  		  		  this.botonPrevio,
		  		  		  this.botonSiguiente,
		  		  		  this.botonFinal,
		  		  		  this.toolStripSeparator1,
		  		  		  this.botonCrear,
		  		  		  this.botonDuplicar,
		  		  		  this.botonBuscar,
		  		  		  this.botonModificar,
		  		  		  this.botonArchivar,
		  		  		  this.botonEliminar});
		  this.barraHerramientas.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
		  this.barraHerramientas.Location = new System.Drawing.Point(3, 3);
		  this.barraHerramientas.Name = "barraHerramientas";
		  this.barraHerramientas.Size = new System.Drawing.Size(626, 49);
		  this.barraHerramientas.Stretch = true;
		  this.barraHerramientas.TabIndex = 0;
		  // 
		  // botonInicio
		  // 
		  this.botonInicio.AutoToolTip = false;
		  this.botonInicio.BackColor = System.Drawing.Color.Transparent;
		  this.botonInicio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.botonInicio.ForeColor = System.Drawing.Color.DeepSkyBlue;
		  this.botonInicio.Image = ((System.Drawing.Image)(resources.GetObject("botonInicio.Image")));
		  this.botonInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
		  this.botonInicio.Name = "botonInicio";
		  this.botonInicio.Size = new System.Drawing.Size(39, 46);
		  this.botonInicio.Text = "Inicio";
		  this.botonInicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		  // 
		  // botonPrevio
		  // 
		  this.botonPrevio.AutoToolTip = false;
		  this.botonPrevio.BackColor = System.Drawing.Color.Transparent;
		  this.botonPrevio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.botonPrevio.ForeColor = System.Drawing.Color.DeepSkyBlue;
		  this.botonPrevio.Image = ((System.Drawing.Image)(resources.GetObject("botonPrevio.Image")));
		  this.botonPrevio.ImageTransparentColor = System.Drawing.Color.Magenta;
		  this.botonPrevio.Name = "botonPrevio";
		  this.botonPrevio.Size = new System.Drawing.Size(42, 46);
		  this.botonPrevio.Text = "Previo";
		  this.botonPrevio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		  // 
		  // botonSiguiente
		  // 
		  this.botonSiguiente.AutoToolTip = false;
		  this.botonSiguiente.BackColor = System.Drawing.Color.Transparent;
		  this.botonSiguiente.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.botonSiguiente.ForeColor = System.Drawing.Color.DeepSkyBlue;
		  this.botonSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("botonSiguiente.Image")));
		  this.botonSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
		  this.botonSiguiente.Name = "botonSiguiente";
		  this.botonSiguiente.Size = new System.Drawing.Size(60, 46);
		  this.botonSiguiente.Text = "Siguiente";
		  this.botonSiguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		  // 
		  // botonFinal
		  // 
		  this.botonFinal.AutoToolTip = false;
		  this.botonFinal.BackColor = System.Drawing.Color.Transparent;
		  this.botonFinal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.botonFinal.ForeColor = System.Drawing.Color.DeepSkyBlue;
		  this.botonFinal.Image = ((System.Drawing.Image)(resources.GetObject("botonFinal.Image")));
		  this.botonFinal.ImageTransparentColor = System.Drawing.Color.Magenta;
		  this.botonFinal.Name = "botonFinal";
		  this.botonFinal.Size = new System.Drawing.Size(36, 46);
		  this.botonFinal.Text = "Final";
		  this.botonFinal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		  // 
		  // toolStripSeparator1
		  // 
		  this.toolStripSeparator1.ForeColor = System.Drawing.Color.DeepSkyBlue;
		  this.toolStripSeparator1.Name = "toolStripSeparator1";
		  this.toolStripSeparator1.Size = new System.Drawing.Size(6, 49);
		  // 
		  // botonCrear
		  // 
		  this.botonCrear.AutoToolTip = false;
		  this.botonCrear.BackColor = System.Drawing.Color.Transparent;
		  this.botonCrear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.botonCrear.ForeColor = System.Drawing.Color.DeepSkyBlue;
		  this.botonCrear.Image = ((System.Drawing.Image)(resources.GetObject("botonCrear.Image")));
		  this.botonCrear.ImageTransparentColor = System.Drawing.Color.Magenta;
		  this.botonCrear.Name = "botonCrear";
		  this.botonCrear.Size = new System.Drawing.Size(38, 46);
		  this.botonCrear.Text = "Crear";
		  this.botonCrear.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
		  this.botonCrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		  // 
		  // botonDuplicar
		  // 
		  this.botonDuplicar.AutoToolTip = false;
		  this.botonDuplicar.BackColor = System.Drawing.Color.Transparent;
		  this.botonDuplicar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.botonDuplicar.ForeColor = System.Drawing.Color.DeepSkyBlue;
		  this.botonDuplicar.Image = ((System.Drawing.Image)(resources.GetObject("botonDuplicar.Image")));
		  this.botonDuplicar.ImageTransparentColor = System.Drawing.Color.Magenta;
		  this.botonDuplicar.Name = "botonDuplicar";
		  this.botonDuplicar.Size = new System.Drawing.Size(54, 46);
		  this.botonDuplicar.Text = "Duplicar";
		  this.botonDuplicar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
		  this.botonDuplicar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		  // 
		  // botonBuscar
		  // 
		  this.botonBuscar.AutoToolTip = false;
		  this.botonBuscar.BackColor = System.Drawing.Color.Transparent;
		  this.botonBuscar.CheckOnClick = true;
		  this.botonBuscar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.botonBuscar.ForeColor = System.Drawing.Color.DeepSkyBlue;
		  this.botonBuscar.Image = ((System.Drawing.Image)(resources.GetObject("botonBuscar.Image")));
		  this.botonBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
		  this.botonBuscar.Name = "botonBuscar";
		  this.botonBuscar.Size = new System.Drawing.Size(45, 46);
		  this.botonBuscar.Text = "Buscar";
		  this.botonBuscar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
		  this.botonBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		  // 
		  // botonModificar
		  // 
		  this.botonModificar.AutoToolTip = false;
		  this.botonModificar.BackColor = System.Drawing.Color.Transparent;
		  this.botonModificar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.botonModificar.ForeColor = System.Drawing.Color.DeepSkyBlue;
		  this.botonModificar.Image = ((System.Drawing.Image)(resources.GetObject("botonModificar.Image")));
		  this.botonModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
		  this.botonModificar.Name = "botonModificar";
		  this.botonModificar.Size = new System.Drawing.Size(60, 46);
		  this.botonModificar.Text = "Modificar";
		  this.botonModificar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
		  this.botonModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		  // 
		  // botonEliminar
		  // 
		  this.botonEliminar.AutoToolTip = false;
		  this.botonEliminar.BackColor = System.Drawing.Color.Transparent;
		  this.botonEliminar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.botonEliminar.ForeColor = System.Drawing.Color.DeepSkyBlue;
		  this.botonEliminar.Image = ((System.Drawing.Image)(resources.GetObject("botonEliminar.Image")));
		  this.botonEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
		  this.botonEliminar.Name = "botonEliminar";
		  this.botonEliminar.Size = new System.Drawing.Size(52, 46);
		  this.botonEliminar.Text = "Eliminar";
		  this.botonEliminar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
		  this.botonEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		  // 
		  // botonArchivar
		  // 
		  this.botonArchivar.AutoToolTip = false;
		  this.botonArchivar.BackColor = System.Drawing.Color.Transparent;
		  this.botonArchivar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		  this.botonArchivar.ForeColor = System.Drawing.Color.DeepSkyBlue;
		  this.botonArchivar.Image = ((System.Drawing.Image)(resources.GetObject("botonArchivar.Image")));
		  this.botonArchivar.ImageTransparentColor = System.Drawing.Color.Magenta;
		  this.botonArchivar.Name = "botonArchivar";
		  this.botonArchivar.Size = new System.Drawing.Size(52, 46);
		  this.botonArchivar.Text = "Archivar";
		  this.botonArchivar.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
		  this.botonArchivar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
		  // 
		  // barraRight
		  // 
		  this.barraRight.Dock = System.Windows.Forms.DockStyle.Right;
		  this.barraRight.Location = new System.Drawing.Point(629, 3);
		  this.barraRight.Name = "barraRight";
		  this.barraRight.Size = new System.Drawing.Size(3, 49);
		  this.barraRight.TabIndex = 3;
		  // 
		  // barraBottom
		  // 
		  this.barraBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
		  this.barraBottom.Location = new System.Drawing.Point(3, 52);
		  this.barraBottom.Name = "barraBottom";
		  this.barraBottom.Size = new System.Drawing.Size(629, 3);
		  this.barraBottom.TabIndex = 2;
		  // 
		  // barraLeft
		  // 
		  this.barraLeft.Dock = System.Windows.Forms.DockStyle.Left;
		  this.barraLeft.Location = new System.Drawing.Point(0, 3);
		  this.barraLeft.Name = "barraLeft";
		  this.barraLeft.Size = new System.Drawing.Size(3, 52);
		  this.barraLeft.TabIndex = 1;
		  // 
		  // barraTop
		  // 
		  this.barraTop.Dock = System.Windows.Forms.DockStyle.Top;
		  this.barraTop.Location = new System.Drawing.Point(0, 0);
		  this.barraTop.Name = "barraTop";
		  this.barraTop.Size = new System.Drawing.Size(632, 3);
		  this.barraTop.TabIndex = 0;
		  // 
		  // VistaFicheroMaestroWf
		  // 
		  this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		  this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		  this.BackColor = System.Drawing.Color.White;
		  this.ClientSize = new System.Drawing.Size(632, 424);
		  this.Controls.Add(this.marcoBarra);
		  this.Controls.Add(this.barraStatus);
		  this.Name = "VistaFicheroMaestroWf";
		  this.Controls.SetChildIndex(this.Nula, 0);
		  this.Controls.SetChildIndex(this.barraStatus, 0);
		  this.Controls.SetChildIndex(this.marcoBarra, 0);
		  ((System.ComponentModel.ISupportInitialize)(this.Incumplimiento)).EndInit();
		  this.barraStatus.ResumeLayout(false);
		  this.barraStatus.PerformLayout();
		  this.marcoBarra.ResumeLayout(false);
		  this.marcoBarra.PerformLayout();
		  this.barraHerramientas.ResumeLayout(false);
		  this.barraHerramientas.PerformLayout();
		  this.ResumeLayout(false);
		  this.PerformLayout();
		}
		protected System.Windows.Forms.ToolStripStatusLabel ayudaEdicion;
		protected System.Windows.Forms.ToolStripButton botonFinal;
		protected System.Windows.Forms.ToolStripButton botonSiguiente;
		protected System.Windows.Forms.ToolStripButton botonPrevio;
		protected System.Windows.Forms.ToolStripButton botonInicio;
		protected System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

		#endregion

		protected System.Windows.Forms.ToolStrip barraHerramientas;
		private System.Windows.Forms.Panel barraRight;
		private System.Windows.Forms.Panel barraBottom;
		private System.Windows.Forms.Panel barraLeft;
		private System.Windows.Forms.Panel barraTop;
		protected System.Windows.Forms.Panel marcoBarra;
		protected System.Windows.Forms.ToolStripButton botonCrear;
		protected System.Windows.Forms.ToolStripButton botonDuplicar;
		protected System.Windows.Forms.ToolStripButton botonBuscar;
		protected System.Windows.Forms.ToolStripButton botonModificar;
		protected System.Windows.Forms.ToolStripButton botonArchivar;
		protected System.Windows.Forms.ToolStripButton botonEliminar;
		protected System.Windows.Forms.ToolStripStatusLabel cuentaRegistros;
		protected System.Windows.Forms.ToolStripStatusLabel statusControlador;
		protected System.Windows.Forms.StatusStrip barraStatus;
	}
}