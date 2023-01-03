using BusinessLayer.DBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ResponsibleFuncs
    {
        public ROUTE_MANAGEMENTEntities GetContext()
        {
            return new ROUTE_MANAGEMENTEntities();
        }

        #region
        public List<ResponsibleUnit> Select_All()
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.ResponsibleUnits.AsQueryable();
                if (ls != null && ls.Any())
                    return ls.ToList();
                return new List<ResponsibleUnit>();
            }
        }

        public ResponsibleUnit Select_ID(int id)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                return db.ResponsibleUnits.FirstOrDefault(s => s.ResponsibleUnitID == id);
            }
        }

        public List<ResponsibleUnit> Select_IDs(List<string> IDs)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.ResponsibleUnits.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.ResponsibleUnitID.ToString()));
                    return ls.ToList();
                }
                return new List<ResponsibleUnit>();
            }
        }

        public List<ResponsibleUnit> Select_By(string ColumnName, string Value)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From ResponsibleUnit Where CONVERT(nvarchar, " + ColumnName + ") = '" + Value + "'";
                var ls = db.ResponsibleUnits.SqlQuery(sql);
                if (ls != null && ls.Any())
                    return ls.ToList<ResponsibleUnit>();
                return new List<ResponsibleUnit>();
            }
        }
        public List<ResponsibleUnit> Select_By(string ColumnName, string Value, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                ColumnName = ColumnName.ToLower();
                Value = Value.ToLower();
                string sql = "Select * From ResponsibleUnit Where CONVERT(nvarchar," + ColumnName + ") = '" + Value + "'";
                var ls = db.ResponsibleUnits.SqlQuery(sql);
                if (ls != null && ls.Any())
                {
                    TotalRows = ls.Count();
                    return ls.OrderByDescending(s => s.ResponsibleUnitID).Skip(PageSize * PageIndex).Take(PageSize).ToList<ResponsibleUnit>();
                }
                return new List<ResponsibleUnit>();
            }
        }
        public int InsertUpdate(ResponsibleUnit obj)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                using (var db1 = new ROUTE_MANAGEMENTEntities())
                {
                    var find = db.ResponsibleUnits.FirstOrDefault(s => s.ResponsibleUnitID == obj.ResponsibleUnitID);
                    if (find != null) db1.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                    else obj = db1.ResponsibleUnits.Add(obj);
                    db1.SaveChanges();
                    return obj.ResponsibleUnitID;
                }
            }
        }
        public void Delete(int id)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var obj = db.ResponsibleUnits.FirstOrDefault(s => s.ResponsibleUnitID == id);
                if (obj != null)
                {
                    db.ResponsibleUnits.Remove(obj);
                    db.SaveChanges();
                }
            }
        }
        public void Delete_IDs(List<string> IDs)
        {
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                var ls = db.ResponsibleUnits.AsQueryable();
                if (ls != null && ls.Any())
                {
                    ls = ls.Where(s => IDs.Contains(s.ResponsibleUnitID.ToString()));
                    foreach (var item in ls)
                        db.ResponsibleUnits.Remove(item);
                    db.SaveChanges();
                }
            }
        }

        public List<ResponsibleUnit> Find_KeyWord(string Keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            TotalRows = 0;
            using (var db = new ROUTE_MANAGEMENTEntities())
            {
                if (!string.IsNullOrWhiteSpace(Keyword))
                {
                    var obj = db.ResponsibleUnits.FirstOrDefault(s => s.ResponsibleUnitID.ToString().CompareTo(Keyword) == 0);
                    if (obj != null)
                    {
                        List<ResponsibleUnit> ls = new List<ResponsibleUnit>();
                        ls.Add(obj);
                        TotalRows = 1;
                        return ls;
                    }
                    var list = db.ResponsibleUnits.AsQueryable();
                    list = list.Where(s => s.ResponsibleUnitID.ToString().Contains(Keyword)
                    || s.ReponsibleUnitName.ToLower().Contains(Keyword)
                    );
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.ResponsibleUnitID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                else
                {
                    var list = db.ResponsibleUnits.AsQueryable();
                    if (list != null && list.Any())
                    {
                        TotalRows = list.Count();
                        return list.OrderByDescending(s => s.ResponsibleUnitID).Skip(PageSize * PageIndex).Take(PageSize).ToList();
                    }
                }
                return new List<ResponsibleUnit>();
            }
        }
        #endregion
    }
}
