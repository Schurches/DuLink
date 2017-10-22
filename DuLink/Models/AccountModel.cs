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

        public List<Account> FindAll() {
            return accountCollection.AsQueryable<Account>().ToList();
        }



        public List<Account> FindAllByCareer(String keyWords)
        {
            List<Account> listaResult = new List<Account>();
            if (keyWords.Trim()!="") {
                List<Account> lista = accountCollection.AsQueryable<Account>().ToList();
                String[] keys = keyWords.Replace(' ', ';').Split(';');
                foreach (Account i in lista){
                    foreach (String j in keys){
                        if (j != ""){
                            if (i.Career.Contains(keyWords))
                            {
                                listaResult.Add(i);
                            }
                        }
                    }

                }
            }
            return listaResult;
        }
        public List<Account> FindAllBySemester(String keyWords)
        {
            List<Account> listaResult = new List<Account>();
            if (keyWords.Trim() != "")
            {
                List<Account> lista = accountCollection.AsQueryable<Account>().ToList();
                String[] keys = keyWords.Replace(' ', ';').Split(';');
                foreach (Account i in lista)
                {
                    foreach (String j in keys)
                    {
                        if (j != "")
                        {
                            if (i.Semester.Contains(keyWords))
                            {
                                listaResult.Add(i);
                            }
                        }
                    }

                }
            }

            return listaResult;
        }
        public List<Account> FindAllByName(String keyWords)
        {
            List<Account> listaResult = new List<Account>();
            if (keyWords.Trim() != "")
            {
                List<Account> lista = accountCollection.AsQueryable<Account>().ToList();
                String[] keys = keyWords.Replace(' ', ';').Split(';');
                foreach (Account i in lista)
                {
                    foreach (String j in keys)
                    {
                        if (j != "")
                        {
                            if (i.Name.Contains(keyWords))
                            {
                                listaResult.Add(i);
                            }
                        }
                    }

                }
            }
            return listaResult;
        }
        public List<Account> FindAllByLastName(String keyWords)
        {
            List<Account> listaResult = new List<Account>();
            if (keyWords.Trim() != "")
            {
                List<Account> lista = accountCollection.AsQueryable<Account>().ToList();
                String[] keys = keyWords.Replace(' ', ';').Split(';');
                foreach (Account i in lista)
                {
                    foreach (String j in keys)
                    {
                        if (j != "")
                        {
                            if (i.LastName.Contains(keyWords))
                            {
                                listaResult.Add(i);
                            }
                        }
                    }

                }
            }
             return listaResult;
        }
        public List<Account> FindSuggestedFriends(string id)
        {
            List<Account> listaResult = new List<Account>();
            Account mainAccount = FindAccount(id);
            foreach (String idF in mainAccount.FriendsList) {
                Account userF = FindAccount(idF);
                foreach (String idFF in userF.FriendsList) {
                    if (ObjectId.Parse(idFF) != mainAccount.Id) {
                        Account userFF = FindAccount(idFF);
                        foreach (String idFFF in userFF.FriendsList) {
                            if (ObjectId.Parse(idFFF) != mainAccount.Id) {
                                foreach (String a in mainAccount.FriendsList) {
                                    if (ObjectId.Parse(a) != ObjectId.Parse(idFFF)) {
                                        listaResult.Add(FindAccount(idFFF));
                                    }  
                                }
                            }
                        }
                    }

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

   
    }
}