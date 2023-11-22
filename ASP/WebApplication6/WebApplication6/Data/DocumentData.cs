using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication6.Models;

namespace WebApplication6.Data
{
    public class DocumentData
    {
        public List<Document> Documents = new List<Document>
        {
            new Document { Document_Number = 1, Title = "ab1", Writer = "abcWriter" },
            new Document { Document_Number = 2, Title = "ab2", Writer = "ab2Writer" },
            new Document { Document_Number = 3, Title = "ab3", Writer = "ab3Writer" }
        };
           
    }
}