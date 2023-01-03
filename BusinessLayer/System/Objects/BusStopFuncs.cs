using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusStopFuncs
    {
        public ROUTE_MANAGEMENTEntities GetContext()
        {
            return new ROUTE_MANAGEMENTEntities();
        }
        #region BusStop
        public List<BusStop> BusStop_Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.BusStops.AsQueryable();
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<BusStop>();
            }
        }
        public BusStop BusStop_Select_ID(int id)
        {
            using (var db = GetContext())
            {
                return db.BusStops.FirstOrDefault(s => s.BusStopID == id);
            }
        }
        public List<BusStop> BusStop_Select_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.BusStops.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.BusStopID.ToString()));
                    return ls.ToList();
                }
                return new List<BusStop>();
            }
        }
        public List<BusStop> BusStop_Select_By(string ColumnName, string Value)
        {
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From BusStop Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.BusStops.SqlQuery(sql);
                if (ls != null && ls.Any()) return ls.ToList<BusStop>();
                return new List<BusStop>();
            }
        }
        public List<BusStop> BusStop_Select_By(string ColumnName, string Value, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From BusStop Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.BusStops.SqlQuery(sql);
                if (ls != null && ls.Any())
                {
                    TotalRows = ls.Count();
                    return ls.OrderByDescending(s => s.BusStopID).Skip(PageSize * PageIndex).Take(PageSize).ToList<BusStop>();
                }
                return new List<BusStop>();
            }
        }
        public int BusStop_InsertUpdate(BusStop obj)
        {
            using (var db = GetContext())
            {
                using (var db1 = GetContext())
                {
                    var find = db.BusStops.FirstOrDefault(s => s.BusStopID == obj.BusStopID);
                    if (find != null) db1.Entry(obj).State = EntityState.Modified;
                    else obj = db1.BusStops.Add(obj);
                    db1.SaveChanges();
                    return obj.BusStopID;
                }
            }
        }
        public void BusStop_Delete(int id)
        {
            using (var db = GetContext())
            {
                var obj = db.BusStops.FirstOrDefault(s => s.BusStopID == id);
                if (obj != null)
                {
                    db.BusStops.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void BusStop_Delete_IDs(List<string> IDs)
        {
            using (var db = GetContext())
            {
                var ls = db.BusStops.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.BusStopID.ToString()));
                    foreach (var item in ls)
                        db.BusStops.Remove(item);
                    db.SaveChanges();
                }
            }
        }
        public List<BusStop> BusStop_Find_KeyWord(string Keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = GetContext())
            {
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    var obj = db.BusStops.FirstOrDefault(s => s.BusStopID.ToString().CompareTo(Keyword) == 0);
                    if (obj != null)
                    {
                        List<BusStop> ls = new List<BusStop>();
                        ls.Add(obj);
                        TotalRows = 1;
                        return ls;
                    }
                    var list = db.BusStops.AsQueryable();
                    list = list.Where(s => s.BusStopID.ToString().Contains(Keyword)
                    || s.BusStopName.ToLower().Contains(Keyword)
                    );
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.BusStopID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                else
                {
                    var list = db.BusStops.AsQueryable();
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.BusStopID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                return new List<BusStop>();
            }
        }
        public void BusStop_Import(List<BusStop> list)
        {
            using (var db = GetContext())
            {
                using (DbContextTransaction transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.BusStops.AddRange(list);
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
        #endregion
    }
}
