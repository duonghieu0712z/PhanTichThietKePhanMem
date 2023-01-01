using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    internal class DriverFuncs
    {
        public List<Driver> Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.Drivers.AsQueryable();
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<Driver>();
            }
        }
        public Driver Select_ID(int id)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                return db.Drivers.FirstOrDefault(s => s.DriverID == id);
            }
        }
        public List<Driver> Select_IDs(List<string> IDs)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.Drivers.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.DriverID.ToString()));
                    return ls.ToList();
                }
                return new List<Driver>();
            }
        }
        public List<Driver> Select_By(string ColumnName, string Value)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From Driver Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.Drivers.SqlQuery(sql);
                if (ls != null && ls.Any()) return ls.ToList<Driver>();
                return new List<Driver>();
            }
        }
        public List<Driver> Select_By(string ColumnName, string Value, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From Driver Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.Drivers.SqlQuery(sql);
                if (ls != null && ls.Any())
                {
                    TotalRows = ls.Count();
                    return ls.OrderByDescending(s => s.DriverID).Skip(PageSize * PageIndex).Take(PageSize).ToList<Driver>();
                }
                return new List<Driver>();
            }
        }
        public int InsertUpdate(Driver obj)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                using (var db1 = new ROUTE_MANAGEMENTEntities())
                {
                    var find = db.Drivers.FirstOrDefault(s => s.DriverID == obj.DriverID);
                    if (find != null) db1.Entry(obj).State = EntityState.Modified;
                    else obj = db1.Drivers.Add(obj);
                    db1.SaveChanges();
                    return obj.DriverID;
                }
            }
        }
        public void Delete(int id)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var obj = db.Drivers.FirstOrDefault(s => s.DriverID == id);
                if (obj != null)
                {
                    db.Drivers.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Delete_IDs(List<string> IDs)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.Drivers.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.DriverID.ToString()));
                    foreach (var item in ls)
                        db.Drivers.Remove(item);
                    db.SaveChanges();
                }
            }
        }
        public List<Driver> Find_KeyWord(string Keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    var obj = db.Drivers.FirstOrDefault(s => s.DriverID.ToString().CompareTo(Keyword) == 0);
                    if (obj != null)
                    {
                        List<Driver> ls = new List<Driver>();
                        ls.Add(obj);
                        TotalRows = 1;
                        return ls;
                    }
                    var list = db.Drivers.AsQueryable();
                    list = list.Where(s => s.DriverID.ToString().Contains(Keyword)
                    || s.FullName.ToLower().Contains(Keyword)
                    || s.DayOfBirth.ToString().Contains(Keyword)
                    || s.HomeTown.ToString().Contains(Keyword)
                    || s.IDCard.ToString().Contains(Keyword)
                    || s.Sex.ToString().Contains(Keyword)
                    );
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.DriverID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                else
                {
                    var list = db.Drivers.AsQueryable();
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.DriverID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                return new List<Driver>();
            }
        }
        public void Import(List<Driver> list)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Drivers.AddRange(list);
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
