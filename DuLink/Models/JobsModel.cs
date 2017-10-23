using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;
using DuLink.Entities;

namespace DuLink.Models
{
    public class JobsModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<Jobs> jobsCollection;

        public JobsModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            jobsCollection = db.GetCollection<Jobs>("EmploymentJobs");
        }

        public List<Jobs> FindAll()
        {
            return jobsCollection.AsQueryable<Jobs>().ToList();
        }

        public Jobs FindJobs(string id)
        {
            var accountId = new ObjectId(id);
            return jobsCollection.AsQueryable<Jobs>().SingleOrDefault(a => a.Id == accountId);
        }

        public void CreateJobs(Jobs job)
        {
            jobsCollection.InsertOne(job);
        }

        public Jobs getLastAddedJob()
        {
            return jobsCollection.AsQueryable<Jobs>().ToList().Last();
        }

        //Fijense si pueden solucionar esto
        public void updateJob(String jobID, String endDate)
        {
            jobsCollection.UpdateOne(Builders<Jobs>.Filter.Eq("Id", jobID),
                Builders<Jobs>.Update.Set("JobEndDate", endDate));
        }

    }
}