using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class InformationFunctions
    {
        public ROUTE_MANAGEMENTEntities GetContext()
        {
            return new ROUTE_MANAGEMENTEntities();
        }
        public List<Information> Information_Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.Information.AsQueryable();
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<Information>();
            }
        }

        public int Info_InsertUpdate(Information obj)
        {
            using (var db = GetContext())
            {
                using (var db1 = GetContext())
                {
                    var find = db.Information.FirstOrDefault(s => s.ID == obj.ID);
                    if (find != null) db1.Entry(obj).State = EntityState.Modified;
                    else obj = db1.Information.Add(obj);
                    db1.SaveChanges();
                    return obj.ID;
                }
            }
        }
        public void Info_Delete(int id)
        {
            using (var db = GetContext())
            {
                var obj = db.Information.FirstOrDefault(s => s.ID == id);
                if (obj != null)
                {
                    db.Information.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public Information Info_Select_ID(int id)
        {
            using (var db = GetContext())
            {
                return db.Information.FirstOrDefault(s => s.ID == id);
            }
        }
        public List<Information> Info_Select_By(string ColumnName, string Value)
        {
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                
                string sql = "Select * From Information Where CONVERT(nvarchar," + ColumnName + ") = N'" + Value + "'";
                var ls = db.Information.SqlQuery(sql);
                if (ls != null && ls.Any()) return ls.ToList<Information>();
                return new List<Information>();
            }
        }
        public List<Information> Info_Delete_all()
        {
            using (var db = GetContext())
            {
                string sql = "DELETE FROM Information";
                var ls = db.Information.SqlQuery(sql);
                if (ls != null && ls.Any()) return ls.ToList<Information>();
                return new List<Information>();
            }
        }
        public List<Information> Info_Find_KeyWord(string Keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    var obj = db.Information.FirstOrDefault(s => s.ID.ToString().CompareTo(Keyword) == 0);
                    if (obj != null)
                    {
                        List<Information> ls = new List<Information>();
                        ls.Add(obj);
                        TotalRows = 1;
                        return ls;
                    }
                    var list = db.Information.AsQueryable();
                    list = list.Where(s => s.ID.ToString().Contains(Keyword)
                    || s.Title.ToLower().Contains(Keyword)
                    );
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.ID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                else
                {
                    var list = db.Information.AsQueryable();
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.ID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                return new List<Information>();
            }
        }
    }
}
