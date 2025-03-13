using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//-------------------------------
using apiRESTChekBd.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using apiRESTCheckBd.Models;
//------------------------------
namespace apiRESTChekBd.Controllers
{
    public class CheckBdController : ApiController
    {
        // creacion y configuracion del endpoint
        [HttpPost]
        [Route("tads/checkbd")]
        public clsApiStatus CheckBd()
        {
            //Definicion  de objetos de salida
            clsApiStatus objRespuesta = new clsApiStatus();
            JObject jsonResp = new JObject();
            //----------------------------
            // crecion del objeto clsCheckBd
            clsCheckBd objCheckBd = new clsCheckBd();
            //Ejecucion del checkBD
            objCheckBd.checkBd();
            //configuraCION DEL OBJETO DE SALIDA
            objRespuesta.ban = objCheckBd.ban;
            if (objRespuesta.ban == 1)
            {
                objRespuesta.statusExec = true;
            }
            else
            {
                objRespuesta.statusExec = false;
            }
            objRespuesta.msg = objCheckBd.statusMsg;
            jsonResp.Add("msgData", objCheckBd.statusMsg);
            objRespuesta.datos = jsonResp;
            // objeto de salida
            return objRespuesta;





        }
    }
}