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
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult test()
        {

            SqlConnection cx = null;
            string consulta = "";


                cx = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_ARES"].ConnectionString);
                consulta = "select * from CentroDeSalud";

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
    }
}