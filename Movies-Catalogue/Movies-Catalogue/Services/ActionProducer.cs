﻿using Movies_Catalogue.Models;
using System;
using System.Collections.Generic;
using Movies_Catalogue.Validators;
using System.Data.SqlClient;
using System.ComponentModel.Design;

namespace Movies_Catalogue.Services
{
    public class ActionProducer
    {
        AccessDB AccessDB = new AccessDB();
        ValidateProducer ValidateProducer = new ValidateProducer();
        public void AddNewProducer(Producer NewProducer)
        {
            ValidateProducer.Validate(NewProducer);

            string Insert = "insert into Producer (Name, EstablishedDate, Place, NumberEmployees, Website) values ('" + NewProducer.Name + "','" + NewProducer.EstablishedDate.ToString("yyyy-MM-dd") + "','" + NewProducer.Place + "'," + NewProducer.NumberEmployees + ",'" + NewProducer.Website + "')";

            AccessDB.AccessNonQuery(Insert);
        }

        public List<Producer> ShowProducers()
        {
            List<Producer> ListProducer = new List<Producer>();

            string Select = "select * from Producer";

            SqlDataReader Reader = AccessDB.AccessReader(Select);

            while (Reader.Read())
            {
                Producer Producer = new Producer();

                Producer.Id = Convert.ToInt32(Reader["Id"]);
                Producer.Name = Convert.ToString(Reader["Name"]);
                Producer.EstablishedDate = Convert.ToDateTime(Reader["EstablishedDate"]);
                Producer.Place = Convert.ToString(Reader["Place"]);
                Producer.NumberEmployees = Convert.ToInt32(Reader["NumberEmployees"]);
                Producer.Website = Convert.ToString(Reader["Website"]);

                ListProducer.Add(Producer);
            }
            return ListProducer;
        }

        public void UpdateProducer(Producer Producer)
        {
            string Update = "Update Producer set Name='" + Producer.Name + "', EstablishedDate='" + Producer.EstablishedDate.ToString("yyyy-MM-dd") + "', Place='" + Producer.Place + "', NumberEmployees=" + Producer.NumberEmployees + ", Website='" + Producer.Website + "' where Id=" + Producer.Id;

            AccessDB.AccessNonQuery(Update);
        }

        public bool CheckRelationalTable(int Id)
        {
            string Select = "select from RelationalMovieProducer where Id=" + Id;

            SqlDataReader Reader = AccessDB.AccessReader(Select);

            bool Delete = true;

            while (Reader.Read())
            {
                int IdProducerDB = Convert.ToInt32(Reader["ProducerId"]);
                if (Id == IdProducerDB)
                {
                    int MovieId = Convert.ToInt32(Reader["MovieId"]);
                    throw new Exception("The Producer Id = " + IdProducerDB + " is related with the Movie Id= " + MovieId + ". Before you continue this delete, you need to change the ProducerId in the Table RelationalMovieProducer about this Movie Id.");

                    Delete = false;
                }
            }

            return Delete;
        }
        public void DeleteProducer(int Id)
        {
            bool Delete = CheckRelationalTable(Id);
            
            if(Delete == true)
            {
                string DeleteR = "delete from RelationalMovieProducer where Id=" + Id;

                AccessDB.AccessNonQuery(DeleteR);

                string DeleteP = "delete from Producer where Id= " + Id;

                AccessDB.AccessNonQuery(DeleteP);
            }
        }
    }
}
