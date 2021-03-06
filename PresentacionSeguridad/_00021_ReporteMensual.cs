﻿using Servicio.RecursoHumano.Agente;
using Servicio.RecursoHumano.Agente.DTOs;
using Servicio.RecursoHumano.Configuracion;
using Servicio.RecursoHumano.Reportes;
using Servicio.RecursoHumano.Reportes.DTOs;
using Servicio.RecursoHumano.Sector;
using Servicio.RecursoHumano.Sector.DTOs;
using Servicio.RecursoHumano.SubSector;
using Servicio.RecursoHumano.SubSector.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace PresentacionRecursoHumano
{
    public partial class _00021_ReporteMensual : PresentacionBase.FormularioBase
    {
        private readonly IAgenteServicio _agenteServicio;
        private readonly ISectorServicio _sectorServicio;
        private readonly ISubSectorServicio _subsectorServicio;
        private IReporteMensualServicio _reporteServicio;
        private List<int> _listaAños;
        private List<string> _listaMeses;
        private IEnumerable<AgenteDTO> _listaAgentes;
        private AgenteDTO _agenteSeleccionado;
        private List<ReporteMensualDTO> _reporteAgenteSeleccionado;
        private int _filaAgente;

        public _00021_ReporteMensual()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            _agenteServicio = new AgenteServicio();
            _sectorServicio = new SectorServicio();
            _subsectorServicio = new SubSectorServicio();
            _agenteSeleccionado = null;

            _filaAgente = -1;
        }

        public _00021_ReporteMensual(string titulo) : this()
        {
            Text = titulo;
        }

        public void FormatearGrillaAgentes(DataGridView dgvAgentes)
        {
            base.FormatearGrilla(dgvAgentes);

            this.dgvAgentes.Columns["Legajo"].Visible = true;
            this.dgvAgentes.Columns["Legajo"].HeaderText = "Legajo";
            this.dgvAgentes.Columns["Legajo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvAgentes.Columns["Legajo"].DisplayIndex = 1;

            this.dgvAgentes.Columns["ApyNom"].Visible = true;
            this.dgvAgentes.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            this.dgvAgentes.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvAgentes.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvAgentes.Columns["ApyNom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void CheckearColumna(DataGridView grilla, string nombreColumna)
        {
            if (!this.dgvReporte.Columns.Contains(nombreColumna))
            {
                var columna = new DataGridViewColumn();
                var celda = new DataGridViewTextBoxCell();
                columna.CellTemplate = celda;
                columna.Name = nombreColumna;

                this.dgvReporte.Columns.Add(columna);
            }
        }

        public void FormatearGrillaReporte(DataGridView dgvReporte)
        {
            base.FormatearGrilla(dgvReporte);

            CheckearColumna(dgvReporte, "Numero");
            CheckearColumna(dgvReporte, "FechaStr");
            CheckearColumna(dgvReporte, "Dia");
            CheckearColumna(dgvReporte, "AusenteStr");
            CheckearColumna(dgvReporte, "HoraEntradaStr");
            CheckearColumna(dgvReporte, "MinutosTardeStr");
            CheckearColumna(dgvReporte, "HoraSalidaParcialStr");
            CheckearColumna(dgvReporte, "HoraEntradaParcialStr");
            CheckearColumna(dgvReporte, "MinutosTardeExtensionStr");
            CheckearColumna(dgvReporte, "HoraSalidaStr");
            CheckearColumna(dgvReporte, "MinutosFaltantesExtensionStr");
            CheckearColumna(dgvReporte, "Filler");

            this.dgvReporte.Columns["Numero"].Visible = true;
            this.dgvReporte.Columns["Numero"].HeaderText = "Nº";
            this.dgvReporte.Columns["Numero"].Width = 30;
            this.dgvReporte.Columns["Numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["Numero"].DisplayIndex = 0;

            
            this.dgvReporte.Columns["FechaStr"].Visible = true;
            this.dgvReporte.Columns["FechaStr"].HeaderText = "Fecha";
            this.dgvReporte.Columns["FechaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["FechaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["FechaStr"].DisplayIndex = 1;

            
            this.dgvReporte.Columns["Dia"].Visible = true;
            this.dgvReporte.Columns["Dia"].HeaderText = "Día";
            this.dgvReporte.Columns["Dia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvReporte.Columns["Dia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["Dia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvReporte.Columns["Dia"].DisplayIndex = 2;

            
            this.dgvReporte.Columns["AusenteStr"].Visible = true;
            this.dgvReporte.Columns["AusenteStr"].HeaderText = "Ausente";
            this.dgvReporte.Columns["AusenteStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvReporte.Columns["AusenteStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["AusenteStr"].DisplayIndex = 3;

            
            this.dgvReporte.Columns["HoraEntradaStr"].Visible = true;
            this.dgvReporte.Columns["HoraEntradaStr"].HeaderText = "Hora Entrada";
            this.dgvReporte.Columns["HoraEntradaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvReporte.Columns["HoraEntradaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["HoraEntradaStr"].DisplayIndex = 4;

            
            this.dgvReporte.Columns["MinutosTardeStr"].Visible = true;
            this.dgvReporte.Columns["MinutosTardeStr"].HeaderText = "Minutos Tarde";
            this.dgvReporte.Columns["MinutosTardeStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvReporte.Columns["MinutosTardeStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["MinutosTardeStr"].DisplayIndex = 5;

            
            this.dgvReporte.Columns["HoraSalidaParcialStr"].Visible = true;
            this.dgvReporte.Columns["HoraSalidaParcialStr"].HeaderText = "Salida Parcial";
            this.dgvReporte.Columns["HoraSalidaParcialStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvReporte.Columns["HoraSalidaParcialStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["HoraSalidaParcialStr"].DisplayIndex = 6;

            
            this.dgvReporte.Columns["MinutosFaltantesStr"].Visible = true;
            this.dgvReporte.Columns["MinutosFaltantesStr"].HeaderText = "Minutos Faltantes";
            this.dgvReporte.Columns["MinutosFaltantesStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvReporte.Columns["MinutosFaltantesStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["MinutosFaltantesStr"].DisplayIndex = 7;

            
            this.dgvReporte.Columns["HoraEntradaParcialStr"].Visible = true;
            this.dgvReporte.Columns["HoraEntradaParcialStr"].HeaderText = "Entrada Parcial";
            this.dgvReporte.Columns["HoraEntradaParcialStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvReporte.Columns["HoraEntradaParcialStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["HoraEntradaParcialStr"].DisplayIndex = 8;

            
            this.dgvReporte.Columns["MinutosTardeExtensionStr"].Visible = true;
            this.dgvReporte.Columns["MinutosTardeExtensionStr"].HeaderText = "Minutos Tarde";
            this.dgvReporte.Columns["MinutosTardeExtensionStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvReporte.Columns["MinutosTardeExtensionStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["MinutosTardeExtensionStr"].DisplayIndex = 9;

            
            this.dgvReporte.Columns["HoraSalidaStr"].Visible = true;
            this.dgvReporte.Columns["HoraSalidaStr"].HeaderText = "Hora Salida";
            this.dgvReporte.Columns["HoraSalidaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvReporte.Columns["HoraSalidaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["HoraSalidaStr"].DisplayIndex = 10;

            
            this.dgvReporte.Columns["MinutosFaltantesExtensionStr"].Visible = true;
            this.dgvReporte.Columns["MinutosFaltantesExtensionStr"].HeaderText = "Minutos Faltantes";
            this.dgvReporte.Columns["MinutosFaltantesExtensionStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvReporte.Columns["MinutosFaltantesExtensionStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvReporte.Columns["MinutosFaltantesExtensionStr"].DisplayIndex = 11;

            
            this.dgvReporte.Columns["Filler"].Visible = true;
            this.dgvReporte.Columns["Filler"].HeaderText = "";
            this.dgvReporte.Columns["Filler"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvReporte.Columns["Filler"].ReadOnly = true;
            this.dgvReporte.Columns["Filler"].DisplayIndex = 12;
        }

        public void FormatearGrillaNovedades(DataGridView dgvNovedades)
        {
            base.FormatearGrilla(dgvNovedades);

            this.dgvNovedades.Columns["FechaDesde"].Visible = true;
            this.dgvNovedades.Columns["FechaDesde"].HeaderText = "Fecha Desde";
            this.dgvNovedades.Columns["FechaDesde"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvNovedades.Columns["FechaDesde"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvNovedades.Columns["FechaDesde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvNovedades.Columns["FechaDesde"].DisplayIndex = 1;
                 
            this.dgvNovedades.Columns["FechaHasta"].Visible = true;
            this.dgvNovedades.Columns["FechaHasta"].HeaderText = "Fecha Hasta";
            this.dgvNovedades.Columns["FechaHasta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvNovedades.Columns["FechaHasta"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvNovedades.Columns["FechaHasta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvNovedades.Columns["FechaHasta"].DisplayIndex = 2;
                
            this.dgvNovedades.Columns["HoraDesde"].Visible = true;
            this.dgvNovedades.Columns["HoraDesde"].HeaderText = "Hora Desde";
            this.dgvNovedades.Columns["HoraDesde"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvNovedades.Columns["HoraDesde"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvNovedades.Columns["HoraDesde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvNovedades.Columns["HoraDesde"].DisplayIndex = 3;
               
            this.dgvNovedades.Columns["HoraHasta"].Visible = true;
            this.dgvNovedades.Columns["HoraHasta"].HeaderText = "Hora Hasta";
            this.dgvNovedades.Columns["HoraHasta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvNovedades.Columns["HoraHasta"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvNovedades.Columns["HoraHasta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvNovedades.Columns["HoraHasta"].DisplayIndex = 4;
                
            this.dgvNovedades.Columns["Observacion"].Visible = true;
            this.dgvNovedades.Columns["Observacion"].HeaderText = "Observaciones";
            this.dgvNovedades.Columns["Observacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvNovedades.Columns["Observacion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvNovedades.Columns["Observacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvNovedades.Columns["Observacion"].DisplayIndex = 5;
        }

        public void FormatearGrillaLactancias(DataGridView dgvLactancias)
        {
            base.FormatearGrilla(dgvLactancias);

            this.dgvLactancias.Columns["FechaDesdeStr"].Visible = true;
            this.dgvLactancias.Columns["FechaDesdeStr"].HeaderText = "Fecha Desde";
            this.dgvLactancias.Columns["FechaDesdeStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvLactancias.Columns["FechaDesdeStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["FechaDesdeStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["FechaDesdeStr"].DisplayIndex = 1;
                    
            this.dgvLactancias.Columns["FechaHastaStr"].Visible = true;
            this.dgvLactancias.Columns["FechaHastaStr"].HeaderText = "Fecha Hasta";
            this.dgvLactancias.Columns["FechaHastaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvLactancias.Columns["FechaHastaStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["FechaHastaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["FechaHastaStr"].DisplayIndex = 2;
                    
            this.dgvLactancias.Columns["LunesStr"].Visible = true;
            this.dgvLactancias.Columns["LunesStr"].HeaderText = "Lunes";
            this.dgvLactancias.Columns["LunesStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvLactancias.Columns["LunesStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["LunesStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["LunesStr"].DisplayIndex = 3;
                    
            this.dgvLactancias.Columns["MartesStr"].Visible = true;
            this.dgvLactancias.Columns["MartesStr"].HeaderText = "Martes";
            this.dgvLactancias.Columns["MartesStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvLactancias.Columns["MartesStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["MartesStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["MartesStr"].DisplayIndex = 4;
                   
            this.dgvLactancias.Columns["MiercolesStr"].Visible = true;
            this.dgvLactancias.Columns["MiercolesStr"].HeaderText = "Miércoles";
            this.dgvLactancias.Columns["MiercolesStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvLactancias.Columns["MiercolesStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["MiercolesStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["MiercolesStr"].DisplayIndex = 5;

            this.dgvLactancias.Columns["JuevesStr"].Visible = true;
            this.dgvLactancias.Columns["JuevesStr"].HeaderText = "Jueves";
            this.dgvLactancias.Columns["JuevesStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvLactancias.Columns["JuevesStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["JuevesStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["JuevesStr"].DisplayIndex = 6;

            this.dgvLactancias.Columns["ViernesStr"].Visible = true;
            this.dgvLactancias.Columns["ViernesStr"].HeaderText = "Viernes";
            this.dgvLactancias.Columns["ViernesStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvLactancias.Columns["ViernesStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["ViernesStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["ViernesStr"].DisplayIndex = 7;

            this.dgvLactancias.Columns["SabadoStr"].Visible = true;
            this.dgvLactancias.Columns["SabadoStr"].HeaderText = "Sábado";
            this.dgvLactancias.Columns["SabadoStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvLactancias.Columns["SabadoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["SabadoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["SabadoStr"].DisplayIndex = 8;

            this.dgvLactancias.Columns["DomingoStr"].Visible = true;
            this.dgvLactancias.Columns["DomingoStr"].HeaderText = "Domingo";
            this.dgvLactancias.Columns["DomingoStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvLactancias.Columns["DomingoStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["DomingoStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvLactancias.Columns["DomingoStr"].DisplayIndex = 9;
        }

        public void FormatearGrillaComisiones(DataGridView dgvComisiones)
        {
            base.FormatearGrilla(dgvComisiones);

            this.dgvComisiones.Columns["Descripcion"].Visible = true;
            this.dgvComisiones.Columns["Descripcion"].HeaderText = "Descripción";
            this.dgvComisiones.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvComisiones.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvComisiones.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvComisiones.Columns["Descripcion"].DisplayIndex = 0;

            this.dgvComisiones.Columns["FechaDesdeStr"].Visible = true;
            this.dgvComisiones.Columns["FechaDesdeStr"].HeaderText = "Desde";
            this.dgvComisiones.Columns["FechaDesdeStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvComisiones.Columns["FechaDesdeStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvComisiones.Columns["FechaDesdeStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvComisiones.Columns["FechaDesdeStr"].DisplayIndex = 1;
        
            this.dgvComisiones.Columns["FechaHastaStr"].Visible = true;
            this.dgvComisiones.Columns["FechaHastaStr"].HeaderText = "Hasta";
            this.dgvComisiones.Columns["FechaHastaStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvComisiones.Columns["FechaHastaStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvComisiones.Columns["FechaHastaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvComisiones.Columns["FechaHastaStr"].DisplayIndex = 2;

            this.dgvComisiones.Columns["HoraInicioStr"].Visible = true;
            this.dgvComisiones.Columns["HoraInicioStr"].HeaderText = "Inicio";
            this.dgvComisiones.Columns["HoraInicioStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvComisiones.Columns["HoraInicioStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvComisiones.Columns["HoraInicioStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvComisiones.Columns["HoraInicioStr"].DisplayIndex = 3;
                    
            this.dgvComisiones.Columns["HoraFinStr"].Visible = true;
            this.dgvComisiones.Columns["HoraFinStr"].HeaderText = "Fin";
            this.dgvComisiones.Columns["HoraFinStr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvComisiones.Columns["HoraFinStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvComisiones.Columns["HoraFinStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvComisiones.Columns["HoraFinStr"].DisplayIndex = 4;
                   
            this.dgvComisiones.Columns["JornadaCompletaStr"].Visible = true;
            this.dgvComisiones.Columns["JornadaCompletaStr"].HeaderText = "Jornada Completa";
            this.dgvComisiones.Columns["JornadaCompletaStr"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvComisiones.Columns["JornadaCompletaStr"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvComisiones.Columns["JornadaCompletaStr"].Width = 111;
            this.dgvComisiones.Columns["JornadaCompletaStr"].DisplayIndex = 5;            
                 
            this.dgvComisiones.Columns["Observaciones"].Visible = true;
            this.dgvComisiones.Columns["Observaciones"].HeaderText = "Observaciones";
            this.dgvComisiones.Columns["Observaciones"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.dgvComisiones.Columns["Observaciones"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvComisiones.Columns["Observaciones"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgvComisiones.Columns["Observaciones"].DisplayIndex = 7;     
        }

        private void ActualizarAgentes()
        {
            if (cmbArea.SelectedItem == null || cmbDireccion.SelectedItem == null) {
                _listaAgentes = new List<AgenteDTO>();
                dgvAgentes.DataSource = _listaAgentes;
                CargarAutoComplete(true);
            }
            else
            {
                _listaAgentes = _agenteServicio.ObtenerPorFiltro(((SubSectorDTO)cmbArea.SelectedItem).Descripcion);
                dgvAgentes.DataSource = _listaAgentes;
                dgvReporte.DataSource = _reporteAgenteSeleccionado;
                CargarAutoComplete();
            }

            FormatearGrillaAgentes(dgvAgentes);
        }

        private void ActualizarReporte()
        {
                lblApyNom.Text = _agenteSeleccionado.ApyNom;
                lblLegajo.Text = _agenteSeleccionado.Legajo;

                _reporteServicio = new ReporteMensualServicio(_agenteSeleccionado.Id, MesReporte());
                _reporteAgenteSeleccionado = _reporteServicio.ObtenerPorId(_agenteSeleccionado.Id, (int)cmbAño.SelectedItem, (int)cmbMes.SelectedIndex + 1);
                dgvReporte.DataSource = _reporteAgenteSeleccionado;

                FormatearGrillaReporte(dgvReporte);

                if (_reporteAgenteSeleccionado.Any())
                {
                    dgvNovedades.DataSource = null;
                    tclDetalles.TabPages[0].Text = "Novedades";
                    dgvComisiones.DataSource = null;
                    tclDetalles.TabPages[1].Text = "Comisiones de servicio";
                    dgvLactancias.DataSource = null;
                    tclDetalles.TabPages[2].Text = "Lactancias";

                    if (_reporteAgenteSeleccionado.Last().Lactancias.Any() && chkLactancias.Checked)
                    {
                        dgvLactancias.Enabled = true;
                        dgvLactancias.DataSource = _reporteAgenteSeleccionado.Last().Lactancias.AsParallel().ToList();

                        tclDetalles.TabPages[2].Text = "Lactancias";
                        tclDetalles.TabPages[2].Text += string.Format(" ({0})", dgvLactancias.RowCount);
                        tclDetalles.SelectTab(2);

                        FormatearGrillaLactancias(dgvLactancias);
                    }

                    if (_reporteAgenteSeleccionado.Last().Comisiones.Any() && chkComsiones.Checked)
                    {
                        dgvComisiones.Enabled = true;
                        dgvComisiones.DataSource = _reporteAgenteSeleccionado.Last().Comisiones.AsParallel().ToList();
                        tclDetalles.TabPages[1].Text = "Comisiones de servicio";
                        tclDetalles.TabPages[1].Text += string.Format(" ({0})", dgvComisiones.RowCount);
                        tclDetalles.SelectTab(1);

                        FormatearGrillaComisiones(dgvComisiones);
                    }

                    if (_reporteAgenteSeleccionado.Last().Novedades.Any() && chkNovedades.Checked)
                    {
                        dgvNovedades.Enabled = true;
                        dgvNovedades.DataSource = _reporteAgenteSeleccionado.Last().Novedades.AsParallel().ToList();

                        tclDetalles.TabPages[0].Text = "Novedades";
                        tclDetalles.TabPages[0].Text += string.Format(" ({0})", dgvNovedades.RowCount);
                        tclDetalles.SelectTab(0);

                        FormatearGrillaNovedades(dgvNovedades);
                    }     
                }
                else
                {
                    if (!_reporteAgenteSeleccionado.Any() || !chkNovedades.Checked)
                    {
                        dgvNovedades.DataSource = null;
                        dgvNovedades.Enabled = false;
                        tclDetalles.TabPages[0].Text = "Novedades";
                    }

                    if (!_reporteAgenteSeleccionado.Any() || !chkComsiones.Checked)
                    {
                        dgvComisiones.DataSource = null;
                        dgvComisiones.Enabled = false;
                        tclDetalles.TabPages[1].Text = "Comisiones de servicio";
                    }

                    if (!_reporteAgenteSeleccionado.Any() || !chkLactancias.Checked)
                    {
                        dgvLactancias.DataSource = null;
                        dgvLactancias.Enabled = false;
                        tclDetalles.TabPages[2].Text = "Lactancias";
                    }
                }

                lblAusenciasTotales.Text = ObtenerInasistenciasTotales().ToString();
                lblAusenciasPorLlegadasTarde.Text = ObtenerInasistenciasPorLlegadasTarde().ToString();
                lblLlegadasTarde.Text = ObtenerLlegadasTarde().ToString();
                lblJornadasIncumplidas.Text = ObtenerJornadasIncumplidas().ToString();
         
        }

        private int ObtenerInasistenciasTotales()
        {
            int inasistencias = 0;

            foreach (ReporteMensualDTO item in _reporteAgenteSeleccionado)
            {
                inasistencias += item.Ausente == null ? 0 : (bool)item.Ausente ? 1 : 0;
            }

            return inasistencias;
        }

        private int ObtenerInasistenciasPorLlegadasTarde() // CAMBIAR (solo las de la mañana cuentan para las inasistencias) --> las otras para el incumpliemiento de la jornada laboral
        {
            int inasistencias = 0;

            foreach (ReporteMensualDTO item in _reporteAgenteSeleccionado)
            {
                inasistencias += item.AusentePorLlegarTarde == null ? 0 : (bool)item.AusentePorLlegarTarde ? 1 : 0;
            }

            return inasistencias;
        }

        private int ObtenerLlegadasTarde() // CAMBIAR --> 2 llegadas tarde (que superen el limite) == 1 ausente
        {
            int llegadasTarde = 0;

            foreach (ReporteMensualDTO item in _reporteAgenteSeleccionado)
            {
                llegadasTarde += ((item.AusentePorLlegarTarde != null && ((bool)item.AusentePorLlegarTarde)) || ((item.MinutosTardeStr != "-" && item.MinutosTardeStr != ""))) ? 1 : 0;
            }

            return llegadasTarde;
        }

        private int ObtenerJornadasIncumplidas() // CAMBIAR --> solo las de la mañana, hacia atrás; las de la tarde hacia adelante
        {
            int llegadasTarde = 0;

            foreach (ReporteMensualDTO item in _reporteAgenteSeleccionado)
            {
                if ((item.AusentePorLlegarTarde != null && (bool)item.AusentePorLlegarTarde) || (((item.MinutosTardeExtension != null && item.MinutosTarde != null)) && (((TimeSpan)item.MinutosTardeExtension).Minutes + ((TimeSpan)item.MinutosTarde).Minutes) > ConfiguracionServicio.MinutosToleranciaLlegadaTarde)) llegadasTarde++;

            }

            return llegadasTarde;
        }

        public void CargarComboBox(ComboBox cmb, object lista, string propiedadMostrar, string propiedadDevolver = "Id")
        {
            cmb.DataSource = lista;
            cmb.DisplayMember = propiedadMostrar;
            cmb.ValueMember = propiedadDevolver;
        }

        public void CargarAutoComplete(bool vacio = false)
        {
            List<string> datos = new List<string>();

            txtBuscar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            if (!vacio)
            {
                coleccion.AddRange(_listaAgentes.Select(agente => agente.ApyNom).ToArray());
                coleccion.AddRange(_listaAgentes.Select(agente => agente.Legajo).ToArray());
            }

            txtBuscar.AutoCompleteCustomSource = coleccion;
        }

        public AgenteDTO BuscarAgente(object busqueda, string criterio)
        {
            foreach (var agente in _listaAgentes)
            {
                if (agente.GetType().GetProperty(criterio).GetValue(agente, null).ToString() == busqueda.ToString()) return agente;
            }

            return null;
        }

        private DateTime MesReporte()
        {
            int day = 1;
            int month = DateTime.ParseExact((string)cmbMes.SelectedItem, "MMMM", new CultureInfo("es-Ar")).Month;
            int year = (int)cmbAño.SelectedItem;

            return new DateTime(year, month, day);
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (DataGridViewRow row in dgvAgentes.Rows)
                {
                    if ((row.Cells["ApyNom"].Value.ToString().ToLower() == txtBuscar.Text.ToLower()) || (row.Cells["Legajo"].Value.ToString().ToLower() == txtBuscar.Text.ToLower()))
                    {
                        dgvAgentes.CurrentCell = row.Cells["Legajo"];
                        txtBuscar.Clear();
                        dgvAgentes.Focus();
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _00021_ReporteMensual_Load(object sender, EventArgs e)
        {
            try
            {
                cmbAño.DataSource = ReporteMensualServicio.ListaAños();
                cmbMes.DataSource = ReporteMensualServicio.ListaMeses();
            }
            catch(Exception ex)
            {
            } 
            finally {
                try
                {
                    lblApyNom.Text = String.Empty;
                    lblLegajo.Text = String.Empty;

                    this.txtBuscar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    this.txtBuscar.AutoCompleteSource = AutoCompleteSource.CustomSource;

                    
                    
                }
                catch(Exception ex)
                {
                }
                finally {
                    try
                    {
                        CargarComboBox(this.cmbDireccion, _sectorServicio.ObtenerTodo(), "Descripcion");
                        CargarComboBox(this.cmbArea, _subsectorServicio.ObtenerTodo(((SectorDTO)cmbDireccion.SelectedItem).Id), "Descripcion");
                        _agenteSeleccionado = _agenteServicio.ObtenerPorFiltro(((SubSectorDTO)cmbArea.SelectedItem).Descripcion).First();

                        ActualizarAgentes();

                        dgvReporte.TabStop = false;
                        dgvLactancias.TabStop = false;
                        dgvNovedades.TabStop = false;
                        dgvComisiones.TabStop = false;

                        dgvAgentes.Focus();
                        ActualizarReporte();
                    }
                    catch
                    {
                    }
                }
            }                 
        }
   
        private void cmbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ActualizarAgentes();
        }

        private void cmbDireccion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CargarComboBox(this.cmbArea, _subsectorServicio.ObtenerTodo(((SectorDTO)cmbDireccion.SelectedItem).Id), "Descripcion");
            ActualizarAgentes();
        }

        private void dgvAgentes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAgentes.RowCount > 0) {
                _filaAgente = e.RowIndex;
                _agenteSeleccionado = (AgenteDTO)dgvAgentes.Rows[_filaAgente].DataBoundItem;
                
                btnActualizar.PerformClick();
                //cmbMes.SelectedIndex = DateTime.Now.Month - 1;
            }
            else
            {
                _filaAgente = -1;
                _agenteSeleccionado = null;
            }          
        }

        private void chkComsiones_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarReporte();
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarReporte();
        }

        private void cmbAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarReporte();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarReporte();
        }
    }
}
