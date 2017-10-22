﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DuLink.Entities;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;

namespace DuLink.Models
{
    public class AccountModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<Account> accountCollection;

        public AccountModel() {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            accountCollection = db.GetCollection<Account>("Employee");
        }

        public List<Account> FindAll() {
            return accountCollection.AsQueryable<Account>().ToList();
        }

        public List<Account> FindAllByCareer(String CareerKeyWords)
        {
            List<Account> lista = accountCollection.AsQueryable<Account>().ToList();
            List<Account> listaResult = new List<Account>();
            foreach (Account i in lista)
            {
                if (i.Career.Contains(CareerKeyWords)) {
                    listaResult.Add(i);
                }
            }
            return listaResult;
        }
        public List<Account> FindAllBySemester(String semesterKeyWords)
        {
            List<Account> lista = accountCollection.AsQueryable<Account>().ToList();
            List<Account> listaResult = new List<Account>();
            foreach (Account i in lista)
            {
                if (i.Semester.Contains(semesterKeyWords))
                {
                    listaResult.Add(i);
                }
            }
            return listaResult;
        }
        public List<Account> FindAllByName(String nameKeyWords)
        {
            List<Account> lista = accountCollection.AsQueryable<Account>().ToList();
            List<Account> listaResult = new List<Account>();
            foreach (Account i in lista)
            {
                if (i.Name.Contains(nameKeyWords))
                {
                    listaResult.Add(i);
                }
            }
            return listaResult;
        }
        public List<Account> FindAllByLastName(String lastNameKeyWords)
        {
            List<Account> lista = accountCollection.AsQueryable<Account>().ToList();
            List<Account> listaResult = new List<Account>();
            foreach (Account i in lista)
            {
                if (i.LastName.Contains(lastNameKeyWords))
                {
                    listaResult.Add(i);
                }
            }
            return listaResult;
        }

        public Account FindAccount(string id)
        {
            var accountId = new ObjectId(id);
            return accountCollection.AsQueryable<Account>().SingleOrDefault(a => a.Id == accountId);
        }

        public void CreateAccount(Account account)
        {
            accountCollection.InsertOne(account);
        }

        public void addJobToUser(Account account)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Name", account.Name);
            //var update = Builders<BsonDocument>.Update.Set("JobList", "American (New)").CurrentDate("lastModified");
            //accountCollection.UpdateOne(filter,account);
            //var result = await collection.UpdateOneAsync(filter, update);
            
        }

   
    }
}