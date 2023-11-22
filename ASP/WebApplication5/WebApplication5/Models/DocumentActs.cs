using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Data;
using WebApplication5.Data;

namespace WebApplication5.Models
{
    public class DocumentActs
    {
       public List<Document> GetDocuments()
        {
            //TODO : database access 
            //string qry = "SELECT * FROM documents";
            //db.Documents...
            DocumentData documentData = new DocumentData();

            return documentData.Documents;
        }
    }
}