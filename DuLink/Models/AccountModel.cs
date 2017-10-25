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
                            if (i.Career.ToLower().Contains(j.ToLower()))
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
                            if (i.Semester.ToLower().Contains(j.ToLower()))
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
                            if (i.Name.ToLower().Contains(j.ToLower()))
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
                            if (i.LastName.ToLower().Contains(j.ToLower()))
                            {
                                listaResult.Add(i);
                            }
                        }
                    }

                }
            }
            return listaResult;
        }
        public List<Account> FindSuggestedFriends(Account mainAccount)
        {
            List<Account> listaResult = new List<Account>();
            foreach (String idF in mainAccount.FriendsList)
            {
                Account userF = FindAccount(idF);
                foreach (String idFF in userF.FriendsList)
                {
                    if (ObjectId.Parse(idFF) != mainAccount.Id)
                    {
                        Account userFF = FindAccount(idFF);
                        foreach (String idFFF in userFF.FriendsList)
                        {
                            if (ObjectId.Parse(idFFF) != mainAccount.Id)
                            {
                                bool Add = true;
                                foreach (String a in mainAccount.FriendsList)
                                {
                                    if(a.Equals(idFFF)){
                                        Add = false;
                                    }
                                }
                                Account newSug = FindAccount(idFFF);
                                foreach (Account a in listaResult)
                                {
                                    if (a.Id.Equals(newSug.Id))
                                    {
                                        Add = false;
                                    }
                                }
                                
                                if (Add) {
                                    listaResult.Add(newSug);
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

        public Account FindAccountByName(String username)
        {
            return accountCollection.AsQueryable<Account>().SingleOrDefault(a => a.UserName == username);
        }

        public void CreateAccount(Account account)
        {
            accountCollection.InsertOne(account);
        }

        public void addJobToUser(String jobID, Account user, Jobs lastJob)
        {
            if (user.JobsList.Count != 0)
            {
                JobsModel jobModel = new JobsModel();
                if (lastJob.EndDate == null)
                {
                    lastJob.EndDate = jobModel.FindAll().Last().StartDate;
                    jobModel.updateJob(lastJob.Id.ToString(), lastJob.EndDate.ToString());
                }
            }
            user.JobsList.Add(jobID);
            accountCollection.UpdateOne(Builders<Account>.Filter.Eq("Id", user.Id),
                Builders<Account>.Update.Set("EmployeeJobs", user.JobsList));
        }

        public void addFriend(String theFriend, Account currentUser)
        {
            currentUser.FriendsList.Add(theFriend);
            accountCollection.UpdateOne(Builders<Account>.Filter.Eq("Id", currentUser.Id),
                Builders<Account>.Update.Set("EmployeeFriends", currentUser.FriendsList));
        }


    }
}