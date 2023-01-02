using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DBAccess;

namespace BusinessLayer
{
    public class handlingViolations
    {

        public ROUTE_MANAGEMENTEntities GetContext()
        {
            return new ROUTE_MANAGEMENTEntities();
        }

        public List<HandlingViolation> HandlingViolation_Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.HandlingViolations.AsQueryable();
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<HandlingViolation>();
            }
        }
        //public List<HandlingViolation> HandlingViolation_Select_Title()
        //{
        //    using (var db = new ROUTE_MANAGEMENTEntities())
        //    {

        //        string sql = "Select * From HandlingViolations ";
        //        var ls = db.HandlingViolations.SqlQuery(sql);
        //        if (ls != null && ls.Any()) return ls.ToList<HandlingViolation>();
        //        return new List<HandlingViolation>();
        //    }
        //}
        public HandlingViolation HandlingViolation_Select_ID(int id)
        {
            using (var db = GetContext())
            {
                return db.HandlingViolations.FirstOrDefault(s => s.ID == id);
            }
        }

        public List<HandlingViolation> HandlingViolation_Select_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.HandlingViolations.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.ID.ToString()));
                    return ls.ToList();
                }
                return new List<HandlingViolation>();
            }
        }

        public List<HandlingViolation> HandlingViolation_Select_By(string ColumnName, string Value)
        {
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From HandlingViolations Where CONVERT(nvarchar," + ColumnName + ") = N'" + Value + "'";
                var ls = db.HandlingViolations.SqlQuery(sql);
                if (ls != null && ls.Any()) return ls.ToList<HandlingViolation>();
                return new List<HandlingViolation>();
            }
        }

        public List<HandlingViolation> HandlingViolation_Select_By(string ColumnName, string Value, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From HandlingViolations Where CONVERT(nvarchar," + ColumnName + ") = N'" + Value + "'";
                var ls = db.HandlingViolations.SqlQuery(sql);
                if (ls != null && ls.Any())
                {
                    TotalRows = ls.Count();
                    return ls.OrderByDescending(s => s.ID).Skip(PageSize * PageIndex).Take(PageSize).ToList<HandlingViolation>();
                }
                return new List<HandlingViolation>();
            }
        }

        public int HandlingViolations_InsertUpdate(HandlingViolation obj)
        {
            using (var db = GetContext())
            {
                using (var db1 = GetContext())
                {
                    var find = db.HandlingViolations.FirstOrDefault(s => s.ID == obj.ID);
                    if (find != null) db1.Entry(obj).State = EntityState.Modified;
                    else obj = db1.HandlingViolations.Add(obj);
                    db1.SaveChanges();
                    return obj.ID;
                }
            }
        }
        public void HandlingViotions_Delete(int id)
        {
            using (var db = GetContext())
            {
                var obj = db.HandlingViolations.FirstOrDefault(s => s.ID == id);
                if (obj != null)
                {
                    db.HandlingViolations.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void HandlingViotions_Delete_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.HandlingViolations.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.ID.ToString()));
                    foreach (var item in ls)
                        db.HandlingViolations.Remove(item);
                    db.SaveChanges();
                }
            }
        }

        public List<HandlingViolation> HandlingViolation_Find_KeyWord(string Keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    var obj = db.HandlingViolations.FirstOrDefault(s => s.ID.ToString().CompareTo(Keyword) == 0);
                    if (obj != null)
                    {
                        List<HandlingViolation> ls = new List<HandlingViolation>();
                        ls.Add(obj);
                        TotalRows = 1;
                        return ls;
                    }
                    var list = db.HandlingViolations.AsQueryable();
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
                    var list = db.HandlingViolations.AsQueryable();
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.ID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                return new List<HandlingViolation>();
            }
        }
        public void HandlingViolation_Import(List<HandlingViolation> list)
        {
            using (var db = GetContext())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.HandlingViolations.AddRange(list);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
