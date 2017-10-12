using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace estadisticasPROTUR.Controllers
{
    public class DerivacionesController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetCentrosDeSalud()
        {

            SqlConnection cx = null;
            string consulta = "";


            cx = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_ARES"].ConnectionString);
            consulta = "select id,Nombre from ProturEquivalenciasCaps order by Nombre asc";

            SqlDataAdapter da = new SqlDataAdapter(consulta, cx);

            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
            }
            catch (Exception err)
            {
                return Json(err.Message);
            }
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return Json(rows);
        }


        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetProturDerivado(int csId, string fd, string fh)
        {

            SqlConnection cx = null;
            string consulta = "";


            cx = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_ARES"].ConnectionString);
            consulta = "exec spGetProturDerivado @id @fd @fh";

            SqlDataAdapter da = new SqlDataAdapter(consulta, cx);
            da.SelectCommand.Parameters.AddWithValue("@id", csId);
            da.SelectCommand.Parameters.AddWithValue("@fd", fd);
            da.SelectCommand.Parameters.AddWithValue("@fh", fh);

            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
            }
            catch (Exception err)
            {
                return Json(err.Message);
            }
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return Json(rows);
        }


        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetProturProgramado(int csId, string fd, string fh)
        {

            SqlConnection cx = null;
            string consulta = "";


            cx = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_ARES"].ConnectionString);
            consulta = "exec spGetProturProgramado @id @fd @fh";

            SqlDataAdapter da = new SqlDataAdapter(consulta, cx);
            da.SelectCommand.Parameters.AddWithValue("@id", csId);
            da.SelectCommand.Parameters.AddWithValue("@fd", fd);
            da.SelectCommand.Parameters.AddWithValue("@fh", fh);

            DataTable dt = new DataTable();

            try
            {
                da.Fill(dt);
            }
            catch (Exception err)
            {
                return Json(err.Message);
            }
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return Json(rows);
        }
    }

}