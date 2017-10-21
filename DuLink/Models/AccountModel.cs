using System;
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

        public List<Account> findAll() {
            return accountCollection.AsQueryable<Account>().ToList();
        }

        public Account findAccount(string id)
        {
            var accountId = new ObjectId(id);
            return accountCollection.AsQueryable<Account>().SingleOrDefault(a => a.Id == accountId);
        }

        public void createAccount(Account account)
        {
            accountCollection.InsertOne(account);
        }

   
    }
}