using BusinessLayer.DBAccess;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Models;

namespace BusinessLayer.Functions
{
    public class HRFunctions : BaseFunctions
    {
        private static HRFunctions instance = null;
        public static HRFunctions Instance
        {
            get
            {
                if (instance == null)
                    instance = new HRFunctions();
                return instance;
            }
        }
        #region Route
        public List<ResponsibleUnit> Select_All_ResponsibleUnit()
        {
            return ResponsibleExt.Instance.Select_All();
        }
        public int InsertNUpdateResponsible(ResponsibleUnit resp)
        {
            return ResponsibleExt.Instance.InsertUpdate(resp);
        }
        public ResponsibleUnit Select_Responsible_Unit_ID(int id)
        {
            return ResponsibleExt.Instance.Select_ID(id);
        }
        public List<ResponsibleUnit> ResponsibleUnit_Pagination(string keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            return ResponsibleExt.Instance.Find_KeyWord(keyword, PageSize, PageIndex, out TotalRows);
        }
        public void DeleteResponsibleUnit(List<String> IDs)
        {
            ResponsibleExt.Instance.Delete_IDs(IDs);
        }
        public List<Route> SelectAllRoute()
        {
            return RouteExt.Instance.Route_Select_All();
        }
        public List<Stop_Route> SelectAllStopRoute()
        {
            return StopRouteExt.Instance.Stop_Route_Select_All();
        }
        public List<BusRoute> SelectAllBusRoute()
        {
            return BusRouteExt.Instance.BusRoute_Select_All();
        }
        public List<BusStop> SelectAllBusStop()
        {
            return BusStopExt.Instance.BusStop_Select_All();
        }
        public void DeleteBusRouteByIDs(List<String> IDs)
        {
            BusRouteExt.Instance.BusRoute_Delete_IDs(IDs);

        }
        public BusRoute Select_Bus_Route_ID(int id)
        {
            return BusRouteExt.Instance.BusRoute_Select_ID(id);
        }
        public List<BusRoute> Bus_Route_Pagination(string keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            return BusRouteExt.Instance.BusRoute_Find_KeyWord(keyword, PageSize, PageIndex, out TotalRows);
        }
        public List<BusRoute> FindBusRoute(string keyword)
        {
            return BusRouteExt.Instance.BusRoute_Find(keyword);
        }
        public int InsertNUpdateBusRoute(BusRoute busRoute)
        {
            return BusRouteExt.Instance.BusRoute_InsertUpdate(busRoute);
        }
        public int InsertNUpdateRoute(Route route)
        {
            return RouteExt.Instance.Route_InsertUpdate(route);
        }
        public int InsertNUpdateStopRoute(Stop_Route stop_Route)
        {
            return StopRouteExt.Instance.Stop_Route_InsertUpdate(stop_Route);
        }
        public int InsertNUpdateBusStop(BusStop  busStop)
        {
            return BusStopExt.Instance.BusStop_InsertUpdate(busStop);
        }

        public void DeleteRoute(int id)
        {
            RouteExt.Instance.Route_Delete(id);
        }
        public void DeleteStopRoute(int id)
        {
            StopRouteExt.Instance.Stop_Route_Delete(id);
        }

        public Route Route_Select_ID(int id)
        {
            return RouteExt.Instance.Route_Select_ID(id);
        }

        public Stop_Route Stop_Route_Select_ID(int id)
        {
            return StopRouteExt.Instance.Stop_Route_Select_ID(id);
        }

        public BusStop BusStop_Select_ID(int id)
        {
            return BusStopExt.Instance.BusStop_Select_ID(id);
        }

        public List<RouteInfo> GetAllRouteInfo()
        {
            return RouteExt.Instance.GetAllRouteInfo();
        }
        public List<Stop_RouteInfo> GetAllStopRouteInfo()
        {
            return StopRouteExt.Instance.GetAllStopRouteInfo();
        }

        public List<Route> SearchRouteByStartAndEndPos(int idStart, int idEnd)
        {
            return RouteExt.Instance.SearchRouteByStartAndEndPos(idStart, idEnd);
        }

        public List<Route> SearchRouteByBusRouteId(int id)
        {
            return RouteExt.Instance.SearchRouteByBusRouteId(id);
        }

        public List<BusStop> GetBusStopByRoute(int routeId)
        {
            return StopRouteExt.Instance.GetBusStopByRoute(routeId);
        }
        #endregion

        #region BusStop
        public List<BusStop> SearchByName(string nameValue)
        {

            return BusStopExt.Instance.BusStop_Select_By("Name", nameValue);
        }

        public int InsertBusStop(BusStop bs)
        {
            return BusStopExt.Instance.BusStop_InsertUpdate(bs);
        }

        public BusStop FindBusStopByID(int id)
        {
            return BusStopExt.Instance.BusStop_Select_ID(id);
        }
        public void DeleteBusStopByID(int id)
        {
            BusStopExt.Instance.BusStop_Delete(id);
        }
        public void DeleteBusStopByIDs(List<String> IDs)
        {
            BusStopExt.Instance.BusStop_Delete_IDs(IDs);

        }
        public List<BusStop> Bus_Stop_Pagination(int PageSize, int PageIndex, out int TotalRows)
        {
            return BusStopExt.Instance.BusStop_Find_KeyWord("", PageSize, PageIndex, out TotalRows);
        }

        public static double getDistanceFromLatLonInKm(double lat1, double lon1, double lat2, double lon2)
        {
            double R = 6371; // Radius of the earth in km
            double dLat = deg2rad(lat2 - lat1);  // deg2rad below
            double dLon = deg2rad(lon2 - lon1);
            double a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
                ;
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = R * c; // Distance in km
            return d;
        }


        public static double deg2rad(double deg)
        {
            return deg * (Math.PI / 180);
        }

        #endregion

        #region Bus, Bus type manager
        public BusType GetBusTypeByID(int id)
        {
            return BusTypeExt.Instance.BusType_Select_BusTypeID(id);
        }

        public BusRoute GetBusRouteByID(int id)
        {
            return BusExt.Instance.BusRoute_Select_ID(id);
        }

        public List<Bus> SelectAllBus()
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return BusExt.Instance.Bus_Select_All();
        }

        public List<BusRoute> SelectAllBusRoutes()
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return BusExt.Instance.BusRoute_Select_All();
        }

        public List<Bus> SearchBusByCriteria(string multiColumn, int pageSize, int pageIndex, out int total)
        {
            return BusExt.Instance.Bus_Find_By_Criteria(multiColumn, pageSize, pageIndex, out total);
        }

        public List<BusType> SearchBusTypeByCrieria(string multiColumn, int pageSize, int pageIndex, out int total)
        {
            return BusTypeExt.Instance.Bus_Type_Find_By_Criteria(multiColumn, pageIndex, pageSize, out total);
        }

        public List<BusType> SelectAllBusType()
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return BusTypeExt.Instance.BusType_Select_All();
        }

        public int InsertUpdateBusType(int id, string name, string carMaker)
        {
            BusType busType;
            busType = new BusType
            {
                BusTypeID = id,
                Name = name,
                CarMaker = carMaker
            };
            return BusTypeExt.Instance.BusType_InsertUpdate(busType);
        }


        public int AddBus(Bus bus)
        {
            return BusExt.Instance.Bus_InsertUpdate(bus);
        }

        public Bus FindBusByID(int id)
        {
            return BusExt.Instance.Bus_Select_ID(id);
        }

        public BusType FindBusTypeByID(int id)
        {
            return BusTypeExt.Instance.BusType_Select_BusTypeID(id);
        }

        public BusType SelectBusTypeByID(int id)
        {
            return BusTypeExt.Instance.BusType_Select_BusTypeID(id);
        }

        public void DeleteBusType(int id)
        {
            BusTypeExt.Instance.BusType_Delete(id);
        }

        public void DeleteBusTypeIDs(List<string> ids)
        {
            BusTypeExt.Instance.BusType_Delete_BusTypeIDs(ids);
        }

        public void DeleteBusBusTypeIDs(List<string> ids)
        {
            BusExt.Instance.Bus_Delete_BusTypeIDs(ids);
        }

        public void DeleteBusByID(int id)
        {
            BusExt.Instance.Bus_Delete(id);
        }

        public List<Bus> Bus_Pagination(int PageSize, int PageIndex, out int TotalRows)
        {
            return BusExt.Instance.Bus_Pagination(PageSize, PageIndex, out TotalRows);
        }

        public List<BusType> Bus_Type_Pagination(int PageSize, int PageIndex, out int TotalRows)
        {
            return BusTypeExt.Instance.BusType_Pagination(PageSize, PageIndex, out TotalRows);
        }

        public int Get_Bus_Total_Row()
        {
            return BusExt.Instance.Get_Total_Rows();
        }
        public void DeleteBusByIDs(List<string> list)
        {
            BusExt.Instance.Bus_Delete_IDs(list);
        }

        public Bus FindBusByBienSoXe(string biensoxe)
        {
            return BusExt.Instance.Bus_Select_BienSoXe(biensoxe);
        }

        public BusType FindBusTypeByBusTypeNameAndCarMarker(string bustypename, string carmarker)
        {
            return BusTypeExt.Instance.BusType_Select_BusTypeName(bustypename, carmarker);
        }

        public Bus FindBusByBusNumber(string busnumber)
        {
            return BusExt.Instance.Bus_Select_BusNumber(busnumber);
        }
        #endregion

        #region Driver
        public void Delete_IDs_Driver(List<String> IDs)
        {
            DriverExt.Instance.Delete_IDs(IDs);

        }

        public void Delete_IDs_DriverOfBus(List<String> IDs)
        {
            DriverOfBusExt.Instance.Delete_IDs(IDs);

        }
        public int InsertNUpdateDriver(Driver driver)
        {
            return DriverExt.Instance.InsertUpdate(driver);
        }

        public int InsertNUpdateDriverOfBus(Driver_Bus driver)
        {
            return DriverOfBusExt.Instance.InsertUpdate(driver);
        }

        public Driver Select_Driver_ID(int id)
        {
            return DriverExt.Instance.Select_ID(id);
        }

        public Driver_Bus Select_BusOfDriver_ID(int id)
        {
            return DriverOfBusExt.Instance.Select_ID(id);
        }

        public List<Driver> Driver_Pagination(string keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            return DriverExt.Instance.Find_KeyWord(keyword, PageSize, PageIndex, out TotalRows);
        }
        #endregion

        #region
        public List<POST> Select_All_POST()
        {
            return PostExt.Instance.POST_Select_All();
        }

        public POST Select_POST_ID(int id)
        {
            return PostExt.Instance.POST_Select_ID(id);
        }

        public int InsertNUpdatePOST(POST post)
        {
            return PostExt.Instance.POST_InsertUpdate(post);
        }

        public void DeletePOST(List<String> IDs)
        {
            PostExt.Instance.POST_Delete_IDs(IDs);
        }

        public List<POST> POST_Pagination(string keyword, int PageSize, int PageIndex, out int TotalRows)
        {
            return PostExt.Instance.POST_Find_KeyWord(keyword, PageSize, PageIndex, out TotalRows);
        }

        public List<Information> SelectAll()
        {
            return InformationExt.Instance.Information_Select_All();
        }

        public int InsertUpdateInfo(Information info)
        {
            return InformationExt.Instance.Info_InsertUpdate(info);
        }

        public void DeleteInfo(int id)
        {
            InformationExt.Instance.Info_Delete(id);
        }

        public Information GetInfo_FromID(int id)
        {
            return InformationExt.Instance.Info_Select_ID(id);
        }

        public List<Information> SearchByNameInformation(string nameValue)
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return InformationExt.Instance.Info_Select_By("Title", nameValue);
        }

        public List<Information> DeleteAll()
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return InformationExt.Instance.Info_Delete_all();
        }

        public ReflectType GetReflectTypeByID(int id)
        {
            return ReflectTypeExt.Instance.ReflectType_Select_ID(id);
        }

        public List<Reflect> SelectAllReflect()
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return ReflectExt.Instance.Reflect_Select_All();
        }

        public List<Reflect> SearchReflectCriteria(string multiColumn, int pageSize, int pageIndex, out int total)
        {
            return ReflectExt.Instance.Reflect_Find_KeyWord(multiColumn, pageSize, pageIndex, out total);
        }

        public List<ReflectType> SearchReflectTypeByCrieria(string multiColumn, int pageSize, int pageIndex, out int total)
        {
            return ReflectTypeExt.Instance.ReflectType_Find_KeyWord(multiColumn, pageIndex, pageSize, out total);
        }

        public List<ReflectType> SelectAllReflectType()
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return ReflectTypeExt.Instance.ReflectType_Select_All();
        }

        public void AddReflect(object reflect)
        {
            throw new NotImplementedException();
        }

        public int InsertUpdateReflectType(int id, string name)
        {
            ReflectType reflectType;
            reflectType = new ReflectType
            {
                ReflectTypeID = id,
                Name = name,

            };
            return ReflectTypeExt.Instance.ReflectType_InsertUpdate(reflectType);
        }


        public int AddReflect(Reflect reflect)
        {
            return ReflectExt.Instance.Reflect_InsertUpdate(reflect);
        }

        public Reflect FindReflectByID(int id)
        {
            return ReflectExt.Instance.Reflect_Select_ID(id);
        }

        public ReflectType FindReflectTypeByID(int id)
        {
            return ReflectTypeExt.Instance.ReflectType_Select_ID(id);
        }

        public ReflectType SelectReflectTypeByIDs(int id)
        {
            return ReflectTypeExt.Instance.ReflectType_Select_ID(id);
        }

        public void DeleteReflectType(int id)
        {
            ReflectTypeExt.Instance.ReflectType_Delete(id);
        }

        public void DeleteReflectTypeIDs(List<string> ids)
        {
            ReflectTypeExt.Instance.ReflectType_Delete_IDs(ids);
        }

        public void DeleteReflectByID(int id)
        {
            ReflectExt.Instance.Reflect_Delete(id);
        }

        public List<Reflect> Reflect_Pagination(int PageSize, int PageIndex, out int TotalRows)
        {
            return ReflectExt.Instance.Reflect_Pagination(PageSize, PageIndex, out TotalRows);
        }

        public List<ReflectType> Reflect_Type_Pagination(int PageSize, int PageIndex, out int TotalRows)
        {
            return ReflectTypeExt.Instance.ReflectType_Pagination(PageSize, PageIndex, out TotalRows);
        }

        public int Get_Reflect_Total_Row()
        {
            return ReflectExt.Instance.Get_Total_Rows();
        }
        public void DeleteReflectByIDs(List<string> list)
        {
            ReflectExt.Instance.Reflect_Delete_IDs(list);
        }
        public void DeleteReflect(int id)
        {
            ReflectExt.Instance.Reflect_Delete(id);
        }

        public Reflect FindBusByTitle(string tieude)
        {
            return ReflectExt.Instance.Reflect_Select_Title(tieude);
        }
        public List<Reflect> Reflect_Find_KeyWord(int PageSize, int PageIndex, out int TotalRows)
        {
            return ReflectExt.Instance.Reflect_Find_KeyWord("", PageSize, PageIndex, out TotalRows);
        }
        public List<ReflectType> Reflect_Find_Type_KeyWord(int PageSize, int PageIndex, out int TotalRows)
        {
            return ReflectTypeExt.Instance.ReflectType_Find_KeyWord("", PageSize, PageIndex, out TotalRows);
        }

        public ReflectType FindBusTypeByReflectTypeNameAndCarMarker(string Reflecttypename)
        {
            return ReflectTypeExt.Instance.ReflectType_Select_ReflectTypeName(Reflecttypename);
        }

        public void DeleteListDocumentType(List<string> list)
        {
            DocumentTypeExt.Instance.Delete_IDs(list);
        }

        public int InsertUpdate_DocumentType(DocumentType obj)
        {
            return DocumentTypeExt.Instance.InsertUpdate(obj);
        }

        public int InsertUpdate_Document(Document obj)
        {
            return DocumentExt.Instance.InsertUpdate(obj);
        }


        public DocumentType EditDocument_ByID(int idEdit)
        {
            return DocumentTypeExt.Instance.Select_ID(idEdit);
        }

        public Document EditDocumentUI_ByID(int idEdit)
        {
            return DocumentExt.Instance.Select_ID(idEdit);
        }

        public List<DocumentType> FindDocumentTypeByKeyWord(string value, int pagesize, int index, out int rows)
        {
            return DocumentTypeExt.Instance.Find_KeyWord(value, pagesize, index, out rows);
        }

        public List<Document> FindDocumentByKeyWord(string value, int pagesize, int index, out int rows)
        {
            return DocumentExt.Instance.Find_KeyWord(value, pagesize, index, out rows);
        }

        public Document SelectDocumentId(int id)
        {
            return DocumentExt.Instance.Select_ID(id);
        }

        public List<Document> FindDocumentByPage(int pagesize, int pindex, out int rows)
        {
            return DocumentExt.Instance.Find_DocumentAll(pagesize, pindex, out rows);
        }

        public List<Document> Load_DocumentFindType(string loai, int pagesize, int pindex, out int rows)
        {
            return DocumentExt.Instance.Find_DocumentType(loai, pagesize, pindex, out rows);
        }

        public List<DocumentType> SelectAll_DocumentType()
        {
            return DocumentTypeExt.Instance.Select_All();
        }

        public List<HandlingViolation> SelectAllHand()
        {
            return handlingViolationsExt.Instance.HandlingViolation_Select_All();
        }
        public List<String> SelectTitle()
        {
            return handlingViolationsExt.Instance.HandlingViolation_Select_All().Select(x => x.Title).ToList();
        }
        public int InsertUpdateInfo(HandlingViolation info)
        {
            return handlingViolationsExt.Instance.HandlingViolations_InsertUpdate(info);
        }

        public void DeleteInfoHand(int id)
        {
            handlingViolationsExt.Instance.HandlingViotions_Delete(id);
        }

        public HandlingViolation GetInfo_FromIDHand(int id)
        {
            return handlingViolationsExt.Instance.HandlingViolation_Select_ID(id);
        }

        public List<HandlingViolation> SearchByNameHand(string nameValue)
        {
            //Ghi loc, kiem tra quyen, kiem du lieu co hop le khong?
            return handlingViolationsExt.Instance.HandlingViolation_Select_By("Title", nameValue);
        }

        #endregion
    }
}
