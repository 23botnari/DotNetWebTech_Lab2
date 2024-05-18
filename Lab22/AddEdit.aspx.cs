using System;
using Lab22.DAL;
using System.Web.UI.WebControls;
using System.Runtime.ConstrainedExecution;
using Lab22.Models;

namespace Lab22
{
    public partial class AddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    int carId = Convert.ToInt32(Request.QueryString["ID"]);
                    CarDAL carDAL = new CarDAL();
                    Car car = carDAL.GetCarById(carId);
                    if (car != null)
                    {
                        txtNume.Text = car.Nume;
                        txtCuloare.Text = car.Culoare;
                        txtAnFabricare.Text = car.AnFabricare.ToString();
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CarDAL carDAL = new CarDAL();
            if (Request.QueryString["ID"] != null)
            {
                int carId = Convert.ToInt32(Request.QueryString["ID"]);
                string nume = txtNume.Text;
                string culoare = txtCuloare.Text;
                int anFabricare = Convert.ToInt32(txtAnFabricare.Text);
                carDAL.UpdateCar(carId, nume, culoare, anFabricare);
            }
            else
            {
                string nume = txtNume.Text;
                string culoare = txtCuloare.Text;
                int anFabricare = Convert.ToInt32(txtAnFabricare.Text);
                carDAL.AddCar(nume, culoare, anFabricare);
            }
            Response.Redirect("Cars.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cars.aspx");
        }
    }
}
