using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API.Models.Entidades;
using API.Models.Metodos;

namespace API.Models.Catalogos
{
    public class CatalogoRespuestasHTTP
    {
        List<RespuestaHTTP> lista = new List<RespuestaHTTP>();
        public List<RespuestaHTTP> consultar() {

            lista.Add(new RespuestaHTTP() {
                codigo  = "100",
                titulo  = "Continue",
                mensaje = "El navegador puede continuar realizando su petición (se utiliza para indicar que la primera parte de la petición del navegador se ha recibido correctamente)."
            });
            lista.Add(new RespuestaHTTP()
            {
                codigo = "200",
                titulo = "OK",
                mensaje ="Peticion correcta."
            });
            lista.Add(new RespuestaHTTP()
            {
                codigo = "202",
                titulo = "Accepted",
                mensaje = "La petición ha sido aceptada para procesamiento, pero este no ha sido completado. La petición eventualmente pudiere no ser satisfecha, ya que podría ser no permitida o prohibida cuando el procesamiento tenga lugar."
            });
            lista.Add(new RespuestaHTTP()
            {
                codigo = "203",
                titulo = "Non-Authoritative Information (desde HTTP/1.1)",
                mensaje = "La petición se ha completado con éxito, pero su contenido no se ha obtenido de la fuente originalmente solicitada sino de otro servidor."
            });
            lista.Add(new RespuestaHTTP()
            {
                codigo = "204",
                titulo = "No Content",
                mensaje = "La petición se ha completado con éxito pero su respuesta no tiene ningún contenido (la respuesta puede incluir información en sus cabeceras HTTP)"
            });
            lista.Add(new RespuestaHTTP()
            {
                codigo = "205",
                titulo = "Reset Content",
                mensaje = "La petición se ha completado con éxito, pero su respuesta no tiene contenidos y además, el navegador tiene que inicializar la página desde la que se realizó la petición (este código es útil por ejemplo para páginas con formularios cuyo contenido debe borrarse después de que el usuario lo envíe)."
            });
            lista.Add(new RespuestaHTTP()
            {
                codigo = "400",
                titulo = "Bad Request",
                mensaje = "El servidor no procesará la solicitud, porque no puede, o no debe, debido a algo que es percibido como un error del cliente (ej: solicitud malformada, sintaxis errónea, etc). La solicitud contiene sintaxis errónea y no debería repetirse."
            });
            lista.Add(new RespuestaHTTP()
            {
                codigo = "401",
                titulo = "Unauthorized",
                mensaje = "Similar al 403 Forbidden, pero específicamente para su uso cuando la autentificación es posible pero ha fallado o aún no ha sido provista."
            });
            lista.Add(new RespuestaHTTP()
            {
                codigo = "403",
                titulo = "Forbidden",
                mensaje = "La solicitud fue legal, pero el servidor rehúsa responderla dado que el cliente no tiene los privilegios para realizarla. En contraste a una respuesta 401 No autorizado, autenticarse previamente no va a cambiar la respuesta."
            });
            lista.Add(new RespuestaHTTP()
            {
                codigo = "404",
                titulo = "Not Found",
                mensaje = "Recurso no encontrado. Se utiliza cuando el servidor web no encuentra la página o recurso solicitado"
            });
            lista.Add(new RespuestaHTTP()
            {
                codigo = "406",
                titulo = "Not acceptable",
                mensaje = "El servidor, despues de aplicar una negociación de contenido servidor-impulsado, no encuentra ningún contenido seguido por la criteria dada por el usuario."
            });
            lista.Add(new RespuestaHTTP()
            {
                codigo = "418",
                titulo = "I'm a teapot",
                mensaje = "'Soy una tetera'. Este código fue definido en 1998 como una inocentada, en el Protocolo de Transmisión de Hipertexto de Cafeteras (RFC-2324). No se espera que los servidores web implementen realmente este código de error, pero es posible encontrar sitios que devuelvan este código HTTP."
            });
            lista.Add(new RespuestaHTTP()
            {
                codigo = "500",
                titulo = "Internal Server Error",
                mensaje = "aplicaciones empotradas en servidores web, mismas que generan contenido dinámicamente, por ejemplo aplicaciones montadas en IIS o Tomcat, cuando se encuentran con situaciones de error ajenas a la naturaleza del servidor web."
            });
            lista.Add(new RespuestaHTTP()
            {
                codigo = "503",
                titulo = "Service Unavailable",
                mensaje = "El servidor no puede responder a la petición del navegador porque está congestionado o está realizando tareas de mantenimiento."
            });
            lista.Add(new RespuestaHTTP()
            {
                codigo = "001",
                titulo = "Error de autentificación 1.",
                mensaje = "Correo Incorrecto"
            });
            lista.Add(new RespuestaHTTP()
            {
                codigo = "002",
                titulo = "Error de autentificación 2.",
                mensaje = "Clave Incorrecta"
            });
            return lista;
        }
    }
}