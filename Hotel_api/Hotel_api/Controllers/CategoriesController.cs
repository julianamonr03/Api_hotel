using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Hotel_api.Models;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Hotel_api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]

    public class CategoriesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public CategoriesController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select id,Name,Price,Category_hotel,Client_calif from specifications
            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("HotelAppCon");

            MySqlDataReader myReader;

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Category cat)
        {
            string query = @"
                        insert into specifications (Name, Price, Category_hotel,
                        Client_calif) values (@Name, @Price, @Category_hotel,
                        @Client_calif)
            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("HotelAppCon");

            MySqlDataReader myReader;

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Name", cat.Name);
                    myCommand.Parameters.AddWithValue("@Category_hotel", cat.Category_hotel);
                    myCommand.Parameters.AddWithValue("@Price", cat.Price);
                    myCommand.Parameters.AddWithValue("@Client_calif", cat.Client_calif);

                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Added Successfully!");
        }

        [HttpPut]
        public JsonResult Put(Category cat)
        {
            string query = @"
                        update hotel.specifications set 
                        Name = @Name,
                        Category_hotel = @Category_hotel,
                        Price = @Price,
                        Client_calif = @Client_calif;
            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("HotelAppCon");

            MySqlDataReader myReader;

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id", cat.Id);
                    myCommand.Parameters.AddWithValue("@Name", cat.Name);
                    myCommand.Parameters.AddWithValue("@Category_hotel", cat.Category_hotel);
                    myCommand.Parameters.AddWithValue("@Price", cat.Price);
                    myCommand.Parameters.AddWithValue("@Client_calif", cat.Client_calif);


                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Updated Successfully!");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from hotel.specifications
                        where Id=@Id;
            ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("HotelAppCon");

            MySqlDataReader myReader;

            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();

                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Id", id);

                    myReader = myCommand.ExecuteReader();

                    table.Load(myReader);
                    myReader.Close();
                    mycon.Close();
                }
            }
            return new JsonResult("Deleted Successfully!");
        }

        [Route("SavePhoto")]
        [HttpPost]

        public JsonResult SavePhoto()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];

                string filename = postedFile.FileName;

                var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("test.png");
            }
        }
    }
}
