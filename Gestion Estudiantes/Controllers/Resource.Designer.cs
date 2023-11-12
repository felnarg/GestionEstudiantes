﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gestion_Estudiantes.Controllers {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Gestion_Estudiantes.Controllers.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a &quot;El estudiante {0} estudia los días Lunes, Martes, Miercoles, Jueves y Viernes&quot;.
        /// </summary>
        internal static string DailyClassDay {
            get {
                return ResourceManager.GetString("DailyClassDay", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a &quot;El estudiante {0} estudia los días Viernes y Sábados&quot;.
        /// </summary>
        internal static string DailyClassNight {
            get {
                return ResourceManager.GetString("DailyClassNight", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a &quot;(Horario diurno)&quot;.
        /// </summary>
        internal static string DailyTypeMorning {
            get {
                return ResourceManager.GetString("DailyTypeMorning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a &quot;(Horario nocturno)&quot;.
        /// </summary>
        internal static string DailyTypeNight {
            get {
                return ResourceManager.GetString("DailyTypeNight", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a &quot;El Id ingresado ya existe en la base de datos&quot;.
        /// </summary>
        internal static string DuplicateKey {
            get {
                return ResourceManager.GetString("DuplicateKey", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a &quot;El campo {0} es requerido&quot;.
        /// </summary>
        internal static string FieldVerify {
            get {
                return ResourceManager.GetString("FieldVerify", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a &quot;No se encuentra el id en la base de datos&quot;.
        /// </summary>
        internal static string IdNotFound {
            get {
                return ResourceManager.GetString("IdNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a &quot;Operación exitosa&quot;.
        /// </summary>
        internal static string Ok {
            get {
                return ResourceManager.GetString("Ok", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a &quot;Eliminación exitosa&quot;.
        /// </summary>
        internal static string OkRemove {
            get {
                return ResourceManager.GetString("OkRemove", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a &quot;Se ha guardado con exito&quot;.
        /// </summary>
        internal static string OkSave {
            get {
                return ResourceManager.GetString("OkSave", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a &quot;Actualización exitosa&quot;.
        /// </summary>
        internal static string OkUpdate {
            get {
                return ResourceManager.GetString("OkUpdate", resourceCulture);
            }
        }
    }
}
