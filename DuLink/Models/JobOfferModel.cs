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
    public class JobOfferModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<JobOffer> jobOfferCollection;

        public JobOfferModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            jobOfferCollection = db.GetCollection<JobOffer>("EmploymentOffer");
        }

        public List<JobOffer> FindAll()
        {
            return jobOfferCollection.AsQueryable<JobOffer>().ToList();
        }

        public JobOffer FindJobOffer(string id)
        {
            var accountId = new ObjectId(id);
            return jobOfferCollection.AsQueryable<JobOffer>().SingleOrDefault(a => a.Id == accountId);
        }

        public void CreateJobOffer(JobOffer jobOffer)
        {
            jobOfferCollection.InsertOne(jobOffer);
        }

        public List<JobOffer> FindAllByDescription(String keyWords)
        {
            List<JobOffer> listaResult = new List<JobOffer>();
            if (keyWords.Trim() != "")
            {
                List<JobOffer> lista = jobOfferCollection.AsQueryable<JobOffer>().ToList();
                String[] keys = keyWords.Replace(' ', ';').Split(';');
                foreach (JobOffer i in lista)
                {
                    foreach (String j in keys)
                    {
                        if (j != "")
                        {
                            if (i.Description.ToLower().Contains(j.ToLower()))
                            {
                                listaResult.Add(i);
                            }
                        }
                    }

                }
            }

            return listaResult;
        }
        public List<JobOffer> FindAllByCompanyName(String keyWords)
        {
            List<JobOffer> listaResult = new List<JobOffer>();
            if (keyWords.Trim() != "")
            {
                List<JobOffer> lista = jobOfferCollection.AsQueryable<JobOffer>().ToList();
                String[] keys = keyWords.Replace(' ', ';').Split(';');
                foreach (JobOffer i in lista)
                {
                    foreach (String j in keys)
                    {
                        if (j != "")
                        {
                            if (i.CompanyName.ToLower().Contains(j.ToLower()))
                            {
                                listaResult.Add(i);
                            }
                        }
                    }

                }
            }
            return listaResult;
        }


    }
}