using System;
using System.Data;
using System.Web.UI.WebControls;
using Lab22.DAL;

namespace Lab22
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        CarDAL carDAL = new CarDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            DataTable dt = carDAL.GetAllCar();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEdit.aspx");
        }

        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Obțineți valorile actualizate ale rândului
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            string nume = e.NewValues["nume"].ToString();
            string culoare = e.NewValues["culoare"].ToString();
            string anFabricare = e.NewValues["an_fabricare"].ToString();

            // Actualizează înregistrarea în baza de date folosind CarDAL sau un alt obiect de acces la date
            CarDAL carDAL = new CarDAL();
            carDAL.UpdateCar(Convert.ToInt32(id), nume, culoare, Convert.ToInt32(anFabricare));

            // Ieșiți din modul de editare și reîncărcați GridView-ul pentru a afișa actualizările
            GridView1.EditIndex = -1;
            BindGrid();
        }


        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            carDAL.DeleteCar(id);
            BindGrid();
        }
    }
}
