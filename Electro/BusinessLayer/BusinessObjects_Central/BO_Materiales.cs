/*
(C)2023
Autor: HDL
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Transactions;
using Electro.BusinessLayer.ValueObjects;
using Electro.BusinessLayer.BusinessObjects;
using Electro.DataLayer.Interfaces;
using Electro.DataLayer.DataObjects;


namespace Electro.BusinessLayer.BusinessObjects
{
    /// <summary>
    /// Clase que presenta la logica de negocio de Cliente.
	/// para la utilizacion desde la capa de presentación
    /// </summary>  
    [DataObject(true)]
    public partial class BO_Materiales
    {

        #region Constructores

        public BO_Materiales()
        {
        }

        #endregion


        #region Alta

        public Respuesta Alta_Area(String pNombre_Area, Int16 pFK_ID_Planta, Int16 pFK_ID_Sector, Int32 pFK_ID_Usuario)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                using (TransactionScope _transaction = new TransactionScope())
                {
                    DataAccess.Materiales.Alta_Area(pNombre_Area, pFK_ID_Planta, pFK_ID_Usuario);

                    _transaction.Complete();
                }

                //Se genera un LOG para el alta
                DataAccess.Log.Informar_Evento(1, "Se realizó correctamente el alta del área " + pNombre_Area, pFK_ID_Usuario);
                _respuesta.Mensaje = "El área se ingreso correctamente";
                _respuesta.Resultado = Resultado_Operacion.Ok;

            }
            catch (Exception ex)
            {
                //Se genera un LOG para el error
                DataAccess.Log.Informar_Evento(1, "Alta_Area - " + ex.Message, pFK_ID_Usuario);
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public Respuesta Alta_Materiales(Int16 pFK_ID_Tipo_Material, String pMaterial_Descripcion, String pCodigo_Origen, String pCodigo_Interno, Int16 pCantidad, String pUbicacion_Estanteria, String pUbicacion_Columna, String pUbicacion_Fila, Int16 pFK_ID_Area, String pUbicacion_Gaveta, Int16 pFK_ID_Planta, Int16 pFK_ID_Sector, Int32 pFK_ID_Usuario)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                using (TransactionScope _transaction = new TransactionScope())
                {
                    DataAccess.Materiales.Alta_Materiales(pFK_ID_Tipo_Material, pMaterial_Descripcion, pCodigo_Origen, pCodigo_Interno, pCantidad, pUbicacion_Estanteria, pUbicacion_Columna, pUbicacion_Fila, pFK_ID_Area, pUbicacion_Gaveta, pFK_ID_Planta, pFK_ID_Sector, pFK_ID_Usuario);

                    _transaction.Complete();
                }

                // Se genera un LOG para el alta
                DataAccess.Log.Informar_Evento(1, "Se realizó correctamente el alta del material " + pMaterial_Descripcion, pFK_ID_Usuario);
                _respuesta.Mensaje = "El material se ingreso correctamente";
                _respuesta.Resultado = Resultado_Operacion.Ok;

            }
            catch (Exception ex)
            {
                // Se genera un LOG para el error
                DataAccess.Log.Informar_Evento(1, "Alta_Materiales - " + ex.Message, pFK_ID_Usuario);
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public Respuesta Alta_Tipo_Materiales(String pTipo_Material, String pDescripcion, Int16 pFK_ID_Estado, Int32 pFK_ID_Usuario)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                using (TransactionScope _transaction = new TransactionScope())
                {
                    DataAccess.Materiales.Alta_Tipo_Materiales(pTipo_Material, pDescripcion,  pFK_ID_Estado,  pFK_ID_Usuario);

                    _transaction.Complete();
                }

                // Se genera un LOG para el alta
                DataAccess.Log.Informar_Evento(1, "Se realizó correctamente el alta del tipo de material " + pTipo_Material, pFK_ID_Usuario);
                _respuesta.Mensaje = "El tipo de material se ingreso correctamente";
                _respuesta.Resultado = Resultado_Operacion.Ok;

            }
            catch (Exception ex)
            {
                // Se genera un LOG para el error
                DataAccess.Log.Informar_Evento(1, "Alta_Tipo_Material - " + ex.Message, pFK_ID_Usuario);
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        #region Modificaciones

        public Respuesta Actualizar_Area(Int32 pID_Area, String pDescripcion, Int16 pFK_ID_Estado)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                OMaterial _miembro = DataAccess.Materiales.Obtener_Area_Por_Nombre(pNombre_Area);

                if (_miembro != null)
                {                    
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Miembros.Actualizar_Miembro_Con_Lider_Red(pId_Miembro, pApellido, pNombre, pDNI, pEdad, pTelefono, pDireccion, pBarrio, pFecha_Nacimiento, pFK_ID_Estado_Civil, pFK_ID_Escalera_Crecimiento, pFK_ID_Lider_Red, pFK_ID_Consolidador, pFK_ID_LiderGDV, pEmail, pFK_ID_Estado, pFK_ID_Condicion);
                        _transaction.Complete();
                    }

                    _respuesta.Mensaje = "Se actualizaron correctamente los datos del miembro: " + pApellido + ", " + pNombre;
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }




        public Respuesta Actualizar_Miembro(Int32 pId_Miembro, String pApellido, String pNombre, Int32 pDNI, Int16 pEdad, String pTelefono, String pDireccion, String pBarrio, String pFecha_Nacimiento, Int16 pFK_ID_Estado_Civil, Int16 pFK_ID_Escalera_Crecimiento, Int16 pFK_ID_Consolidador, Int16 pFK_ID_LiderGDV, String pEmail, Int16 pFK_ID_Estado, Int16 pFK_ID_Condicion)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                OMiembros _miembro = DataAccess.Miembros.Obtener_Miembro_Editar(pId_Miembro);

                if (_miembro != null)
                {                    
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Miembros.Actualizar_Miembro(pId_Miembro, pApellido, pNombre, pDNI, pEdad, pTelefono, pDireccion, pBarrio, pFecha_Nacimiento, pFK_ID_Estado_Civil, pFK_ID_Escalera_Crecimiento, pFK_ID_Consolidador, pFK_ID_LiderGDV, pEmail, pFK_ID_Estado, pFK_ID_Condicion);
                        _transaction.Complete();
                    }

                    _respuesta.Mensaje = "Se actualizaron correctamente los datos del miembro: " + pApellido + ", " + pNombre;
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        
        #endregion

        #region Baja

        public Respuesta Baja_Miembro(Int32 pId_Miembro, String pMotivo_baja, Int32 pFK_ID_Estado)
        {
            Respuesta _respuesta = new Respuesta();
        
            try
            {
                OMiembros _miembro = DataAccess.Miembros.Obtener_Miembro(pId_Miembro);

                if (_miembro != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Miembros.Baja_Miembro(pId_Miembro, pMotivo_baja, pFK_ID_Estado);
                        _transaction.Complete();
                    }

                    _respuesta.Mensaje = "El miembro se dió de baja correctamente.";
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        #endregion



        #region Consultas Miembros
        public RS_Miembros Obtener_Miembro(Int32 pId_Miembro)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro[0] = DataAccess.Miembros.Obtener_Miembro(pId_Miembro);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Miembro_Seleccionado(Int32 pId_Miembro)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro[0] = DataAccess.Miembros.Obtener_Miembro_Seleccionado(pId_Miembro);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Consolidaciones_Por_Filtro(Int16 pID_Miembro, String pFiltro)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Consolidaciones_Por_Filtro(pID_Miembro, pFiltro);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Miembro_Editar(Int32 pId_Miembro)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro[0] = DataAccess.Miembros.Obtener_Miembro_Editar(pId_Miembro);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Miembro_Seleccionado_Por_ID(Int32 pID_Hospedador)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro[0] = DataAccess.Miembros.Obtener_Miembro_Seleccionado_Por_ID(pID_Hospedador);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Miembro_Seleccionado_CDP(Int32 pId_Miembro)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro[0] = DataAccess.Miembros.Obtener_Miembro_Seleccionado_CDP(pId_Miembro);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Miembro_Seleccionado_GDV(Int32 pId_Miembro)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro[0] = DataAccess.Miembros.Obtener_Miembro_Seleccionado_GDV(pId_Miembro);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_GDV_Seleccionado_Por_ID(Int32 pId_GDV)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Grupo_de_Vida = new OGrupo_de_Vida[1];
                _respuesta.Lista_Grupo_de_Vida[0] = DataAccess.Miembros.Obtener_GDV_Seleccionado_Por_ID(pId_GDV);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Miembros_Con_Datos()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro[0] = DataAccess.Miembros.Obtener_Miembros_Con_Datos();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Liderazgo()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Liderazgo = DataAccess.Miembros.Obtener_Liderazgo();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Mes()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Mes = DataAccess.Miembros.Obtener_Mes();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Tipo_Entrega()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Tipo_Entrega = DataAccess.Miembros.Obtener_Tipo_Entrega();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Dia_Semana()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Dia_Semana = DataAccess.Miembros.Obtener_Dia_Semana();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_Civil()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Estado_Civil = DataAccess.Miembros.Obtener_Estado_Civil();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        public RS_Miembros Obtener_Miembros_Por_Filtro(string pFiltro)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Miembros_Por_Filtro(pFiltro);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Miembros_Por_Filtro_Red(String pFiltro, Int16 pFK_ID_Lider_Red)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Miembros_Por_Filtro_Red(pFiltro, pFK_ID_Lider_Red);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_Baja()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Estado = DataAccess.Miembros.Obtener_Estado_Baja();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Condicion()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Condicion = DataAccess.Miembros.Obtener_Condicion();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }
            return _respuesta;
        }
        public RS_Miembros Obtener_Numero_Leccion()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Numero_Leccion = DataAccess.Miembros.Obtener_Numero_Leccion();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_Enviar_A()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Estado = DataAccess.Miembros.Obtener_Estado_Enviar_A();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_Consolidacion()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_Consolidacion();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_Consolidacion_por_Red(Int16 pID_Session)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_Consolidacion_por_Red(pID_Session);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_Consolidacion_Completo()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_Consolidacion_Completo();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_Consolidacion_por_Red_Con_Fecha(Int16 pID_Session, String pFecha_Inicio, String pFecha_Fin)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_Consolidacion_por_Red_Con_Fecha(pID_Session, pFecha_Inicio, pFecha_Fin);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Miembros_por_Lider_GDV(Int16 pID_Lider)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Miembros_por_Lider_GDV(pID_Lider);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        #endregion

        #region Consultas Miembros bajas

        public RS_Miembros Obtener_Estados_Baja_Por_Condicion_Por_Red(Int16 pID_Estado, Int16 pID_Condicion, Int16 pID_Lider_Red, Int16 pID_Lider_GDV)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estados_Baja_Por_Condicion_Por_Red(pID_Estado, pID_Condicion, pID_Lider_Red, pID_Lider_GDV);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Miembro_Baja_Por_Condicion_Por_Red_Editar(Int16 pId_Miembro, Int16 pID_LiderGDV, Int16 pID_Condicion)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro[0] = DataAccess.Miembros.Obtener_Miembro_Baja_Por_Condicion_Por_Red_Editar(pId_Miembro, pID_LiderGDV, pID_Condicion);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        #endregion

        #region Consultas CDP
        public RS_Miembros Obtener_Consolidacion_A_CDP()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro[0] = DataAccess.Miembros.Obtener_Consolidacion_A_CDP();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_CDP()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_CDP();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_CDP_Sin_Lider()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_CDP_Sin_Lider();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_CDP_por_Red(Int16 pID_Session)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_CDP_por_Red(pID_Session);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_CDP_Completo()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_CDP_Completo();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_CDP_por_Red_Con_Fecha(Int16 pID_Session, String pFecha_Inicio, String pFecha_Fin)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_CDP_por_Red_Con_Fecha(pID_Session, pFecha_Inicio, pFecha_Fin);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Miembros_por_Red(Int16 pID_Session)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Miembros_por_Red(pID_Session);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Miembros_Completo()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Miembros_Completo();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Miembros_por_Red_Con_Fecha(Int16 pID_Session, String pFecha_Inicio, String pFecha_Fin)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Miembros_por_Red_Con_Fecha(pID_Session, pFecha_Inicio, pFecha_Fin);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_CDP_Por_Filtro(String pFiltro)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_CDP_Por_Filtro(pFiltro);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public Respuesta Actualizar_Numero_Leccion(int pId_Miembro, Int16 pFK_ID_Numero_Leccion)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                OMiembros _miembro = DataAccess.Miembros.Obtener_Miembro(pId_Miembro);

                if (_miembro != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Miembros.Actualizar_Numero_Leccion(pId_Miembro, pFK_ID_Numero_Leccion);
                        _transaction.Complete();
                    }

                    _respuesta.Mensaje = "La asignación se realizó correctamente";
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        #endregion

        #region Consultas GDV
        public RS_Miembros Obtener_Consolidacion_A_GDV()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro[0] = DataAccess.Miembros.Obtener_Consolidacion_A_GDV();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_GDV()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_GDV();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Sobres_GDV()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Sobres_Grupo = DataAccess.Miembros.Obtener_Sobres_GDV();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Sobre_Seleccionado_Por_ID(Int32 pID_Sobre)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Sobres_Grupo = new OSobre_Grupo[1];
                _respuesta.Lista_Sobres_Grupo[0] = DataAccess.Miembros.Obtener_Sobre_Seleccionado_Por_ID(pID_Sobre);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Sobres_GDV_por_Filtro(Int16 pID_Lider_Red, Int16 pID_Lider_GDV, Int16 pID_Mes, Int16 pAnio)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Sobres_Grupo = DataAccess.Miembros.Obtener_Sobres_GDV_por_Filtro(pID_Lider_Red, pID_Lider_GDV, pID_Mes, pAnio);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_GDV_por_Red(Int16 pID_Session)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_GDV_por_Red(pID_Session);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_GDV_por_Red(Int16 pID_Session)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = new OMiembros[1];
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_GDV_por_Red(pID_Session);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public RS_Miembros Obtener_GDV_por_Red_Nuevo(Int16 pID_Session)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Grupo_de_Vida = new OGrupo_de_Vida[1];
                _respuesta.Lista_Grupo_de_Vida = DataAccess.Miembros.Obtener_GDV_por_Red_Nuevo(pID_Session);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public RS_Miembros Obtener_GDV_Completo()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Grupo_de_Vida = new OGrupo_de_Vida[1];
                _respuesta.Lista_Grupo_de_Vida = DataAccess.Miembros.Obtener_GDV_Completo();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public RS_Miembros Obtener_GDV_por_Red_Con_Fecha(Int16 pID_Session, String pFecha_Inicio, String pFecha_Fin)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Grupo_de_Vida = new OGrupo_de_Vida[1];
                _respuesta.Lista_Grupo_de_Vida = DataAccess.Miembros.Obtener_GDV_por_Red_Con_Fecha(pID_Session, pFecha_Inicio, pFecha_Fin);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public RS_Miembros Obtener_GDV_por_Red_Nuevo2(Int16 pID_Session)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Sobres_Grupo = new OSobre_Grupo[1];
                _respuesta.Lista_Sobres_Grupo = DataAccess.Miembros.Obtener_GDV_por_Red_Nuevo2(pID_Session);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public RS_Miembros Obtener_GDV_Por_Filtro(String pFiltro)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Grupo_de_Vida = new OGrupo_de_Vida[1];
                _respuesta.Lista_Grupo_de_Vida = DataAccess.Miembros.Obtener_GDV_Por_Filtro(pFiltro);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public RS_Miembros Obtener_GDV_Por_Filtro_Red(String pFiltro, Int16 pFK_ID_Lider_Red)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Grupo_de_Vida = new OGrupo_de_Vida[1];
                _respuesta.Lista_Grupo_de_Vida = DataAccess.Miembros.Obtener_GDV_Por_Filtro_Red(pFiltro, pFK_ID_Lider_Red);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        #endregion

        #region Consultas Asistencia
        public Respuesta Actualizar_Asistencia(Int32 ID_Asistencia, Int16 pId_Miembro, Int16 pAnio, Int16 pFK_ID_Mes, String pQuincena_uno_grupo, String pQuincena_uno_culto, String pQuincena_dos_grupo, String pQuincena_dos_culto)
        {
            Respuesta _respuesta = new Respuesta();

            try
            {
                OMiembros _asistencia = DataAccess.Miembros.Obtener_Miembro_Seleccionado_Por_ID(pId_Miembro);

                if (_asistencia != null)
                {
                    using (TransactionScope _transaction = new TransactionScope())
                    {
                        DataAccess.Miembros.Actualizar_Asistencia(ID_Asistencia, pId_Miembro, pAnio, pFK_ID_Mes, pQuincena_uno_grupo, pQuincena_uno_culto, pQuincena_dos_grupo, pQuincena_dos_culto);
                        _transaction.Complete();
                    }

                    _respuesta.Mensaje = "La asistencia de actualizó correctamente";
                    _respuesta.Resultado = Resultado_Operacion.Ok;
                }
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Asistencia_por_Red(Int16 pID_Session)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Asistencia = new OAsistencia[1];
                _respuesta.Lista_Asistencia = DataAccess.Miembros.Obtener_Asistencia_por_Red(pID_Session);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Asistencia_por_Filtro(Int16 pID_Lider_Red, Int16 pID_Responsable, Int16 pID_Mes, Int16 pAnio)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Asistencia = new OAsistencia[1];
                _respuesta.Lista_Asistencia = DataAccess.Miembros.Obtener_Asistencia_por_Filtro(pID_Lider_Red, pID_Responsable, pID_Mes, pAnio);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        #endregion

        #region consultas EDV
        public RS_Miembros Obtener_Consolidacion_A_EDV(int pId_Miembro, string pApellido, string pNombre, string pDireccion, short pFK_ID_Consolidador)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Consultas Lideres
        public RS_Miembros Obtener_Lideres_Activos()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Lideres_Activos();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Lideres_Inactivos()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Lideres_Inactivos();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Lideres_GDV()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Lideres_GDV();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Lideres_GDV_por_Red(Int32 pID_Session)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Lideres_GDV_por_Red(pID_Session);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Lideres_GDV_por_Red2(Int32 pID_Session)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Grupo_de_Vida = DataAccess.Miembros.Obtener_Lideres_GDV_por_Red2(pID_Session);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Lideres_GDV_por_Red3(Int32 pID_Session)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Grupo_de_Vida = DataAccess.Miembros.Obtener_Lideres_GDV_por_Red3(pID_Session);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Lideres_GDV_Nuevo()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Grupo_de_Vida = DataAccess.Miembros.Obtener_Lideres_GDV_Nuevo();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Lideres_CDP_por_Red(Int32 pID_Session)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Lideres_CDP_por_Red(pID_Session);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Lideres_por_Red(Int32 pID_Session)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Lideres_por_Red(pID_Session);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Hospedador_Activos_Por_Red(Int32 pID_Session)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Hospedador_Activos_Por_Red(pID_Session);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Lideres_Red()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Lideres_Red();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Escalera_Crecimiento()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Escalera_Crecimiento = DataAccess.Miembros.Obtener_Escalera_Crecimiento();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        #endregion

        #region Consultas Bautismo
        public RS_Miembros Obtener_Estado_Bautismo(Int16 pID_Estado)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_Bautismo(pID_Estado);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_Bautismo_Por_Red(Int16 pID_Estado, Int16 pID_Lider_Red)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_Bautismo_Por_Red(pID_Estado, pID_Lider_Red);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_Bautismo_Completo(Int16 pID_Estado)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_Bautismo_Completo(pID_Estado);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_Bautismo_Completo_Estadistica(Int16 pID_Estado)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_Bautismo_Completo_Estadistica(pID_Estado);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Estado_Bautismo_Por_Red_Con_Fecha(Int16 pID_Estado, Int16 pID_Lider_Red, String pFecha_Inicio, String pFecha_Fin)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Estado_Bautismo_Por_Red_Con_Fecha(pID_Estado, pID_Lider_Red, pFecha_Inicio, pFecha_Fin);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }
        public RS_Miembros Obtener_Bautismo_Por_Filtro_Red(String pFiltro, Int16 pFK_ID_Lider_Red)
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Miembro = DataAccess.Miembros.Obtener_Bautismo_Por_Filtro_Red(pFiltro, pFK_ID_Lider_Red);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }


        #endregion

        #region Consultas Iglesias
        public RS_Miembros Obtener_Iglesia()
        {
            RS_Miembros _respuesta = new RS_Miembros();

            try
            {
                _respuesta.Lista_Iglesia = DataAccess.Miembros.Obtener_Iglesia();
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;

            }

            return _respuesta;
        }

        #endregion

        public RS_Acciones_Notificaciones Obtener_Acciones_Disponibles_Por_Sistema_Y_Usuario(Int16 pId_Sistema, Int32 pId_Usuario)
        {
            RS_Acciones_Notificaciones _respuesta = new RS_Acciones_Notificaciones();

            try
            {
                _respuesta.Lista = DataAccess.Accion_Notificacion.Obtener_Acciones_Disponibles_Por_Sistema_Y_Usuario(pId_Sistema, pId_Usuario);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
            }

            return _respuesta;
        }

        public RS_Acciones_Notificaciones Obtener_Notificaciones_Disponibles_Por_Sistema_Y_Usuario(Int16 pId_Sistema, Int32 pId_Usuario)
        {
            RS_Acciones_Notificaciones _respuesta = new RS_Acciones_Notificaciones();

            try
            {
                _respuesta.Lista = DataAccess.Accion_Notificacion.Obtener_Notificaciones_Disponibles_Por_Sistema_Y_Usuario(pId_Sistema, pId_Usuario);
                _respuesta.Resultado = Resultado_Operacion.Ok;
            }
            catch (Exception ex)
            {
                _respuesta.Mensaje = ex.Message;
                _respuesta.Resultado = Resultado_Operacion.Error;
                
            }

            return _respuesta;
        }

    }
}

#endregion