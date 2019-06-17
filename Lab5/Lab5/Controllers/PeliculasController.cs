using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Server;

namespace Lab5.Controllers
{
    public class PeliculasController : Controller
    {
        string connection = "Data Source= database-1.c0pmfzscntnx.us-east-1.rds.amazonaws.com,1433 ;Initial Catalog= Lab_Virtualizacion ;User ID= admin; Password= iRdCsjCWDLTnxs0OdLb4;";
        // GET: Peliculas
        public ActionResult Index()
        {
            List<Models.PeliculaModel> PeliculasLista = new List<Models.PeliculaModel>();

            SqlConnection sqlconnection = new SqlConnection(connection);

            string query = "Select * from Peliculas";

            sqlconnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Models.PeliculaModel pelicula = new Models.PeliculaModel();
                pelicula.ID = sqlDataReader.GetInt32(0);
                pelicula.Nombre = sqlDataReader.GetString(1);
                pelicula.Duracion = sqlDataReader.GetString(2);
                pelicula.Clasificacion = sqlDataReader.GetString(3);
                pelicula.Categoria = sqlDataReader.GetString(4);
                PeliculasLista.Add(pelicula);
            }
            sqlconnection.Close();
            IEnumerable<Models.PeliculaModel> peliculaModels = PeliculasLista;
            return View(peliculaModels);
        }

        // GET: Peliculas/Details/5
        public ActionResult Details(int id)
        {
            SqlConnection sqlconnection = new SqlConnection(connection);

            string query = "Select * from Peliculas where ID = '" + id + "';";

            sqlconnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            Models.PeliculaModel pelicula = new Models.PeliculaModel();
            while (sqlDataReader.Read())
            {

                pelicula.ID = sqlDataReader.GetInt32(0);
                pelicula.Nombre = sqlDataReader.GetString(1);
                pelicula.Duracion = sqlDataReader.GetString(2);
                pelicula.Clasificacion = sqlDataReader.GetString(3);
                pelicula.Categoria = sqlDataReader.GetString(4);

            }
            sqlconnection.Close();
            return View(pelicula);
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Peliculas/Create
        [HttpPost]
        public ActionResult Create(Models.PeliculaModel collection)
        {
            try
            {
                SqlConnection sqlconnection = new SqlConnection(connection);

                string query = "INSERT INTO [dbo].[PELICULAS] ([Nombre],[Duracion],[Tipo],[Categoria]) VALUES ('" + collection.Nombre + "','" + collection.Duracion + "','" + collection.Clasificacion + "','" + collection.Categoria + "');";
                sqlconnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                sqlCommand.ExecuteNonQuery();
                sqlconnection.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Peliculas/Edit/5
        public ActionResult Edit(int id)
        {
            SqlConnection sqlconnection = new SqlConnection(connection);

            string query = "Select * from Peliculas where ID = '" + id + "';";

            sqlconnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            Models.PeliculaModel pelicula = new Models.PeliculaModel();
            while (sqlDataReader.Read())
            {

                pelicula.ID = sqlDataReader.GetInt32(0);
                pelicula.Nombre = sqlDataReader.GetString(1);
                pelicula.Duracion = sqlDataReader.GetString(2);
                pelicula.Clasificacion = sqlDataReader.GetString(3);
                pelicula.Categoria = sqlDataReader.GetString(4);

            }
            sqlconnection.Close();
            return View(pelicula);
        }

        // POST: Peliculas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.PeliculaModel collection)
        {
            try
            {
                SqlConnection sqlconnection = new SqlConnection(connection);

                string query = "UPDATE [dbo].[PELICULAS]SET [Nombre] = '" + collection.Nombre + "',[Duracion] = '" + collection.Duracion + "',[Tipo] = '" + collection.Clasificacion + "',[Categoria] = '" + collection.Categoria + "' WHERE [ID] = '" + collection.ID + "';";
                sqlconnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                sqlCommand.ExecuteNonQuery();
                sqlconnection.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Peliculas/Delete/5
        public ActionResult Delete(int id)
        {
            SqlConnection sqlconnection = new SqlConnection(connection);

            string query = "Select * from Peliculas where ID = '" + id + "';";

            sqlconnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            Models.PeliculaModel pelicula = new Models.PeliculaModel();
            while (sqlDataReader.Read())
            {

                pelicula.ID = sqlDataReader.GetInt32(0);
                pelicula.Nombre = sqlDataReader.GetString(1);
                pelicula.Duracion = sqlDataReader.GetString(2);
                pelicula.Clasificacion = sqlDataReader.GetString(3);
                pelicula.Categoria = sqlDataReader.GetString(4);

            }
            sqlconnection.Close();
            return View(pelicula);
        }

        // POST: Peliculas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                SqlConnection sqlconnection = new SqlConnection(connection);

                string query = "DELETE FROM [dbo].[PELICULAS] WHERE [ID]= '" + id + "';";

                sqlconnection.Open();

                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);

                sqlCommand.ExecuteNonQuery();
                Models.PeliculaModel pelicula = new Models.PeliculaModel();
                sqlconnection.Close();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}