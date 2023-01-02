using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentLayer.BaseObjectMethods
{
    public class IntroduceFunc
    {
        public List<Introduction> Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.Introductions.AsQueryable();
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<Introduction>();
            }
        }

        public int InsertUpdate(Introduction obj)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                using (var db1 = new ROUTE_MANAGEMENTEntities())
                {
                    var find = db.Introductions.FirstOrDefault(s => s.IntroductionID == obj.IntroductionID);
                    if (find != null) db1.Entry(obj).State = EntityState.Modified;
                    else obj = db1.Introductions.Add(obj);
                    db1.SaveChanges();
                    return obj.IntroductionID;
                }
            }
        }
    }
}
