using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class DocumentData
    {
        public List<Document> Documents
        {
            get
            {
                List<Document> list = new List<Document>
                {
                    new Document { Document_Number = 1, Title = "1 Notice!!", Writer = "Scott" },
                    new Document { Document_Number = 2, Title = "2 Notice!!", Writer = "Tiger" },
                    new Document { Document_Number = 3, Title = "3 Notice!!", Writer = "Tom" },
                    new Document { Document_Number = 4, Title = "4 Notice!!", Writer = "Jonson" },
                    new Document { Document_Number = 5, Title = "5 Notice!!", Writer = "Gerry" },
                };

                return list;
            }
        }
    }
}