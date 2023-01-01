using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DriverOfBusFuncs
    {
        public List<Driver_Bus> Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.Driver_Bus.AsQueryable();
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<Driver_Bus>();
            }
        }
        public Driver_Bus Select_ID(int id)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                return db.Driver_Bus.FirstOrDefault(s => s.DriverID == id);
            }
        }
        public List<Driver_Bus> Select_IDs(List<string> IDs)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.Driver_Bus.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.ID.ToString()));
                    return ls.ToList();
                }
                return new List<Driver_Bus>();
            }
        }
        public List<Driver_Bus> Select_By(string ColumnName, string Value)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From Driver_Bus Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.Driver_Bus.SqlQuery(sql);
                if (ls != null && ls.Any()) return ls.ToList<Driver_Bus>();
                return new List<Driver_Bus>();
            }
        }
        public List<Driver_Bus> Select_By(string ColumnName, string Value, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From Driver_Bus Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.Driver_Bus.SqlQuery(sql);
                if (ls != null && ls.Any())
                {
                    TotalRows = ls.Count();
                    return ls.OrderByDescending(s => s.ID).Skip(PageSize * PageIndex).Take(PageSize).ToList<Driver_Bus>();
                }
                return new List<Driver_Bus>();
            }
        }
        public int InsertUpdate(Driver_Bus obj)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                using (var db1 = new ROUTE_MANAGEMENTEntities())
                {
                    var find = db.Driver_Bus.FirstOrDefault(s => s.ID == obj.ID);
                    if (find != null) db1.Entry(obj).State = EntityState.Modified;
                    else obj = db1.Driver_Bus.Add(obj);
                    db1.SaveChanges();
                    return obj.ID;
                }
            }
        }
        public void Delete(int id)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var obj = db.Driver_Bus.FirstOrDefault(s => s.ID == id);
                if (obj != null)
                {
                    db.Driver_Bus.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Delete_IDs(List<string> IDs)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.Driver_Bus.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.ID.ToString()));
                    foreach (var item in ls)
                        db.Driver_Bus.Remove(item);
                    db.SaveChanges();
                }
            }
        }
        public List<Driver_Bus> Find_KeyWord(string Keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    var obj = db.Driver_Bus.FirstOrDefault(s => s.ID.ToString().CompareTo(Keyword) == 0);
                    if (obj != null)
                    {
                        List<Driver_Bus> ls = new List<Driver_Bus>();
                        ls.Add(obj);
                        TotalRows = 1;
                        return ls;
                    }
                    var list = db.Driver_Bus.AsQueryable();
                    list = list.Where(s => s.ID.ToString().Contains(Keyword)
                    || s.DriverID.ToString().Contains(Keyword)
                    || s.BusID.ToString().Contains(Keyword)
                    || s.DepartureDay.ToString().Contains(Keyword)

                    );
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.ID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                else
                {
                    var list = db.Driver_Bus.AsQueryable();
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.ID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                return new List<Driver_Bus>();
            }
        }
        public void Import(List<Driver_Bus> list)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Driver_Bus.AddRange(list);
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
